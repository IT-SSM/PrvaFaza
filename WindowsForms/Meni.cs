using SQLModifications.DomenskeKlase;
using SQLModifications.WindowsForms;
using SQLModifications.WindowsForms.Escalation;
using SQLModifications.WindowsForms.Update;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQLModifications
{
    public partial class Meni : Form
    {
        public Meni()
        {
            InitializeComponent();
            
        }

        private void tableToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new CreateTable().ShowDialog();
        }

        private void columnToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new CreateColumn().ShowDialog();
        }

        private void viewTableToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new ViewTable().ShowDialog();
        }

        private void tableToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            new UpdateTable().ShowDialog();
        }

        private void columnToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            new UpdateColumn().ShowDialog();
        }

        private void viewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (PocetnaForma.database == "MSSQL")
            {
                new UpdateView().ShowDialog();
            }
        }

        private void createToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (PocetnaForma.database == "MSSQL")
            {
                new CreateEscalation().ShowDialog();
            }
        }
    }
}
