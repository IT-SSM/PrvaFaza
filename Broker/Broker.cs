using SQLModifications.DomenskeKlase;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQLModifications.Broker
{
    public class Broker
    {
        #region Fields
        private static Broker _instanca;
        private SqlConnection konekcija;
        private SqlTransaction transakcija;
        #endregion

        #region Broker
        public static Broker Instanca
        {
            get
            {
                if (_instanca == null)
                {
                    _instanca = new Broker();
                }
                return _instanca;
            }
        }

        private Broker()
        {
            konekcija = new SqlConnection(@"Data Source=ca172sql;Initial Catalog=ctickets;Integrated Security=True");
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

        #region Create
        public int vratiMaxID()
        {
            OtvoriKonekciju();
            string upit = "SELECT MAX(id) FROM dbo.tbl_list";
            SqlCommand komanda = new SqlCommand(upit, konekcija, transakcija);
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
                int createDate = Convert.ToInt32(DateTimeToUnixTimestamp(DateTime.Now));
                string upit = "INSERT INTO dbo.tbl_list (table_name, ootb, create_date, created_by)" +
                              "values('" + txtName.Text + "', 0, " + createDate + ",'C#Nindze')";
                SqlCommand komanda = new SqlCommand(upit, konekcija, transakcija);
                rezultat = komanda.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if(rezultat == 1)
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
                SqlCommand komanda = new SqlCommand(upit, konekcija, transakcija);
                rezultat = komanda.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                
            }
            finally
            {
                if(rezultat == -1)
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
            string upit = "SELECT * from dbo.tbl_list";
            SqlCommand komanda = new SqlCommand(upit, konekcija, transakcija);
            DataTable tabela = new DataTable();
            SqlDataReader citac = komanda.ExecuteReader();
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
            string upit = "SELECT * from dbo.col_list";
            SqlCommand komanda = new SqlCommand(upit, konekcija, transakcija);
            DataTable tabela = new DataTable();
            SqlDataReader citac = komanda.ExecuteReader();
            tabela.Load(citac);

            foreach(DataColumn col in tabela.Columns)
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
            string upit = "SELECT * from dbo.data_type";
            SqlCommand komanda = new SqlCommand(upit, konekcija, transakcija);
            DataTable tabela = new DataTable();
            SqlDataReader citac = komanda.ExecuteReader();
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
                    upit = "SELECT COUNT(*) FROM dbo.col_list WHERE table_name = '" + tabela.SelectedItem.ToString() + "' " +
                        "AND column_name= '" + txtNazivKolone.Text + "'";


                }
                catch (Exception ex)
                {
                   
                    MessageBox.Show("Kolona vec postoji!" + ex.Message);
                }

                SqlCommand komanda = new SqlCommand(upit, konekcija, transakcija);
                rezultat = (int)komanda.ExecuteScalar();
               
            }
            catch (Exception ex)
            {

                MessageBox.Show("Kolona vec postoji!" + ex.Message);
            }
            finally
            {
                if(rezultat > 0)
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
                int createDate = Convert.ToInt32(DateTimeToUnixTimestamp(DateTime.Now));
                string upit = "INSERT INTO dbo.col_list (table_name, column_name, type, create_date, created_by, max_string_len)" +
                              "values('" + comboTabela.SelectedItem.ToString() + "', '"+nazivKolone.Text+"',"+ type +", " + createDate + ",'C#Nindze', '"+attr+"')";
                SqlCommand komanda = new SqlCommand(upit, konekcija, transakcija);
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
                
                foreach(var item in vratiSveDataTypeove())
                {
                    if(item.TypeName == comboTypes.SelectedItem.ToString())
                    {
                        type = item.SqlDataType;
                    }
                }
                if(comboTypes.SelectedItem.ToString() == "Character")
                {
                    type = attr;
                }
                
                OtvoriKonekciju();
                PocniTransakciju();
                string upit = "ALTER TABLE " + comboTabela.SelectedItem.ToString() +" add "+nazivKolone.Text+" "+type+"";
                SqlCommand komanda = new SqlCommand(upit, konekcija, transakcija);
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
                foreach(var item in listBoxTabele1.CheckedItems)
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
                
                string upit = "CREATE VIEW  " + nazivTabele.Text + " AS SELECT "+select1+noviSelect+" FROM " + tab1 + " LEFT JOIN " +
                    "" + tab2 + " ON " + tab1 + "." +kol1+ " = " +tab2+ "." +kol2+""; // WHERE USLOV :D

                //string upit = "CREATE VIEW  " + nazivTabele.Text + " AS SELECT * FROM " + tab1 + " LEFT JOIN " +
                //    "" + tab2 + " ON " + tab1 + "." + kol1 + " = " + tab2 + "." + kol2 + "";
                SqlCommand komanda = new SqlCommand(upit, konekcija, transakcija);
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

        #region Update

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
                    upit = "SELECT COUNT(*) FROM "+comboTabela.SelectedItem.ToString()+"";

                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }

                SqlCommand komanda = new SqlCommand(upit, konekcija, transakcija);
                rezultat = (int)komanda.ExecuteScalar();

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
                string upit = "EXEC sp_rename 'dbo." + comboTabela.SelectedItem.ToString() + "','" + txtNazivTabele.Text + "'";
                SqlCommand komanda = new SqlCommand(upit, konekcija, transakcija);
                rezultat = komanda.ExecuteNonQuery();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if(rezultat != 0)
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
                string upit = "UPDATE dbo.tbl_list  SET table_name='" + txtNazivTabele.Text + "' WHERE table_name = '" + comboTabela.SelectedItem.ToString()+"'";
                SqlCommand komanda = new SqlCommand(upit, konekcija, transakcija);
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
                string upit = "UPDATE dbo.col_list  SET table_name='" + txtNazivTabele.Text + "' WHERE table_name = '" + comboTabela.SelectedItem.ToString() + "'";
                SqlCommand komanda = new SqlCommand(upit, konekcija, transakcija);
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
            string upit = "SELECT * FROM dbo."+ comboTabela.SelectedItem.ToString()+"";
            SqlCommand komanda = new SqlCommand(upit, konekcija, transakcija);
            DataTable tabela = new DataTable();
            SqlDataReader citac = komanda.ExecuteReader();
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
            string upit = "SELECT column_name FROM dbo.col_list WHERE table_name='" + comboTabela.SelectedItem.ToString() + "'";
            SqlCommand komanda = new SqlCommand(upit, konekcija, transakcija);
            DataTable tabela = new DataTable();
            SqlDataReader citac = komanda.ExecuteReader();
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
            string upit = "SELECT column_name FROM dbo.col_list";
            SqlCommand komanda = new SqlCommand(upit, konekcija, transakcija);
            DataTable tabela = new DataTable();
            SqlDataReader citac = komanda.ExecuteReader();
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

                SqlCommand komanda = new SqlCommand(upit, konekcija, transakcija);
                rezultat = (int)komanda.ExecuteScalar();

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
                string upit = "UPDATE dbo.col_list  SET column_name='" + txtKolona.Text + "' WHERE table_name = '" + comboTabela.SelectedItem.ToString() + "' AND column_name = '" + comboKolona.SelectedItem.ToString() + "'";
                SqlCommand komanda = new SqlCommand(upit, konekcija, transakcija);
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
                string upit = "EXEC sp_RENAME '" + comboTabela.SelectedItem.ToString() + "." + comboKolona.SelectedItem.ToString() + "', '" + txtKolona.Text + "', 'COLUMN'";
                SqlCommand komanda = new SqlCommand(upit, konekcija, transakcija);
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
            string upit = "SELECT type FROM dbo.col_list WHERE table_name='" + comboTabela.SelectedItem.ToString() + "' AND column_name = '" + comboKolona.SelectedItem.ToString() + "'";
            SqlCommand komanda = new SqlCommand(upit, konekcija, transakcija);
            DataTable tabela = new DataTable();
            if (konekcija.State == ConnectionState.Closed)
            {
                OtvoriKonekciju();
            }
            SqlDataReader citac = komanda.ExecuteReader();
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
                string upit = "UPDATE dbo.col_list  SET type=" + type + " WHERE table_name = '" + tabela.SelectedItem.ToString() + "' AND column_name = '" + kolona.SelectedItem.ToString() + "'";
                SqlCommand komanda = new SqlCommand(upit, konekcija, transakcija);
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
                }

                if (konekcija.State == ConnectionState.Closed)
                {
                    OtvoriKonekciju();
                }

                PocniTransakciju();
                string upit = "ALTER TABLE " + tabela.SelectedItem.ToString() + " ALTER COLUMN " + kolona.SelectedItem.ToString() + " " + type + "";
                SqlCommand komanda = new SqlCommand(upit, konekcija, transakcija);
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

        public List<ViewList> VratiSveViewove()
        {
            //OtvoriKonekciju();
            if (konekcija.State == ConnectionState.Closed)
            {
                OtvoriKonekciju();
            }
            List<ViewList> lista = new List<ViewList>();
            string upit = "SELECT * FROM sys.views";
            SqlCommand komanda = new SqlCommand(upit, konekcija, transakcija);
            DataTable tabela = new DataTable();
            SqlDataReader citac = komanda.ExecuteReader();
            tabela.Load(citac);

            foreach (DataRow red in tabela.Rows)
            {
                ViewList viewNameList = new ViewList();
                //tableNameList.Id = Convert.ToInt32(red[0]);
                viewNameList.Name = red[0].ToString();
                //DataTypes dataTypes = new DataTypes();
                //dataTypes.Id = Convert.ToInt32(red[0]);
                //dataTypes.TypeName = red[1].ToString();
                //dataTypes.Enum = Convert.ToInt32(red[2]);
                //dataTypes.SqlDataType = red[3].ToString();
                //dataTypes.AttrMaxLength = Convert.ToInt32(red[4]);
                //dataTypes.AttrMaxSize = Convert.ToInt32(red[5]);
                lista.Add(viewNameList);
            }
            ZatvoriKonekciju();
            return lista;
        }
        public DataTable PopuniDataGridView(ComboBox combo)
        {
            OtvoriKonekciju();
            string upit = "SELECT * FROM " + combo.SelectedItem.ToString() + "";

            SqlDataAdapter da = new SqlDataAdapter(upit, konekcija);
            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(da);
            DataTable table = new DataTable
            {
                Locale = CultureInfo.InvariantCulture
            };

            da.Fill(table);


            ZatvoriKonekciju();
            return table;
        }

        public Dictionary<string, bool> VratiPrvuTabeluZaOdabraniView(ComboBox comboView, CheckedListBox checkedListBox, Label clbLabel1)
        {
            string prvaTabela;
            //string drugaTabela;
            List<string> chekiraneKoloneZaPrvuTabelu = new List<string>();
            Dictionary<string, bool> koloneZaPrvuTabelu = new Dictionary<string, bool>();
            // List<string> koloneZaDruguTabelu = new List<string>();
            List<string> viewTabele = new List<string>();

            //OtvoriKonekciju();
            if (konekcija.State == ConnectionState.Closed)
            {
                OtvoriKonekciju();
            }
            //List<DataTypes> lista = new List<DataTypes>();
            string tabeleUpit = "SELECT view_name, Table_Name FROM INFORMATION_SCHEMA.VIEW_TABLE_USAGE " +
                            "WHERE View_Name = '" + comboView.SelectedItem.ToString() + "' ORDER BY view_name, table_name";
            SqlCommand komanda = new SqlCommand(tabeleUpit, konekcija, transakcija);
            DataTable tabela = new DataTable();
            SqlDataReader citac = komanda.ExecuteReader();
            tabela.Load(citac);

            foreach (DataRow red in tabela.Rows)
            {
                viewTabele.Add(red[1].ToString());
            }

            prvaTabela = viewTabele[0];
            clbLabel1.Text = prvaTabela;
            // drugaTabela = viewTabele[1];

            koloneZaPrvuTabelu = this.vratiKoloneZaIzabranuTabeluDict(prvaTabela);
            //koloneZaDruguTabelu = this.vratiKoloneZaIzabranuTabeluString(drugaTabela);

            OtvoriKonekciju();
            string chekiraneKoloneUpit = "EXEC sp_depends @objname = N'" + comboView.SelectedItem.ToString() + "'";
            SqlCommand command = new SqlCommand(chekiraneKoloneUpit, konekcija);
            DataTable table = new DataTable();
            SqlDataReader reader = command.ExecuteReader();
            table.Load(reader);

            foreach (DataRow row in table.Rows)
            {
                if (row[0].ToString() == "dbo." + prvaTabela)
                    chekiraneKoloneZaPrvuTabelu.Add(row[4].ToString());
            }

            foreach (var item in chekiraneKoloneZaPrvuTabelu)
            {
                if (koloneZaPrvuTabelu.ContainsKey(item))
                {
                    koloneZaPrvuTabelu[item] = true;
                }
            }

            ZatvoriKonekciju();
            return koloneZaPrvuTabelu;
        }

        public Dictionary<string, bool> VratiDruguTabeluZaOdabraniView(ComboBox comboView, CheckedListBox checkedListBox, Label clbLabel2)
        {
            //string prvaTabela;
            string drugaTabela;
            //List<string> koloneZaPrvuTabelu = new List<string>();
            List<string> chekiraneKoloneZaDruguTabelu = new List<string>();
            Dictionary<string, bool> koloneZaDruguTabelu = new Dictionary<string, bool>();
            List<string> viewTabele = new List<string>();

            //OtvoriKonekciju();
            if (konekcija.State == ConnectionState.Closed)
            {
                OtvoriKonekciju();
            }
            //List<DataTypes> lista = new List<DataTypes>();
            string tabeleUpit = "SELECT view_name, Table_Name FROM INFORMATION_SCHEMA.VIEW_TABLE_USAGE " +
                            "WHERE View_Name = '" + comboView.SelectedItem.ToString() + "' ORDER BY view_name, table_name";
            SqlCommand komanda = new SqlCommand(tabeleUpit, konekcija, transakcija);
            DataTable tabela = new DataTable();
            SqlDataReader citac = komanda.ExecuteReader();
            tabela.Load(citac);

            foreach (DataRow red in tabela.Rows)
            {
                viewTabele.Add(red[1].ToString());
            }

            //prvaTabela = viewTabele[0];
            drugaTabela = viewTabele[1];
            clbLabel2.Text = drugaTabela;

            //koloneZaPrvuTabelu = this.vratiKoloneZaIzabranuTabeluString(prvaTabela);
            koloneZaDruguTabelu = this.vratiKoloneZaIzabranuTabeluDict(drugaTabela);

            OtvoriKonekciju();
            string chekiraneKoloneUpit = "EXEC sp_depends @objname = N'" + comboView.SelectedItem.ToString() + "'";
            SqlCommand command = new SqlCommand(chekiraneKoloneUpit, konekcija);
            DataTable table = new DataTable();
            SqlDataReader reader = command.ExecuteReader();
            table.Load(reader);

            foreach (DataRow row in table.Rows)
            {
                if (row[0].ToString() == "dbo." + drugaTabela)
                    chekiraneKoloneZaDruguTabelu.Add(row[4].ToString());
            }


            foreach (var item in chekiraneKoloneZaDruguTabelu)
            {
                if (koloneZaDruguTabelu.ContainsKey(item))
                {
                    koloneZaDruguTabelu[item] = true;
                }
            }

            ZatvoriKonekciju();
            return koloneZaDruguTabelu;
        }

        public int AlterView(ComboBox view, Label tabela1, Label tabela2, CheckedListBox listBoxTabele1, CheckedListBox listBoxTabele2)
        {
            int rezultat = 0;

            try
            {
                OtvoriKonekciju();
                PocniTransakciju();
                List<string> kolonePrveTabele = new List<string>();
                List<string> koloneDrugeTabele = new List<string>();
                string tab1 = tabela1.Text;
                string tab2 = tabela2.Text;
                string select1 = "";
                string select2 = "";
                string viewDefinition = "";
                string upitTab1 = "";

                string viewDefinitionUpit = "SELECT VIEW_DEFINITION FROM INFORMATION_SCHEMA.VIEWS " +
                                            "WHERE TABLE_NAME='" + view.SelectedItem.ToString() + "'";

                SqlCommand komanda = new SqlCommand(viewDefinitionUpit, konekcija, transakcija);
                DataTable tabela = new DataTable();
                SqlDataReader citac = komanda.ExecuteReader();
                tabela.Load(citac);

                foreach (DataRow red in tabela.Rows)
                {
                    viewDefinition = red[0].ToString();
                }


                viewDefinition = viewDefinition.Substring(viewDefinition.IndexOf("FROM ") + 5);
                upitTab1 = viewDefinition.Split(' ').First();
                //Debug.WriteLine(viewDefinition);
                //Debug.WriteLine(upitTab1);
                //return 0;

                if (upitTab1 == tab1)
                {
                    foreach (var item in listBoxTabele1.CheckedItems)
                    {
                        kolonePrveTabele.Add(item.ToString());
                    }
                    foreach (var item in listBoxTabele2.CheckedItems)
                    {
                        koloneDrugeTabele.Add(item.ToString());
                    }

                    foreach (var item in kolonePrveTabele)
                    {
                        select1 += tab1 + "." + item + ",";
                    }

                    foreach (var item in koloneDrugeTabele)
                    {
                        select2 += tab2 + "." + item + ",";
                    }
                }
                else
                {
                    foreach (var item in listBoxTabele2.CheckedItems)
                    {
                        kolonePrveTabele.Add(item.ToString());
                    }
                    foreach (var item in listBoxTabele1.CheckedItems)
                    {
                        koloneDrugeTabele.Add(item.ToString());
                    }

                    foreach (var item in kolonePrveTabele)
                    {
                        select1 += tab2 + "." + item + ",";
                    }

                    foreach (var item in koloneDrugeTabele)
                    {
                        select2 += tab1 + "." + item + ",";
                    }
                }

                string noviSelect = select2.Remove(select2.Length - 1, 1);

                string upit = "ALTER VIEW  " + view.SelectedItem.ToString() + " AS SELECT " + select1 + noviSelect +
                            " FROM " + viewDefinition + "";

                SqlCommand cmd = new SqlCommand(upit, konekcija, transakcija);
                rezultat = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greska: " + ex.Message);

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

        #region Pomocne metode
        //metoda za konvertovanje UnixTime-a u DateTime -> koristimo je za parametre Create_Date i Last_Modified_Date
        public static DateTime UnixTimeStampToDateTime(double unixTimeStamp)
        {
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dtDateTime;
        }

        //metoda za konvertovanje DateTime to UnixTime -> koristimo je za parametre Create_Date i Last_Modified_Date
        public static double DateTimeToUnixTimestamp(DateTime dateTime)
        {
            return (TimeZoneInfo.ConvertTimeToUtc(dateTime) -
                   new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc)).TotalSeconds;
        }

        public Dictionary<string, bool> vratiKoloneZaIzabranuTabeluDict(string comboTabela)
        {
            if (konekcija.State == ConnectionState.Closed)
            {
                OtvoriKonekciju();
            }
            Dictionary<string, bool> dict = new Dictionary<string, bool>();
            string upit = "SELECT * FROM dbo." + comboTabela + "";
            SqlCommand komanda = new SqlCommand(upit, konekcija, transakcija);
            DataTable tabela = new DataTable();
            SqlDataReader citac = komanda.ExecuteReader();
            tabela.Load(citac);

            foreach (DataColumn kolona in tabela.Columns)
            {
                dict.Add((kolona.ColumnName.ToString()), false);
            }
            ZatvoriKonekciju();
            return dict;
        }
        #endregion
    }
}
