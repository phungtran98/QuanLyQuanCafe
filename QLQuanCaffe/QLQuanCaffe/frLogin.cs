using QLQuanCaffe.DAO;
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
    public partial class frLogin : Form
    {
        public frLogin()
        {
            InitializeComponent();
        }

      

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát ? ", "Thông báo", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
                e.Cancel = true;
        }

        



        private void frLogin_Load(object sender, EventArgs e)
        {

        }


        //ham kiem tra dang nhap

        bool Login(string user, string pass)
        {
            return AccountDAO.Instance.Login(user, pass);
        }

       
        private void btnLogin_Click(object sender, EventArgs e)
        {

            string username = txtUsername.Text;
            string password = txtPassword.Text;
            if (Login(username, password))
            {
                frTableManager f = new frTableManager();
                this.Hide();
                f.ShowDialog();
                this.Show();
            }
            else
                MessageBox.Show("Sai tài khoản hoặc mật khẩu");
        }

      

       
    }
}
