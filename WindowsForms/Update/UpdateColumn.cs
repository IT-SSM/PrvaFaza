using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQLModifications.WindowsForms.Update
{
    public partial class UpdateColumn : Form
    {
        KontrolerKorisnickogInterfejsa kki;
        public UpdateColumn()
        {
            InitializeComponent();
            kki = new KontrolerKorisnickogInterfejsa();
        }

        private void UpdateColumn_Load(object sender, EventArgs e)
        {
            kki.vratiSveNaziveTabela(comboBoxTabele);
            kki.vratiSveDataTypeove(comboBoxTypes);
            comboBoxTypes.Text = "--Izaberite tip kolone--";
            
        }

        private void comboBoxTabele_SelectedIndexChanged(object sender, EventArgs e)
        {
           
           kki.vratiKoloneZaIzabranuTabeluIzColLista(comboBoxTabele, comboBoxKolone);
        }

        private void buttonIzmenaNazivaKolone_Click(object sender, EventArgs e)
        {
            if(kki.daLiJeKolonaPrazna(comboBoxTabele, comboBoxKolone) == false) 
            {
                if (comboBoxTypes.SelectedItem.ToString() != "--Izaberite tip kolone--" && comboBoxTypes.SelectedItem.ToString() != textBoxTipKolone.Text)
                {

                    if (kki.promenaTipaKoloneUTabeli(comboBoxTabele, comboBoxKolone, textBoxTipKolone, textBoxNoviNazivKolone, comboBoxTypes) != 0 &&kki.promenaTipaKoloneUColListi(comboBoxTabele, comboBoxKolone, textBoxTipKolone, textBoxNoviNazivKolone, comboBoxTypes) != 0)
                    {
                        if (kki.izmenaNazivaKoloneUColListi(comboBoxTabele, comboBoxKolone, textBoxNoviNazivKolone) != 0
               && kki.izmenaNazivaKoloneUTabeli(comboBoxTabele, comboBoxKolone, textBoxNoviNazivKolone) != 0)
                        {
                            MessageBox.Show("Uspesno ste update-ovali kolonu!");
                        }
                   
                    }
                }
                else
                {
                    if (kki.izmenaNazivaKoloneUColListi(comboBoxTabele, comboBoxKolone, textBoxNoviNazivKolone) != 0
               && kki.izmenaNazivaKoloneUTabeli(comboBoxTabele, comboBoxKolone, textBoxNoviNazivKolone) != 0)
                    {
                        MessageBox.Show("Uspesno ste update-ovali kolonu!");
                    }
                }
            }
        }

        private void comboBoxKolone_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                textBoxTipKolone.Text = kki.vratiTipZaIzabranuKolonu(comboBoxTabele, comboBoxKolone);
            }
            catch (Exception)
            {

               textBoxTipKolone.Text = "";
            }
           
        }
    }
}
