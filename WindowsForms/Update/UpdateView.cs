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
    public partial class UpdateView : Form
    {
        KontrolerKorisnickogInterfejsa kki;
        public UpdateView()
        {
            InitializeComponent();
            kki = new KontrolerKorisnickogInterfejsa();
        }

        private void UpdateView_Load(object sender, EventArgs e)
        {
            kki.VratiSveViewove(cmbAllViews);
        }

        private void cmbAllViews_SelectedIndexChanged(object sender, EventArgs e)
        {
            kki.PopuniDataGridView(cmbAllViews, dataGridView);
            kki.PopuniKolonePrveTabeleViewa(cmbAllViews, checkedListBox1, clbLabel1);
            kki.PopuniKoloneDrugeTabeleViewa(cmbAllViews, checkedListBox2, clbLabel2);
        }

        private void btnUpdateView_Click(object sender, EventArgs e)
        {
            if(kki.AlterView(cmbAllViews, clbLabel1, clbLabel2, checkedListBox1, checkedListBox2) != 0)
            {
                MessageBox.Show("View je uspesno update-ovan!");
            }
        }
    }
}
