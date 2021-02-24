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
    public partial class PocetnaForma : Form
    {
        public static string database = "";
        public PocetnaForma()
        {
            InitializeComponent();
        }

        private void comboBoxDatabase_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBoxDatabase.SelectedItem.ToString() == "MSSQL")
            {
                database = "MSSQL";
                new Meni().ShowDialog();
               
            }
            else if(comboBoxDatabase.SelectedItem.ToString() == "Oracle")
            {
                database = "Oracle";
                new Meni().ShowDialog();
               
            }
        }
    }
}
