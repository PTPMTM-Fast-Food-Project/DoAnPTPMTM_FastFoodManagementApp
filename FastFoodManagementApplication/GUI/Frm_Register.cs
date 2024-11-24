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
    public partial class Frm_Register : Form
    {
        private AdminBLL adminBLL = new AdminBLL();
        public Frm_Register()
        {
            InitializeComponent();
            btnNaviLoginPage.Click += BtnNaviLoginPage_Click;
            btnRegister.Click += BtnRegister_Click;
        }

        private void BtnRegister_Click(object sender, EventArgs e)
        {
            string username = txbUsername.Text.Trim();
            string password = txbPassword.Text.Trim();
            string retypePassword = txbRetypePass.Text.Trim();

            if (username.Length <= 0 || password.Length <= 0 || retypePassword.Length <= 0)
            {
                MessageBox.Show("Please enter full username and password", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (!password.Equals(retypePassword))
            {
                MessageBox.Show("Password and retype password do not match", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (adminBLL.FindAdminByUsername(username) != null)
            {
                MessageBox.Show("Username already exists", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (adminBLL.HandleRegister(username, password))
            {
                MessageBox.Show("Registration successful, please log in", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Frm_Login login = new Frm_Login();
                login.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Registration failed, please try again", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnNaviLoginPage_Click(object sender, EventArgs e)
        {
            Frm_Login login = new Frm_Login();
            login.Show();
            this.Dispose();
        }
    }
}
