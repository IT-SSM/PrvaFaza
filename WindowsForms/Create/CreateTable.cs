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
    public partial class CreateTable : Form
    {
        KontrolerKorisnickogInterfejsa kki;
        public CreateTable()
        {
            InitializeComponent();
            kki = new KontrolerKorisnickogInterfejsa();
           
        }

        private void buttonCreateTable_Click(object sender, EventArgs e)
        {
            if(textBoxTableName.Text == "")
            {
                MessageBox.Show("Morate da unesete naziv tabele!");
                return;
            }

            try
            {
                if(kki.kreirajTabelu(textBoxTableName) == -1) // provera za commit i rollback!!!!
                {
                    if (kki.insertIntoTblList(textBoxTableName) == 1)
                    {
                        MessageBox.Show("Tabela je uspesno kreirana!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Doslo je do greske prilikom kreiranja tabele." + ex.Message);
                throw;
            }
        }
    }
}
