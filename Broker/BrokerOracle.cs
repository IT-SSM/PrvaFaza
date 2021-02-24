using Oracle.ManagedDataAccess.Client;
using SQLModifications.DomenskeKlase;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQLModifications.Broker
{
    public class BrokerOracle
    {
        #region Fields
        private static BrokerOracle _instanca;
        private OracleConnection konekcija;
        private OracleTransaction transakcija;
        #endregion

        #region Broker
        public static BrokerOracle Instanca
        {
            get
            {
                if (_instanca == null)
                {
                    _instanca = new BrokerOracle();
                }
                return _instanca;
            }
        }

        private BrokerOracle()
        {
            konekcija = new OracleConnection(@"TNS_ADMIN=C:\Users\mminic\Oracle\network\admin;USER ID=CTICKETSADMIN;Password=CT#Admin#;DATA SOURCE=10.20.128.162:1521/orclpdb"); //(@"Data Source=ca172sql;Initial Catalog=ctickets;Integrated Security=True");
        }

        public void OtvoriKonekciju()
        {
            konekcija.Open();
        }

        public void ZatvoriKonekciju()
        {
            konekcija.Close();
        }

        public void PocniTransakciju()
        {
            transakcija = konekcija.BeginTransaction();

        }

        public void PotvrdiTransakciju()
        {
            transakcija.Commit();
        }

        public void PonistiTransakciju()
        {
            transakcija.Rollback();
        }
        #endregion

        #region CreateOracle
        public int vratiMaxID()
        {
            OtvoriKonekciju();
            string upit = "SELECT MAX(id) FROM dbo.tbl_list";
            OracleCommand komanda = new OracleCommand(upit, konekcija);
            komanda.Transaction = transakcija;
            try
            {
                int sifra = Convert.ToInt32(komanda.ExecuteScalar());
                return sifra + 1;
            }
            catch (Exception)
            {
                return 1;
            }
            finally
            {
                PonistiTransakciju();
                ZatvoriKonekciju();
            }
        }

        public int insertIntoTblList(TextBox txtName)
        {
            int rezultat = 0;
            try
            {
                OtvoriKonekciju();
                PocniTransakciju();
                int createDate = Convert.ToInt32(Broker.DateTimeToUnixTimestamp(DateTime.Now));
                string upit = "INSERT INTO tbl_list (table_name, ootb, create_date, created_by)" +
                              "values('" + txtName.Text + "', 0, " + createDate + ",'C#Nindze')";
                OracleCommand komanda = new OracleCommand(upit, konekcija);
                komanda.Transaction = transakcija;
                rezultat = komanda.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (rezultat == 1)
                {
                    PotvrdiTransakciju();
                }
                else
                {
                    PonistiTransakciju();
                }
                ZatvoriKonekciju();
            }
            return rezultat;
        }

        public int kreirajTabelu(TextBox txtTableName)
        {
            int rezultat = 0;
            try
            {
                OtvoriKonekciju();
                PocniTransakciju();
                string upit = "CREATE TABLE " + txtTableName.Text + " (id int not null primary key, name varchar(50), createDate int, createdBy varchar(50), " +
                    "lastModDate int, lastModBy varchar(50))";
                OracleCommand komanda = new OracleCommand(upit, konekcija);
                komanda.Transaction = transakcija;
                rezultat = komanda.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            finally
            {
                if (rezultat == -1)
                {
                    PotvrdiTransakciju();
                }
                else
                {
                    PonistiTransakciju();
                }
                ZatvoriKonekciju();

            }
            return rezultat;
        }

        public List<TableList> vratiSveNaziveTabele()
        {
            OtvoriKonekciju();
            List<TableList> lista = new List<TableList>();
            string upit = "SELECT * from tbl_list";
            OracleCommand komanda = new OracleCommand(upit, konekcija);
            komanda.Transaction = transakcija;
            DataTable tabela = new DataTable();
            OracleDataReader citac = komanda.ExecuteReader();
            tabela.Load(citac);

            foreach (DataRow red in tabela.Rows)
            {
                TableList tableNameList = new TableList();
                //tableNameList.Id = Convert.ToInt32(red[0]);
                tableNameList.TableName = red[1].ToString();
                //tableList.DBMSName = red[2].ToString();
                //tableList.Description = red[3].ToString();
                //tableList.DisplayName = red[4].ToString();
                //tableList.DisplayGroup = red[5].ToString();
                //tableList.FunctionGroup = red[6].ToString();
                //tableList.RelAttr = red[7].ToString();
                //tableList.CommonName = red[8].ToString();
                //tableList.SortBy = red[9].ToString();
                //tableList.Methods = red[10].ToString();
                //tableList.Triggers = red[11].ToString();
                //tableList.IsLocal = Convert.ToInt32(red[12]);
                //tableList.LastModDate = UnixTimeStampToDateTime(Convert.ToDouble(red[13]));
                //tableList.LastModBy = red[14].ToString();
                //tableList.TableType = Convert.ToInt32(red[15]);
                //tableList.TenancyType = Convert.ToInt32(red[16]);
                //tableList.SlSortBy = red[17].ToString();
                //tableList.SLWhere = red[18].ToString();
                //tableList.OOTB = Convert.ToInt32(red[19]);
                //tableList.CreateDate = UnixTimeStampToDateTime(Convert.ToDouble(red[20]));
                //tableList.CreatedBy = red[21].ToString();

                lista.Add(tableNameList);
            }
            ZatvoriKonekciju();
            return lista;
        }

        public List<string> vratiSveKolone()
        {
            OtvoriKonekciju();
            List<string> lista = new List<string>();
            string upit = "SELECT * from col_list";
            OracleCommand komanda = new OracleCommand(upit, konekcija);
            komanda.Transaction = transakcija;
            DataTable tabela = new DataTable();
            OracleDataReader citac = komanda.ExecuteReader();
            tabela.Load(citac);

            foreach (DataColumn col in tabela.Columns)
            {
                lista.Add(col.ColumnName);

            }
            ZatvoriKonekciju();
            return lista;
        }

        public List<DataTypes> vratiSveDataTypeove()
        {
            //OtvoriKonekciju();
            if (konekcija.State == ConnectionState.Closed)
            {
                OtvoriKonekciju();
            }
            List<DataTypes> lista = new List<DataTypes>();
            string upit = "SELECT * from data_type";
            OracleCommand komanda = new OracleCommand(upit, konekcija);
            komanda.Transaction = transakcija;
            DataTable tabela = new DataTable();
            OracleDataReader citac = komanda.ExecuteReader();
            tabela.Load(citac);

            foreach (DataRow red in tabela.Rows)
            {
                DataTypes dataTypes = new DataTypes();
                dataTypes.Id = Convert.ToInt32(red[0]);
                dataTypes.TypeName = red[1].ToString();
                dataTypes.Enum = Convert.ToInt32(red[2]);
                dataTypes.SqlDataType = red[3].ToString();
                //dataTypes.AttrMaxLength = Convert.ToInt32(red[4]);
                //dataTypes.AttrMaxSize = Convert.ToInt32(red[5]);
                lista.Add(dataTypes);
            }
            ZatvoriKonekciju();
            return lista;
        }

        public bool proveraDaLiPostojiKolonaUTabeli(ComboBox tabela, TextBox txtNazivKolone)
        {
            int rezultat = 0;
            bool provera = false;
            try
            {
                OtvoriKonekciju();
                PocniTransakciju();
                string upit = null;
                try
                {
                    upit = "SELECT COUNT(*) FROM col_list WHERE table_name = '" + tabela.SelectedItem.ToString() + "' " +
                        "AND column_name= '" + txtNazivKolone.Text + "'";


                }
                catch (Exception ex)
                {

                    MessageBox.Show("Kolona vec postoji!" + ex.Message);
                }

                OracleCommand komanda = new OracleCommand(upit, konekcija);
                komanda.Transaction = transakcija;
                rezultat = Convert.ToInt32(komanda.ExecuteScalar());

            }
            catch (Exception ex)
            {

                MessageBox.Show("Kolona vec postoji!" + ex.Message);
            }
            finally
            {
                if (rezultat > 0)
                {
                    provera = true;
                    PonistiTransakciju();
                }
                else
                {
                    PotvrdiTransakciju();
                }
                ZatvoriKonekciju();
            }
            return provera;
        }

        public int insertIntoColList(ComboBox comboTabela, ComboBox comboTypes, TextBox nazivKolone, string attr)
        {
            int rezultat = 0;

            try
            {
                int type = 0;
                foreach (var item in vratiSveDataTypeove())
                {
                    if (item.TypeName == comboTypes.SelectedItem.ToString())
                    {
                        type = item.Enum;
                    }
                }

                OtvoriKonekciju();
                PocniTransakciju();
                int createDate = Convert.ToInt32(Broker.DateTimeToUnixTimestamp(DateTime.Now));
                string upit = "INSERT INTO col_list (table_name, column_name, type, create_date, created_by, max_string_len)" +
                              "values('" + comboTabela.SelectedItem.ToString() + "', '" + nazivKolone.Text + "'," + type + ", " + createDate + ",'C#Nindze', '" + attr + "')";
                OracleCommand komanda = new OracleCommand(upit, konekcija);
                komanda.Transaction = transakcija;
                rezultat = komanda.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (rezultat == 1)
                {
                    PotvrdiTransakciju();
                }
                else
                {
                    PonistiTransakciju();
                }
                ZatvoriKonekciju();
            }
            return rezultat;
        }

        public int kreirajKolonu(ComboBox comboTabela, TextBox nazivKolone, ComboBox comboTypes, string attr)
        {
            int rezultat = 0;
            string type = null;
            try
            {

                foreach (var item in vratiSveDataTypeove())
                {
                    if (item.TypeName == comboTypes.SelectedItem.ToString())
                    {
                        type = item.SqlDataType;
                    }
                }
                if (comboTypes.SelectedItem.ToString() == "Character")
                {
                    type = attr;
                }

                OtvoriKonekciju();
                PocniTransakciju();
                string upit = "ALTER TABLE " + comboTabela.SelectedItem.ToString() + " add " + nazivKolone.Text + " " + type + "";
                OracleCommand komanda = new OracleCommand(upit, konekcija);
                komanda.Transaction = transakcija;
                rezultat = komanda.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            finally
            {
                if (rezultat == -1)
                {
                    PotvrdiTransakciju();
                }
                else
                {
                    PonistiTransakciju();
                }
                ZatvoriKonekciju();

            }
            return rezultat;
        }

        public int kreirajViewTabelu(ComboBox tabela1, ComboBox tabela2, ComboBox kolona1, ComboBox kolona2, TextBox nazivTabele, CheckedListBox listBoxTabele1, CheckedListBox listBoxTabele2)
        {
            int rezultat = 0;
            try
            {
                OtvoriKonekciju();
                PocniTransakciju();
                List<string> kolonePrveTabele = new List<string>();
                List<string> koloneDrugeTabele = new List<string>();
                string tab1 = tabela1.SelectedItem.ToString();
                string tab2 = tabela2.SelectedItem.ToString();
                string kol1 = kolona1.SelectedItem.ToString();
                string kol2 = kolona2.SelectedItem.ToString();


                string select1 = "";
                string select2 = "";
                foreach (var item in listBoxTabele1.CheckedItems)
                {
                    kolonePrveTabele.Add(item.ToString());
                }
                foreach (var item in listBoxTabele2.CheckedItems)
                {
                    koloneDrugeTabele.Add(item.ToString());
                }

                // Prvo da se vidi kreiranje reference na drugu tabelu

                /*foreach (var item1 in kolonePrveTabele)
                {
                    foreach (var item2 in koloneDrugeTabele)
                    {
                        if (item1 == item2)
                        {

                        }
                    }
                }*/
                foreach (var item in kolonePrveTabele)
                {
                    select1 += tab1 + "." + item + ",";
                }

                foreach (var item in koloneDrugeTabele)
                {
                    select2 += tab2 + "." + item + ",";
                }

                string noviSelect = select2.Remove(select2.Length - 1, 1);

                string upit = "CREATE OR REPLACE VIEW  " + nazivTabele.Text + " AS SELECT " + select1 + noviSelect + " FROM " + tab1 + " LEFT JOIN " +
                    "" + tab2 + " ON " + tab1 + "." + kol1 + " = " + tab2 + "." + kol2 + ""; //Od view -> create || update(combo za odabir)  

                //string upit = "CREATE VIEW  " + nazivTabele.Text + " AS SELECT * FROM " + tab1 + " LEFT JOIN " +
                //    "" + tab2 + " ON " + tab1 + "." + kol1 + " = " + tab2 + "." + kol2 + "";
                OracleCommand komanda = new OracleCommand(upit, konekcija);
                komanda.Transaction = transakcija;
                rezultat = komanda.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            finally
            {
                if (rezultat == -1)
                {
                    PotvrdiTransakciju();
                }
                else
                {
                    PonistiTransakciju();
                }
                ZatvoriKonekciju();
            }
            return rezultat;
        }
        #endregion

        #region UpdateOracle

        public bool daLiPostojeZapisiUTabeli(ComboBox comboTabela)
        {
            int rezultat = 0;
            bool provera = false;
            try
            {
                OtvoriKonekciju();
                PocniTransakciju();
                string upit = null;
                try
                {
                    upit = "SELECT COUNT(*) FROM " + comboTabela.SelectedItem.ToString() + "";

                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }

                OracleCommand komanda = new OracleCommand(upit, konekcija);
                komanda.Transaction = transakcija;
                rezultat = Convert.ToInt32(komanda.ExecuteScalar());

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (rezultat > 0)
                {
                    provera = true;
                    PonistiTransakciju();
                }
                else
                {
                    PotvrdiTransakciju();
                }
                ZatvoriKonekciju();
            }
            return provera;
        }

        public int izmenaNazivaTabele(ComboBox comboTabela, TextBox txtNazivTabele)
        {
            int rezultat = 0;
            try
            {
                OtvoriKonekciju();
                PocniTransakciju();
                string upit = "ALTER TABLE " + comboTabela.SelectedItem.ToString() + " RENAME TO " + txtNazivTabele.Text + "";//"EXEC sp_rename '" + comboTabela.SelectedItem.ToString() + "','" + txtNazivTabele.Text + "'";
                OracleCommand komanda = new OracleCommand(upit, konekcija);
                komanda.Transaction = transakcija;
                rezultat = komanda.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (rezultat != 0)
                {
                    PotvrdiTransakciju();
                }
                else
                {
                    PonistiTransakciju();
                }
                ZatvoriKonekciju();
            }
            return rezultat;
        }

        public int izmenaNazivaTabeleUTblList(ComboBox comboTabela, TextBox txtNazivTabele)
        {
            int rezultat = 0;
            try
            {
                OtvoriKonekciju();
                PocniTransakciju();
                string upit = "UPDATE tbl_list  SET table_name='" + txtNazivTabele.Text + "' WHERE table_name = '" + comboTabela.SelectedItem.ToString() + "'";
                OracleCommand komanda = new OracleCommand(upit, konekcija);
                komanda.Transaction = transakcija;
                rezultat = komanda.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (rezultat != 0)
                {
                    PotvrdiTransakciju();
                }
                else
                {
                    PonistiTransakciju();
                }
                ZatvoriKonekciju();
            }
            return rezultat;
        }

        public int izmenaNazivaTabeleUColList(ComboBox comboTabela, TextBox txtNazivTabele)
        {
            int rezultat = 0;
            try
            {
                OtvoriKonekciju();
                PocniTransakciju();
                string upit = "UPDATE col_list  SET table_name='" + txtNazivTabele.Text + "' WHERE table_name = '" + comboTabela.SelectedItem.ToString() + "'";
                OracleCommand komanda = new OracleCommand(upit, konekcija);
                komanda.Transaction = transakcija;
                rezultat = komanda.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (rezultat != 0)
                {
                    PotvrdiTransakciju();
                }
                else
                {
                    PonistiTransakciju();
                }
                ZatvoriKonekciju();
            }
            return rezultat;
        }

        public List<string> vratiKoloneZaIzabranuTabelu(ComboBox comboTabela)
        {
            OtvoriKonekciju();
            List<string> lista = new List<string>();
            string upit = "SELECT * FROM " + comboTabela.SelectedItem.ToString() + "";
            OracleCommand komanda = new OracleCommand(upit, konekcija);
            komanda.Transaction = transakcija;
            DataTable tabela = new DataTable();
            OracleDataReader citac = komanda.ExecuteReader();
            tabela.Load(citac);

            foreach (DataColumn red in tabela.Columns)
            {
                lista.Add(red.ColumnName.ToString());
            }
            ZatvoriKonekciju();
            return lista;
        }

        public List<string> vratiKoloneZaIzabranuTabeluIzColLista(ComboBox comboTabela)
        {
            OtvoriKonekciju();
            List<string> lista = new List<string>();
            string upit = "SELECT column_name FROM col_list WHERE table_name='" + comboTabela.SelectedItem.ToString() + "'";
            OracleCommand komanda = new OracleCommand(upit, konekcija);
            komanda.Transaction = transakcija;
            DataTable tabela = new DataTable();
            OracleDataReader citac = komanda.ExecuteReader();
            tabela.Load(citac);

            foreach (DataRow red in tabela.Rows)
            {
                lista.Add(red[0].ToString());
            }
            ZatvoriKonekciju();
            return lista;
        }

        public List<ColumnsList> vratiSveKolone(ComboBox comboTabela)
        {
            OtvoriKonekciju();
            List<ColumnsList> lista = new List<ColumnsList>();
            string upit = "SELECT column_name FROM col_list";
            OracleCommand komanda = new OracleCommand(upit, konekcija);
            komanda.Transaction = transakcija;
            DataTable tabela = new DataTable();
            OracleDataReader citac = komanda.ExecuteReader();
            tabela.Load(citac);

            foreach (DataRow red in tabela.Rows)
            {
                ColumnsList cl = new ColumnsList();
                cl.ColumnName = red[0].ToString();
                lista.Add(cl);
            }
            ZatvoriKonekciju();
            return lista;
        }

        public bool daLiJeKolonaPrazna(ComboBox comboKolona, ComboBox comboTabela)
        {
            int rezultat = 0;
            bool provera = false;
            try
            {
                OtvoriKonekciju();
                PocniTransakciju();
                string upit = null;
                try
                {
                    upit = "SELECT COUNT(" + comboKolona.SelectedItem.ToString() + ") FROM " + comboTabela.SelectedItem.ToString() + "";

                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }

                OracleCommand komanda = new OracleCommand(upit, konekcija);
                komanda.Transaction = transakcija;
                rezultat = Convert.ToInt32(komanda.ExecuteScalar());

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (rezultat > 0)
                {
                    provera = true;
                    PonistiTransakciju();
                }
                else
                {
                    PotvrdiTransakciju();
                }
                ZatvoriKonekciju();
            }
            return provera;
        }

        public int izmenaNazivaKoloneUColListi(ComboBox comboTabela, ComboBox comboKolona, TextBox txtKolona)
        {
            int rezultat = 0;
            try
            {
                OtvoriKonekciju();
                PocniTransakciju();
                string upit = "UPDATE col_list  SET column_name='" + txtKolona.Text + "' WHERE table_name = '" + comboTabela.SelectedItem.ToString() + "' AND column_name = '" + comboKolona.SelectedItem.ToString() + "'";
                OracleCommand komanda = new OracleCommand(upit, konekcija);
                komanda.Transaction = transakcija;
                rezultat = komanda.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (rezultat != 0)
                {
                    PotvrdiTransakciju();
                }
                else
                {
                    PonistiTransakciju();
                }
                ZatvoriKonekciju();
            }
            return rezultat;
        }

        public int izmenaNazivaKoloneUTabeli(ComboBox comboTabela, ComboBox comboKolona, TextBox txtKolona)
        {
            int rezultat = 0;
            try
            {
                OtvoriKonekciju();
                PocniTransakciju();
                string upit = "ALTER TABLE " + comboTabela.SelectedItem.ToString() + " RENAME COLUMN " + comboKolona.SelectedItem.ToString() + " TO " + txtKolona.Text + "";//"EXEC sp_RENAME '" + comboTabela.SelectedItem.ToString() + "." + comboKolona.SelectedItem.ToString() + "', '" + txtKolona.Text + "', 'COLUMN'";
                OracleCommand komanda = new OracleCommand(upit, konekcija);
                komanda.Transaction = transakcija;
                rezultat = komanda.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (rezultat != 0)
                {
                    PotvrdiTransakciju();
                }
                else
                {
                    PonistiTransakciju();
                }
                ZatvoriKonekciju();
            }
            return rezultat;
        }

        public string vratiTipZaIzabranuKolonu(ComboBox comboTabela, ComboBox comboKolona)
        {
            //OtvoriKonekciju();
            int type = 0;
            string typeFormat = null;
            string upit = "SELECT type FROM col_list WHERE table_name='" + comboTabela.SelectedItem.ToString() + "' AND column_name = '" + comboKolona.SelectedItem.ToString() + "'";
            OracleCommand komanda = new OracleCommand(upit, konekcija);
            komanda.Transaction = transakcija;
            DataTable tabela = new DataTable();
            if (konekcija.State == ConnectionState.Closed)
            {
                OtvoriKonekciju();
            }
            OracleDataReader citac = komanda.ExecuteReader();
            tabela.Load(citac);

            foreach (DataRow red in tabela.Rows)
            {
                type = Convert.ToInt32(red[0]);
            }

            ZatvoriKonekciju();

            foreach (var item in vratiSveDataTypeove())
            {
                if (item.Enum == type)
                {
                    typeFormat = item.TypeName;
                }
            }

            return typeFormat;
        }

        public int promenaTipaKoloneUColListi(ComboBox tabela, ComboBox kolona, TextBox txtTip, TextBox nazivKolone, ComboBox tipPolja)
        {
            int rezultat = 0;
            try
            {
                int type = 0;
                foreach (var item in vratiSveDataTypeove())
                {
                    if (item.TypeName == tipPolja.SelectedItem.ToString())
                    {
                        type = item.Enum;
                    }
                }

                if (konekcija.State == ConnectionState.Closed)
                {
                    OtvoriKonekciju();
                }

                PocniTransakciju();
                string upit = "UPDATE col_list  SET type=" + type + " WHERE table_name = '" + tabela.SelectedItem.ToString() + "' AND column_name = '" + kolona.SelectedItem.ToString() + "'";
                OracleCommand komanda = new OracleCommand(upit, konekcija);
                komanda.Transaction = transakcija;
                rezultat = komanda.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (rezultat != 0)
                {
                    PotvrdiTransakciju();
                }
                else
                {
                    PonistiTransakciju();
                }
                ZatvoriKonekciju();
            }
            return rezultat;
        }

        public int promenaTipaKoloneUTabeli(ComboBox tabela, ComboBox kolona, TextBox txtTip, TextBox nazivKolone, ComboBox tipPolja)
        {
            int rezultat = 0;
            try
            {
                string type = "";
                foreach (var item in vratiSveDataTypeove())
                {
                    if (item.TypeName == tipPolja.SelectedItem.ToString())
                    {
                        type = item.SqlDataType;
                    }
                    //uslov samo za Character da mu se fiksira vrednost na 1000 karaktera, jer ne moze da primi MAX datatype
                    if(item.TypeName == "Character")
                    {
                        type = "VARCHAR2(1000)";
                    }
                }

                if (konekcija.State == ConnectionState.Closed)
                {
                    OtvoriKonekciju();
                }

                PocniTransakciju();
                string upit = "ALTER TABLE " + tabela.SelectedItem.ToString() + " MODIFY (" + kolona.SelectedItem.ToString() + " "+ type +")";
                OracleCommand komanda = new OracleCommand(upit, konekcija);
                komanda.Transaction = transakcija;
                rezultat = komanda.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (rezultat != 0)
                {
                    PotvrdiTransakciju();
                }
                else
                {
                    PonistiTransakciju();
                }
                ZatvoriKonekciju();
            }
            return rezultat;
        }

        #endregion
    }
}
