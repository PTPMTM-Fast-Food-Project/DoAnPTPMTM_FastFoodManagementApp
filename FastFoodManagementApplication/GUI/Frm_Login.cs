using BLL;
using DTO;
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
            btnForgotPass.Click += BtnForgotPass_Click;
        }

        private void BtnForgotPass_Click(object sender, EventArgs e)
        {
            Frm_ForgotPassword f = new Frm_ForgotPassword();
            f.ShowDialog();
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            //if (LoginHelper.Check_Config() == 0)
            //{
            //    ProcessLogin();// Cấu hình phù hợp xử lý đăng nhập
            //}
            //if (LoginHelper.Check_Config() == 1)
            //{
            //    MessageBox.Show("The configuration string does not exist", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);// Xử lý cấu hình
            //    ProcessConfig();
            //}
            //if (LoginHelper.Check_Config() == 2)
            //{
            //    MessageBox.Show("The configuration string does not match", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);// Xử lý cấu hình
            //    ProcessConfig();
            //}
            ProcessLogin();
        }

        private void ProcessLogin()
        {
            string username = txbUsername.Text;
            string password = txbPassword.Text;

            if (username.Length <= 0 || password.Length <= 0)
            {
                MessageBox.Show("Please enter full username and password", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (adminBLL.HandleLogin(username, password) == LoginResult.Success)
            {
                MessageBox.Show("Successful login, welcome " + username, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Frm_Dashboard dashboard = new Frm_Dashboard();
                dashboard.SetUsername(username);
                dashboard.Show();
                this.Visible = false;
            }
            else
            {
                MessageBox.Show("Login failed, please try again", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ProcessConfig()
        {
            Frm_Config f = new Frm_Config();
            f.ShowDialog();
        }
    }
}
