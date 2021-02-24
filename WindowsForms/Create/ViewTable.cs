using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQLModifications.WindowsForms
{
    public partial class ViewTable : Form
    {
        KontrolerKorisnickogInterfejsa kki;
        public ViewTable()
        {
            InitializeComponent();
            kki = new KontrolerKorisnickogInterfejsa();
        }

        private void ViewTable_Load(object sender, EventArgs e)
        {
            kki.vratiSveNaziveTabela(comboBoxTabele1);
            kki.vratiSveNaziveTabela(comboBoxTabele2);
            
        }

        private void comboBoxTabele1_SelectedIndexChanged(object sender, EventArgs e)
        {
            kki.vratiKoloneZaIzabranuTabelu(comboBoxTabele1, comboBoxKolonePrveTabele);
            kki.popuniCheckBoxList1(comboBoxTabele1, checkedListBox);
        }

        private void comboBoxTabele2_SelectedIndexChanged(object sender, EventArgs e)
        {
            kki.vratiKoloneZaIzabranuTabelu(comboBoxTabele2, comboBoxKoloneDrugeTabele);
            kki.popuniCheckBoxList2(comboBoxTabele2, checkedListBox1);
        }

        private void btnKreirajView_Click(object sender, EventArgs e)
        {
            //izaberi tabelu 1 
            //nadji u col_listi da li xrel_atribut nije null i prikazi vrednosti koje nisu null
            //za te vrednosti pozovi funkciju dajKolonuNaKojuReferenciraZaDatuTabelu();


            //posalji selektovane vrednosti iz checkBoxList1 i checkBoxList2
            if(kki.kreirajViewTabelu(comboBoxTabele1, comboBoxTabele2, comboBoxKolonePrveTabele, comboBoxKoloneDrugeTabele,txtView, checkedListBox, checkedListBox1) != 0)
            {

            }
        }
    }
}
