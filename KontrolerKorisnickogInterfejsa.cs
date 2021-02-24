using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SQLModifications.Broker;
using SQLModifications.WindowsForms;

namespace SQLModifications
{
    public class KontrolerKorisnickogInterfejsa
    {
        #region Methods
        public int kreirajTabelu(TextBox txtTableName)
        {
            try
            {
                if(PocetnaForma.database == "MSSQL") 
                {
                    return Broker.Broker.Instanca.kreirajTabelu(txtTableName);
                }
                if(PocetnaForma.database == "Oracle")
                {
                    return Broker.BrokerOracle.Instanca.kreirajTabelu(txtTableName);
                }
                return 0;
                
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public int insertIntoTblList(TextBox txtName)
        {
            try
            {
                if (PocetnaForma.database == "MSSQL")
                {
                    return Broker.Broker.Instanca.insertIntoTblList(txtName);
                }
                if (PocetnaForma.database == "Oracle") 
                { 
                    return Broker.BrokerOracle.Instanca.insertIntoTblList(txtName);
                }
                return 0;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void vratiSveNaziveTabela(ComboBox comboBoxTabele)
        {
            if (PocetnaForma.database == "MSSQL")
            {
                comboBoxTabele.DataSource = Broker.Broker.Instanca.vratiSveNaziveTabele();
            }
            else if(PocetnaForma.database == "Oracle")
            {
                comboBoxTabele.DataSource = Broker.BrokerOracle.Instanca.vratiSveNaziveTabele();
            }
        }

        public void vratiSveDataTypeove(ComboBox comboBoxTipovi)
        {
            List<string> pomLista = new List<string>();
            if (PocetnaForma.database == "MSSQL")
            {
                foreach (var pom in Broker.Broker.Instanca.vratiSveDataTypeove())
                {
                    pomLista.Add(pom.TypeName);
                }
                comboBoxTipovi.DataSource = pomLista;
            }
            else if(PocetnaForma.database == "Oracle")
            {
                foreach (var pom in Broker.BrokerOracle.Instanca.vratiSveDataTypeove())
                {
                    pomLista.Add(pom.TypeName);
                }
                comboBoxTipovi.DataSource = pomLista;
            }
        }

        public bool proveraDaLiPostojiKolonaUTabeli(ComboBox comboBoxTabela, TextBox txtNazivTabele)
        {
            if (PocetnaForma.database == "MSSQL")
            {
                return Broker.Broker.Instanca.proveraDaLiPostojiKolonaUTabeli(comboBoxTabela, txtNazivTabele);
            }
            else if(PocetnaForma.database == "Oracle")
            {
                return Broker.BrokerOracle.Instanca.proveraDaLiPostojiKolonaUTabeli(comboBoxTabela, txtNazivTabele);
            }
            return true;
        }

        public int insertIntoColList(ComboBox comboTabela, ComboBox comboTypes, TextBox nazivKolone, string attr)
        {
            
            try
            {
                if(PocetnaForma.database == "MSSQL")
                    return Broker.Broker.Instanca.insertIntoColList(comboTabela, comboTypes, nazivKolone, attr);
                else if(PocetnaForma.database == "Oracle")
                    return Broker.BrokerOracle.Instanca.insertIntoColList(comboTabela, comboTypes, nazivKolone, attr);
                return 0;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int kreirajKolonu(ComboBox comboTabela, TextBox nazivKolone, ComboBox comboTypes, string attr)
        {
            try
            {
                if(PocetnaForma.database == "MSSQL")
                    return Broker.Broker.Instanca.kreirajKolonu(comboTabela, nazivKolone, comboTypes, attr);
                else if(PocetnaForma.database == "Oracle")
                    return Broker.BrokerOracle.Instanca.kreirajKolonu(comboTabela, nazivKolone, comboTypes, attr);
                return 0;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool daLiPostojiZapisUTabeli(ComboBox comboBoxTabela)
        {
            if(PocetnaForma.database == "MSSQL")
                return Broker.Broker.Instanca.daLiPostojeZapisiUTabeli(comboBoxTabela);
            else if(PocetnaForma.database == "Oracle")
                return Broker.BrokerOracle.Instanca.daLiPostojeZapisiUTabeli(comboBoxTabela);
            return true;
        }

        public int izmenaNazivaTabele(ComboBox comboTabela, TextBox txtNazivTabele)
        {
            if (PocetnaForma.database == "MSSQL")
                return Broker.Broker.Instanca.izmenaNazivaTabele(comboTabela, txtNazivTabele);
            else if(PocetnaForma.database =="Oracle")
                return Broker.BrokerOracle.Instanca.izmenaNazivaTabele(comboTabela, txtNazivTabele);
            return 0;
        }

        public int izmenaNazivaTabeleUTblList(ComboBox comboTabela, TextBox txtNazivTabele)
        {
            if (PocetnaForma.database == "MSSQL")
                return Broker.Broker.Instanca.izmenaNazivaTabeleUTblList(comboTabela, txtNazivTabele);
            else if (PocetnaForma.database == "Oracle")
                return Broker.BrokerOracle.Instanca.izmenaNazivaTabeleUTblList(comboTabela, txtNazivTabele);
            return 0;
        }

        public int izmenaNazivaTabeleUColList(ComboBox comboTabela, TextBox txtNazivTabele)
        {
            if (PocetnaForma.database == "MSSQL")
                return Broker.Broker.Instanca.izmenaNazivaTabeleUColList(comboTabela, txtNazivTabele);
            else if (PocetnaForma.database == "Oracle")
                return Broker.BrokerOracle.Instanca.izmenaNazivaTabeleUColList(comboTabela, txtNazivTabele);
            return 0;
        }

        public void vratiKoloneZaIzabranuTabelu(ComboBox comboTabela, ComboBox comboColona)
        {
            if (PocetnaForma.database == "MSSQL")
                comboColona.DataSource = Broker.Broker.Instanca.vratiKoloneZaIzabranuTabelu(comboTabela);
            else if (PocetnaForma.database == "Oracle")
                comboColona.DataSource = Broker.BrokerOracle.Instanca.vratiKoloneZaIzabranuTabelu(comboTabela);
        }

        public void vratiKoloneZaIzabranuTabeluIzColLista(ComboBox comboTabela, ComboBox comboColona)
        {
            if (PocetnaForma.database == "MSSQL")
                comboColona.DataSource = Broker.Broker.Instanca.vratiKoloneZaIzabranuTabeluIzColLista(comboTabela);
            else if (PocetnaForma.database == "Oracle")
                comboColona.DataSource = Broker.BrokerOracle.Instanca.vratiKoloneZaIzabranuTabeluIzColLista(comboTabela);
        }

        public bool daLiJeKolonaPrazna(ComboBox comboBoxTabela,ComboBox comboBoxKolona)
        {
            if (PocetnaForma.database == "MSSQL")
                return Broker.Broker.Instanca.daLiJeKolonaPrazna(comboBoxKolona,comboBoxTabela);
            else if (PocetnaForma.database == "Oracle")
                return Broker.BrokerOracle.Instanca.daLiJeKolonaPrazna(comboBoxKolona, comboBoxTabela);
            return true;
        }

        public int izmenaNazivaKoloneUColListi(ComboBox comboTabela, ComboBox comboKolona, TextBox txtNazivKolone)
        {
            if (PocetnaForma.database == "MSSQL")
                return Broker.Broker.Instanca.izmenaNazivaKoloneUColListi(comboTabela, comboKolona, txtNazivKolone);
            else if (PocetnaForma.database == "Oracle")
                return Broker.BrokerOracle.Instanca.izmenaNazivaKoloneUColListi(comboTabela, comboKolona, txtNazivKolone);
            return 0;
        }

        public int izmenaNazivaKoloneUTabeli(ComboBox comboTabela, ComboBox comboKolona, TextBox txtNazivKolone)
        {
            if (PocetnaForma.database == "MSSQL")
                return Broker.Broker.Instanca.izmenaNazivaKoloneUTabeli(comboTabela, comboKolona, txtNazivKolone);
            else if (PocetnaForma.database == "Oracle")
                return Broker.BrokerOracle.Instanca.izmenaNazivaKoloneUTabeli(comboTabela, comboKolona, txtNazivKolone);
            return 0;
        }

        public string vratiTipZaIzabranuKolonu(ComboBox comboTabela, ComboBox comboKolona)
        {
            if (PocetnaForma.database == "MSSQL")
                return Broker.Broker.Instanca.vratiTipZaIzabranuKolonu(comboTabela, comboKolona);
            else if (PocetnaForma.database == "Oracle")
                return Broker.BrokerOracle.Instanca.vratiTipZaIzabranuKolonu(comboTabela, comboKolona);
            return null;
        }

        public int promenaTipaKoloneUColListi(ComboBox tabela, ComboBox kolona, TextBox txtTip, TextBox nazivKolone, ComboBox tipPolja)
        {
            if (PocetnaForma.database == "MSSQL")
                return Broker.Broker.Instanca.promenaTipaKoloneUColListi(tabela, kolona, txtTip, nazivKolone, tipPolja);
            else if (PocetnaForma.database == "Oracle")
                return Broker.BrokerOracle.Instanca.promenaTipaKoloneUColListi(tabela, kolona, txtTip, nazivKolone, tipPolja);
            return 0;
        }

        public int promenaTipaKoloneUTabeli(ComboBox tabela, ComboBox kolona, TextBox txtTip, TextBox nazivKolone, ComboBox tipPolja)
        {
            if (PocetnaForma.database == "MSSQL")
                return Broker.Broker.Instanca.promenaTipaKoloneUTabeli(tabela, kolona, txtTip, nazivKolone, tipPolja);
            else if (PocetnaForma.database == "Oracle")
                return Broker.BrokerOracle.Instanca.promenaTipaKoloneUTabeli(tabela, kolona, txtTip, nazivKolone, tipPolja);
            return 0;
        }

        public int kreirajViewTabelu(ComboBox tabela1, ComboBox tabela2, ComboBox kolona1, ComboBox kolona2, TextBox nazivTabele, CheckedListBox checkedListBox, CheckedListBox checkedListBox1)
        {
            if (PocetnaForma.database == "MSSQL")
                return Broker.Broker.Instanca.kreirajViewTabelu(tabela1, tabela2, kolona1, kolona2, nazivTabele, checkedListBox, checkedListBox1);
            else if (PocetnaForma.database == "Oracle")
                return Broker.BrokerOracle.Instanca.kreirajViewTabelu(tabela1, tabela2, kolona1, kolona2, nazivTabele, checkedListBox, checkedListBox1);
            return 0;
        }

        public void VratiSveViewove(ComboBox comboBoxViews)
        {
            if (PocetnaForma.database == "MSSQL")
            {
                comboBoxViews.DataSource = Broker.Broker.Instanca.VratiSveViewove();
            }
            else if (PocetnaForma.database == "Oracle")
            {

            }
        }

        public void PopuniDataGridView(ComboBox comboViews, DataGridView dataGridView)
        {
            if (PocetnaForma.database == "MSSQL")
            {
                dataGridView.DataSource = Broker.Broker.Instanca.PopuniDataGridView(comboViews);
                dataGridView.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader);
            }

        }

        public void PopuniKolonePrveTabeleViewa(ComboBox view, CheckedListBox kolonePrveTabeleViewa, Label clbLabel1)
        {
            if (PocetnaForma.database == "MSSQL")
            {
                kolonePrveTabeleViewa.Items.Clear();
                Dictionary<string, bool> dict = new Dictionary<string, bool>();
                dict = Broker.Broker.Instanca.VratiPrvuTabeluZaOdabraniView(view, kolonePrveTabeleViewa, clbLabel1);

                for (int i = 0; i < dict.Count; i++)
                {
                    kolonePrveTabeleViewa.Items.Add(dict.ElementAt(i).Key);
                    if (dict.ElementAt(i).Value == true)
                    {
                        kolonePrveTabeleViewa.SetItemChecked(i, true);
                    }
                }
            }
        }

        public void PopuniKoloneDrugeTabeleViewa(ComboBox view, CheckedListBox koloneDrugeTabeleViewa, Label clbLabel2)
        {
            if (PocetnaForma.database == "MSSQL")
            {
                koloneDrugeTabeleViewa.Items.Clear();
                Dictionary<string, bool> dict = new Dictionary<string, bool>();
                dict = Broker.Broker.Instanca.VratiDruguTabeluZaOdabraniView(view, koloneDrugeTabeleViewa, clbLabel2);

                for (int i = 0; i < dict.Count; i++)
                {
                    koloneDrugeTabeleViewa.Items.Add(dict.ElementAt(i).Key);
                    if (dict.ElementAt(i).Value == true)
                    {
                        koloneDrugeTabeleViewa.SetItemChecked(i, true);
                    }
                }
            }
        }

        public int AlterView(ComboBox cmbAllViews, Label tabela1, Label tabela2, CheckedListBox checkedLb1, CheckedListBox checkedLb2)
        {
            if (PocetnaForma.database == "MSSQL")
            {
               return Broker.Broker.Instanca.AlterView(cmbAllViews, tabela1, tabela2, checkedLb1, checkedLb2);
            }
            return 0;
        }
        public void popuniCheckBoxList1(ComboBox tabela1, CheckedListBox kolonePrveTabele)
        {
            if (PocetnaForma.database == "MSSQL")
            {
                kolonePrveTabele.Items.Clear();
                foreach (var item in Broker.Broker.Instanca.vratiKoloneZaIzabranuTabelu(tabela1))
                {
                    kolonePrveTabele.Items.Add(item);
                }
            }
            else if(PocetnaForma.database == "Oracle")
            {
                kolonePrveTabele.Items.Clear();
                foreach (var item in Broker.BrokerOracle.Instanca.vratiKoloneZaIzabranuTabelu(tabela1))
                {
                    kolonePrveTabele.Items.Add(item);
                }
            }
        }

        public void popuniCheckBoxList2(ComboBox tabela2, CheckedListBox kolone2Tabele) 
        {
            if (PocetnaForma.database == "MSSQL")
            {
                kolone2Tabele.Items.Clear();
                foreach (var item in Broker.Broker.Instanca.vratiKoloneZaIzabranuTabelu(tabela2))
                {
                    kolone2Tabele.Items.Add(item);
                }
            }
            else if (PocetnaForma.database == "Oracle")
            {
                kolone2Tabele.Items.Clear();
                foreach (var item in Broker.BrokerOracle.Instanca.vratiKoloneZaIzabranuTabelu(tabela2))
                {
                    kolone2Tabele.Items.Add(item);
                }
            }
        }

        #endregion
    }
}
