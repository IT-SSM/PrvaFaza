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
    public partial class UpdateTable : Form
    {
        KontrolerKorisnickogInterfejsa kki;
        public UpdateTable()
        {
            InitializeComponent();
            kki = new KontrolerKorisnickogInterfejsa();
        }

        private void UpdateTable_Load(object sender, EventArgs e)
        {
            kki.vratiSveNaziveTabela(comboBoxTabele);
        }

        private void btnPromenaNaziva_Click(object sender, EventArgs e)
        {
            
            if(kki.daLiPostojiZapisUTabeli(comboBoxTabele) == false)
            {
                if (kki.izmenaNazivaTabele(comboBoxTabele, textBoxNoviNazivTabele) != 0)
                {
                    if(kki.izmenaNazivaTabeleUTblList(comboBoxTabele, textBoxNoviNazivTabele) != 0
                     && kki.izmenaNazivaTabeleUColList(comboBoxTabele, textBoxNoviNazivTabele) != 0)
                    {
                        MessageBox.Show("Naziv tabele je uspesno izmenjen!");
                    }
                    else
                    {
                        MessageBox.Show("Neuspesna izmena!");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Neuspesna izmena!");
                    return;
                }
            }
            else
            {
                MessageBox.Show("Tabela ima zapise! Nije dozvoljeno promeniti naziv!");
                return;
            }
        }
    }
}
