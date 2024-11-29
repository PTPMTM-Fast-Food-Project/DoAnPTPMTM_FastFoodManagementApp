using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;

namespace GUI
{
    public partial class AddACustomer : Form
    {
        private CustomerBLL customerBLL = new CustomerBLL();
        public AddACustomer()
        {
            InitializeComponent();
            btnAdd.Click += BtnAdd_Click;
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();
            string retypePassword = txtRetypePass.Text.Trim();

            if (username.Length <= 0 || password.Length <= 0 || retypePassword.Length <= 0)
            {
                MessageBox.Show("Please enter full username, password and role", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (!password.Equals(retypePassword))
            {
                MessageBox.Show("Password and retype password do not match", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (customerBLL.FindCustomerByUsername(username) != null)
            {
                MessageBox.Show("Username already exists", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (customerBLL.HandleRegister(username, password))
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
            txtUsername.Clear();
            txtPassword.Clear();
            txtRetypePass.Clear();
            txtUsername.Focus();
        }
    }
}
