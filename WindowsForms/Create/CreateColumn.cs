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
    public partial class CreateColumn : Form
    {
        KontrolerKorisnickogInterfejsa kki;
        public CreateColumn()
        {
            InitializeComponent();
            kki = new KontrolerKorisnickogInterfejsa();
        }

        private void CreateColumn_Load(object sender, EventArgs e)
        {
            kki.vratiSveNaziveTabela(comboBoxTabele);
            kki.vratiSveDataTypeove(comboBoxTipPolja);
        }

        private void comboBoxTipPolja_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBoxTipPolja.Text == "Character")
            {
                label4.Visible = true;
                textBoxAtribut.Visible = true;
            }
            else
            {
                label4.Visible = false;
                textBoxAtribut.Visible = false;
                textBoxAtribut.Text = "";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string type = "";
            if (textBoxKolona.Text == "")
            {
                MessageBox.Show("Morate uneti naziv kolone!");
                return;
            }

            if( comboBoxTipPolja.SelectedItem.ToString() == "Character" && textBoxAtribut.Text == "")
            {
                MessageBox.Show("Popunite duzinu karaktera!");
                return;
            }
            else
            {
                if (PocetnaForma.database == "Oracle")
                {
                    type = "varchar2(" + textBoxAtribut.Text + ")";
                }

                if(PocetnaForma.database == "MSSQL")
                {
                    type = "varchar("+textBoxAtribut.Text+")";
                }
            }

            try
            {
                if (kki.proveraDaLiPostojiKolonaUTabeli(comboBoxTabele, textBoxKolona) == false)
                {
                    if (kki.insertIntoColList(comboBoxTabele, comboBoxTipPolja, textBoxKolona, textBoxAtribut.Text) == 1 && kki.kreirajKolonu(comboBoxTabele, textBoxKolona, comboBoxTipPolja,type) == -1)
                    {
                        MessageBox.Show("Kolona je uspesno dodata!");
                    }
                }
                else
                {
                    MessageBox.Show("Kolona vec postoji u tabeli!");
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greska prilikom dodavanja kolone! " + ex.Message);
                throw;
            }
          
        }
    }
}
