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
    public partial class Frm_AddAUser : Form
    {
        private AdminBLL adminBLL = new AdminBLL();
        private RoleBLL roleBLL = new RoleBLL();
        public Frm_AddAUser()
        {
            InitializeComponent();
            btnAdd.Click += BtnAdd_Click;
            this.Load += Frm_AddAUser_Load;
        }

        private void Frm_AddAUser_Load(object sender, EventArgs e)
        {
            cmbRoles.DataSource = roleBLL.FindAllRoles();
            cmbRoles.DisplayMember = "name";
            cmbRoles.ValueMember = "role_id";
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            string username = txbUsername.Text.Trim();
            string password = txbPassword.Text.Trim();
            string retypePassword = txbRetypePass.Text.Trim();
            
            if (username.Length <= 0 || password.Length <= 0 || retypePassword.Length <= 0 || cmbRoles.SelectedValue == null)
            {
                MessageBox.Show("Please enter full username, password and role", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

            long role = long.Parse(cmbRoles.SelectedValue.ToString());

            if (adminBLL.HandleRegister(username, password) && adminBLL.AuthorizeForUser(username, role))
            {
                MessageBox.Show("User added successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearInput();
            }
            else
            {
                MessageBox.Show("Adding user failed, please try again", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ClearInput()
        {
            txbUsername.Clear();
            txbPassword.Clear();
            txbRetypePass.Clear();
            cmbRoles.SelectedIndex = -1;
            txbUsername.Focus();
        }
    }
}
