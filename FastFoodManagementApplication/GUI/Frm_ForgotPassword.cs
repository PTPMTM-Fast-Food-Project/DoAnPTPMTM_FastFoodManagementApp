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
    public partial class Frm_ForgotPassword : Form
    {
        private AdminBLL adminBLL = new AdminBLL();
        public string Username { get; set; } = null;
        public Frm_ForgotPassword()
        {
            InitializeComponent();
            btnChangePass.Click += BtnChangePass_Click;
            Load += Frm_ForgotPassword_Load;
        }

        public void SetUsername(string username)
        {
            Username = username;
        }

        private void Frm_ForgotPassword_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Username))
            {
                txbUsername.Text = Username;
                txbUsername.Enabled = false;
            }
        }

        private void BtnChangePass_Click(object sender, EventArgs e)
        {
            string username = txbUsername.Text.Trim();
            string password = txbNewPass.Text.Trim();
            string retypePassword = txbRetypePass.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please do not leave the username and password blank", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (adminBLL.FindAdminByUsername(username) == null)
            {
                MessageBox.Show("Account does not exists, please try again", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (!password.Equals(retypePassword))
            {
                MessageBox.Show("Password and retype password do not match, please try again", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (adminBLL.ChangePassword(username, password))
            {
                MessageBox.Show("Password change successful, please log in again", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Visible = false;
            }
            else
            {
                MessageBox.Show("Password change failed, please try again", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }    
        }
    }
}
