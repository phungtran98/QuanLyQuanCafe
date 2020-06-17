using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLQuanCaffe
{
    public partial class frTableManager : Form
    {
        public frTableManager()
        {
            InitializeComponent();
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void thôngTinCáNhânToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frAccountProfile f = new frAccountProfile();

            this.Hide();

            f.ShowDialog();

            this.Show();
        }

        private void adminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frAdmin f = new frAdmin();

            f.ShowDialog();
        }

        
    }
}
