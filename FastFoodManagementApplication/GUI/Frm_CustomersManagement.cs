using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;  
using DTO;

namespace GUI
{
    public partial class Frm_CustomersManagement : Form
    {
        private CustomerBLL customerBLL = new CustomerBLL();
        public Frm_CustomersManagement()
        {
            InitializeComponent();
            this.Load += Frm_CustomersManagement_Load;
            btnAdd.Click += BtnAdd_Click;
            btnUpdate.Click += BtnUpdate_Click;
            dgvCustomerList.SelectionChanged += DgvCustomerList_SelectionChanged;
            btnDelete.Click += BtnDelete_Click;
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (dgvCustomerList.CurrentRow == null)
            {
                MessageBox.Show("Please select a user to delete", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string username = txtUsername.Text.Trim();

            DialogResult res = MessageBox.Show("Are you sure you want to delete this user?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (res == DialogResult.No)
                return;

            if (customerBLL.DeleteAdmin(username))
            {
                MessageBox.Show("Deleted successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadCustomerList();
            }
            else
            {
                MessageBox.Show("Delete failed, please try again", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void DgvCustomerList_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCustomerList.CurrentRow != null)
            {
                txtFirstName.Text = dgvCustomerList.CurrentRow.Cells[3].Value != null
                                    ? dgvCustomerList.CurrentRow.Cells[1].Value.ToString()
                                    : string.Empty;

                txtLastName.Text = dgvCustomerList.CurrentRow.Cells[4].Value != null
                                   ? dgvCustomerList.CurrentRow.Cells[2].Value.ToString()
                                   : string.Empty;

                txtUsername.Text = dgvCustomerList.CurrentRow.Cells[6].Value != null
                                   ? dgvCustomerList.CurrentRow.Cells[3].Value.ToString()
                                   : string.Empty;

                txtPhoneNumber.Text = dgvCustomerList.CurrentRow.Cells[5].Value != null
                                      ? dgvCustomerList.CurrentRow.Cells[4].Value.ToString()
                                      : string.Empty;

                txtAddress.Text = dgvCustomerList.CurrentRow.Cells[1].Value != null
                                  ? dgvCustomerList.CurrentRow.Cells[5].Value.ToString()
                                  : string.Empty;

                txtCountry.Text = dgvCustomerList.CurrentRow.Cells[2].Value != null
                                  ? dgvCustomerList.CurrentRow.Cells[6].Value.ToString()
                                  : string.Empty;
            }
            else
            {
                txtFirstName.Text = string.Empty;
                txtLastName.Text = string.Empty;
                txtUsername.Text = string.Empty;
                txtPhoneNumber.Text = string.Empty;
                txtAddress.Text = string.Empty;
                txtCountry.Text = string.Empty;
            }
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvCustomerList.CurrentRow == null)
            {
                MessageBox.Show("Please select a user to edit", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string username = txtUsername.Text.Trim();
            string firstName = txtFirstName.Text.Trim();
            string lastName = txtLastName.Text.Trim();
            string phone = txtPhoneNumber.Text.Trim();
            string address = txtAddress.Text.Trim();
            string country = txtCountry.Text.Trim();
            if (customerBLL.UpdateCustomer(username, firstName, lastName, phone, address, country))
            {
                MessageBox.Show("Updated successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadCustomerList();
            }
            else
            {
                MessageBox.Show("Update failed, please try again", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            AddACustomer addCustomer = new AddACustomer();
            addCustomer.ShowDialog();
            LoadCustomerList();
        }

        private void Frm_CustomersManagement_Load(object sender, EventArgs e)
        {
            LoadCustomerList();
        }

        private void LoadCustomerList()
        {
            try
            {
                var customers = customerBLL.GetAllCustomers().ToList();

                dgvCustomerList.DataSource = customers;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading customers: " + ex.Message);
            }
        }


    }
}
