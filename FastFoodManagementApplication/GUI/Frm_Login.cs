using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class Frm_Login : Form
    {
        private AdminBLL adminBLL = new AdminBLL();
        public Frm_Login()
        {
            InitializeComponent();
            btnLogin.Click += BtnLogin_Click;
            btnNaviRegisterPage.Click += BtnNaviRegisterPage_Click;
        }

        private void BtnNaviRegisterPage_Click(object sender, EventArgs e)
        {
            Frm_Register register = new Frm_Register();
            register.Show();
            this.Hide();
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            string username = txbUsername.Text;
            string password = txbPassword.Text;

            if (username.Length <= 0 || password.Length <= 0)
            {
                MessageBox.Show("Please enter full username and password", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (adminBLL.HandleLogin(username, password))
            {
                MessageBox.Show("Successful login, welcome " + username, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Frm_Dashboard dashboard = new Frm_Dashboard();
                dashboard.SetUsername(username);
                dashboard.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Login failed, please try again", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }    
        }
    }
}
