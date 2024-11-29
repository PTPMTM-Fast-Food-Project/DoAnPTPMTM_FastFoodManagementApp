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
    public partial class Frm_Authorization : Form
    {
        private RoleBLL roleBLL = new RoleBLL();
        private PermissionBLL permissionBLL = new PermissionBLL();
        private RolePermissionBLL rolePermissionBLL = new RolePermissionBLL();

        public Frm_Authorization()
        {
            InitializeComponent();
            Load += Frm_Authorization_Load;
            btnAuthorize.Click += BtnAuthorize_Click;
            btnUpdate.Click += BtnUpdate_Click;
            btnDelete.Click += BtnDelete_Click;
            dgvAuthorList.SelectionChanged += DgvAuthorList_SelectionChanged;
        }

        private void DgvAuthorList_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvAuthorList.CurrentRow != null)
            {
                string roleName = dgvAuthorList.CurrentRow.Cells[0].Value != null ?
                    dgvAuthorList.CurrentRow.Cells[0].Value.ToString() : "_";
                string permissionName = dgvAuthorList.CurrentRow.Cells[1].Value != null ?
                    dgvAuthorList.CurrentRow.Cells[1].Value.ToString() : "_";

                role r = roleBLL.FindRoleByRoleName(roleName);
                permission p = permissionBLL.FindPermissionByPermissionName(permissionName);

                if (r != null && p != null)
                {
                    cmbRoles.SelectedValue = r.role_id;
                    cmbPermissions.SelectedValue = p.permission_id;
                }

                ckbIsPermit.Checked = dgvAuthorList.CurrentRow.Cells[2].Value != null ?
                    bool.Parse(dgvAuthorList.CurrentRow.Cells[2].Value.ToString()) : false;
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (dgvAuthorList.CurrentRow == null)
            {
                MessageBox.Show("Please select a row to delete", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            long roleId = long.Parse(cmbRoles.SelectedValue.ToString());
            long permissionId = long.Parse(cmbPermissions.SelectedValue.ToString());

            DialogResult res = MessageBox.Show("Are you sure you want to delete this row?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (res == DialogResult.No)
                return;

            if (rolePermissionBLL.DeleteAuthorization(roleId, permissionId))
            {
                MessageBox.Show("Deleted successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDataGridViewRolePermissions();
            }
            else
            {
                MessageBox.Show("Delete failed, please try again", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvAuthorList.CurrentRow == null)
            {
                MessageBox.Show("Please select a row to update", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string roleName = dgvAuthorList.CurrentRow.Cells[0].Value != null ?
                    dgvAuthorList.CurrentRow.Cells[0].Value.ToString() : "_";
            string permissionName = dgvAuthorList.CurrentRow.Cells[1].Value != null ?
                dgvAuthorList.CurrentRow.Cells[1].Value.ToString() : "_";

            role r = roleBLL.FindRoleByRoleName(roleName);
            permission p = permissionBLL.FindPermissionByPermissionName(permissionName);

            long roleId = 0, permissionId = 0;

            if (r != null && p != null)
            {
                roleId = r.role_id;
                permissionId = p.permission_id;
            }
            bool isPermit = ckbIsPermit.Checked;

            if (rolePermissionBLL.UpdateAuthorization(roleId, permissionId, isPermit))
            {
                MessageBox.Show("Updated the IsPermit data field successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDataGridViewRolePermissions();
            }
            else
            {
                MessageBox.Show("Update failed, please try again", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnAuthorize_Click(object sender, EventArgs e)
        {
            if (cmbRoles.SelectedValue == null || cmbPermissions.SelectedValue == null)
            {
                MessageBox.Show("Please select a role and a permission to delegate", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            long roleId = long.Parse(cmbRoles.SelectedValue.ToString());
            long permissionId = long.Parse(cmbPermissions.SelectedValue.ToString());
            bool isPermit = ckbIsPermit.Checked;

            if (rolePermissionBLL.CheckRolePermissionExists(roleId, permissionId))
            {
                MessageBox.Show(cmbRoles.SelectedText.ToString() + "role already has" + cmbPermissions.SelectedText.ToString() + " permission",
                    "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (rolePermissionBLL.HandleAuthorize(roleId, permissionId, isPermit))
            {
                MessageBox.Show("Successful Authorization", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDataGridViewRolePermissions();
            }
            else
            {
                MessageBox.Show("Authorization failed, please try again", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }    
        }

        private void Frm_Authorization_Load(object sender, EventArgs e)
        {
            LoadComboRoles();
            LoadComboPermissions();
            LoadDataGridViewRolePermissions();
        }

        private void LoadComboRoles()
        {
            cmbRoles.DataSource = rolePermissionBLL.LoadAllRoles();
            cmbRoles.DisplayMember = "name";
            cmbRoles.ValueMember = "role_id";
        }

        private void LoadComboPermissions()
        {
            cmbPermissions.DataSource = rolePermissionBLL.LoadAllPermissions();
            cmbPermissions.DisplayMember = "name";
            cmbPermissions.ValueMember = "permission_id";
        }

        private void LoadDataGridViewRolePermissions()
        {
            dgvAuthorList.DataSource = rolePermissionBLL.LoadAllRolesFollowingPermissions();
            dgvAuthorList.Font = new Font("Century Gothic", 10, FontStyle.Regular);
            dgvAuthorList.DefaultCellStyle.ForeColor = Color.Black;
            dgvAuthorList.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 10, FontStyle.Bold);
        }
    }
}
