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
    public partial class Frm_RolesManagement : Form
    {
        private RoleBLL roleBLL = new RoleBLL();
        public Frm_RolesManagement()
        {
            InitializeComponent();
            this.Load += Frm_RolesManagement_Load;
            dgvRoleList.SelectionChanged += DgvRoleList_SelectionChanged;
            btnClear.Click += BtnClear_Click;
            btnAdd.Click += BtnAdd_Click;
            btnUpdate.Click += BtnUpdate_Click;
            btnDelete.Click += BtnDelete_Click;
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (dgvRoleList.CurrentRow == null)
            {
                MessageBox.Show("Please select a role to delete", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            role r = roleBLL.FindRoleByRoleName(txbRoleName.Text.Trim());

            DialogResult res = MessageBox.Show("Are you sure you want to delete this role?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (res == DialogResult.No)
                return;

            if (r != null && roleBLL.RemoveRoleAllUsers(r.role_id) && roleBLL.DeleteRole(r.role_id))
            {
                MessageBox.Show("Deleted successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadAllRoles();
            }
            else
            {
                MessageBox.Show("Delete failed, please try again", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvRoleList.CurrentRow == null)
            {
                MessageBox.Show("Please select a role to edit", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            role r = roleBLL.FindRoleByRoleName(txbRoleName.Text.Trim());

            if (r != null && roleBLL.UpdateRole(r.role_id, r.name))
            {
                MessageBox.Show("Updated successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadAllRoles();
            }
            else
            {
                MessageBox.Show("Update failed, please try again", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            string roleName = txbRoleName.Text.Trim();

            if (roleName.Length <= 0)
            {
                MessageBox.Show("Please enter role name", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (roleBLL.FindRoleByRoleName(roleName) != null)
            {
                MessageBox.Show("Role already exists", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (roleBLL.InsertRole(roleName))
            {
                MessageBox.Show("Insert a role successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadAllRoles();
            }
            else
            {
                MessageBox.Show("Role insertion failed, please try again", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }    
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            txbRoleName.Clear();
            txbRoleName.Focus();
        }

        private void DgvRoleList_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvRoleList.CurrentRow != null)
            {
                txbRoleName.Text = dgvRoleList.CurrentRow.Cells[1].Value.ToString();
            }
        }

        private void Frm_RolesManagement_Load(object sender, EventArgs e)
        {
            LoadAllRoles();
        }

        public void LoadAllRoles()
        {
            dgvRoleList.DataSource = roleBLL.FindAllRoles();
            dgvRoleList.Font = new Font("Century Gothic", 10, FontStyle.Regular);
        }
    }
}
