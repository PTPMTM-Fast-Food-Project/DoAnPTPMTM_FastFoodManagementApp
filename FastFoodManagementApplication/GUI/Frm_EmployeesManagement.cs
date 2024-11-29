using BLL;
using DTO;
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

namespace GUI
{
    public partial class Frm_EmployeesManagement : Form
    {
        private AdminBLL adminBLL = new AdminBLL();
        private RoleBLL roleBLL = new RoleBLL();
        private PermissionBLL permissionBLL = new PermissionBLL();
        private string loadedImagePath = null;
        public Frm_EmployeesManagement()
        {
            InitializeComponent();
            this.Load += Frm_EmployeesManagement_Load;
            btnAdd.Click += BtnAdd_Click;
            dgvEmpList.SelectionChanged += DgvEmpList_SelectionChanged;
            dgvRoleList.SelectionChanged += DgvRoleList_SelectionChanged;
            dgvPerList.SelectionChanged += DgvPerList_SelectionChanged;
            btnUpdate.Click += BtnUpdate_Click;
            btnDelete.Click += BtnDelete_Click;
            btnResetPassword.Click += BtnResetPassword_Click;
            btnUploadAvatar.Click += BtnUploadAvatar_Click;
            btnAddRole.Click += BtnAddRole_Click;
            btnUpdateRole.Click += BtnUpdateRole_Click;
            btnDeleteRole.Click += BtnDeleteRole_Click;
            btnClear.Click += BtnClear_Click;
            btnAddPermission.Click += BtnAddPermission_Click;
            btnUpdatePermission.Click += BtnUpdatePermission_Click;
            btnDeletePermission.Click += BtnDeletePermission_Click;
            btnClearPerInfo.Click += BtnClearPerInfo_Click;
            btnAuthorize.Click += BtnAuthorize_Click;
        }

        private void BtnAuthorize_Click(object sender, EventArgs e)
        {
            Frm_Authorization f = new Frm_Authorization();
            f.ShowDialog();
        }

        private void BtnClearPerInfo_Click(object sender, EventArgs e)
        {
            txbPerName.Clear();
            txbDescription.Clear();
            txbPerName.Focus();
        }

        private void BtnDeletePermission_Click(object sender, EventArgs e)
        {
            if (dgvPerList.CurrentRow == null)
            {
                MessageBox.Show("Please select a permission to delete", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            permission p = permissionBLL.FindPermissionByPermissionName(txbPerName.Text.Trim());

            DialogResult res = MessageBox.Show("Are you sure you want to delete this permission?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (res == DialogResult.No)
                return;

            if (p != null && permissionBLL.RemovePermissionFromTheRole(p.permission_id) && 
                permissionBLL.DeletePermission(p.permission_id))
            {
                MessageBox.Show("Deleted successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadAllPermissions();
            }
            else
            {
                MessageBox.Show("Delete failed, please try again", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnUpdatePermission_Click(object sender, EventArgs e)
        {
            if (dgvPerList.CurrentRow == null)
            {
                MessageBox.Show("Please select a permission to edit", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string description = txbDescription.Text.Trim();
            permission p = permissionBLL.FindPermissionByPermissionName(txbPerName.Text.Trim());

            if (p != null && permissionBLL.UpdatePermission(p.permission_id, p.name, description))
            {
                MessageBox.Show("Updated successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadAllPermissions();
            }
            else
            {
                MessageBox.Show("Update failed, please try again", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnAddPermission_Click(object sender, EventArgs e)
        {
            string perName = txbPerName.Text.Trim();
            string description = txbDescription.Text.Trim();

            if (perName.Length <= 0)
            {
                MessageBox.Show("Please enter permission name", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (permissionBLL.FindPermissionByPermissionName(perName) != null)
            {
                MessageBox.Show("Permission already exists", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (permissionBLL.InsertPermission(perName, description))
            {
                MessageBox.Show("Insert a permission successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadAllPermissions();
            }
            else
            {
                MessageBox.Show("Permission insertion failed, please try again", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void DgvPerList_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvPerList.CurrentRow != null)
            {
                txbPerName.Text = dgvPerList.CurrentRow.Cells[1].Value != null ? 
                    dgvPerList.CurrentRow.Cells[1].Value.ToString() : string.Empty;
                txbDescription.Text = dgvPerList.CurrentRow.Cells[2].Value != null ?
                    dgvPerList.CurrentRow.Cells[2].Value.ToString() : string.Empty;
            }
        }

        private void BtnResetPassword_Click(object sender, EventArgs e)
        {
            if (dgvEmpList.CurrentRow == null)
            {
                MessageBox.Show("Please select a user to reset user's password", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            object usernameObject = dgvEmpList.CurrentRow.Cells[2].Value;
            Frm_ForgotPassword f = new Frm_ForgotPassword();
            f.SetUsername(usernameObject != null ? usernameObject.ToString() : string.Empty);
            f.ShowDialog();
        }

        private void DgvRoleList_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvRoleList.CurrentRow != null)
            {
                txbRoleName.Text = dgvRoleList.CurrentRow.Cells[1].Value != null ?
                    dgvRoleList.CurrentRow.Cells[1].Value.ToString() : string.Empty; ;
            }
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            txbRoleName.Clear();
            txbRoleName.Focus();
        }

        private void BtnDeleteRole_Click(object sender, EventArgs e)
        {
            if(dgvRoleList.CurrentRow == null)
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

        private void BtnUpdateRole_Click(object sender, EventArgs e)
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

        private void BtnAddRole_Click(object sender, EventArgs e)
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

        private void BtnUploadAvatar_Click(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
                    openFileDialog.Title = "Select an Image";

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        loadedImagePath = openFileDialog.FileName;

                        // Load the selected image into the PictureBox
                        pbAvatar.Image = Image.FromFile(loadedImagePath);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading image: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private bool SaveImageToResources()
        {
            if (string.IsNullOrEmpty(loadedImagePath))
            { 
                return true;
            }

            try
            {
                // Đường dẫn gốc nơi file thực thi đang chạy
                string executablePath = AppDomain.CurrentDomain.BaseDirectory;

                // Đi lùi lên 2 cấp để về thư mục gốc của project (nơi chứa thư mục "Images")
                string projectPath = Directory.GetParent(executablePath).Parent.Parent.FullName;

                // Thư mục đích để lưu file
                string targetFolder = Path.Combine(projectPath, "Resources\\Avatar");

                // Tạo thư mục đích nếu chưa tồn tại
                if (!Directory.Exists(targetFolder))
                {
                    Directory.CreateDirectory(targetFolder);
                }

                // Đường dẫn file đích (lưu theo tên file gốc)
                string targetPath = Path.Combine(targetFolder, Path.GetFileName(loadedImagePath));

                // Sao chép file vào thư mục đích
                File.Copy(loadedImagePath, targetPath, overwrite: true);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error while saving image: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (dgvEmpList.CurrentRow == null)
            {
                MessageBox.Show("Please select a user to delete", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string username = txbUsername.Text.Trim();

            DialogResult res = MessageBox.Show("Are you sure you want to delete this user?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (res == DialogResult.No)
                return;

            if (adminBLL.RevokeUserPermissions(username) && adminBLL.DeleteAdmin(username))
            {
                MessageBox.Show("Deleted successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadUsersWithRoleIsNotAdmin();
            }
            else
            {
                MessageBox.Show("Delete failed, please try again", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvEmpList.CurrentRow == null)
            {
                MessageBox.Show("Please select a user to edit", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string username = txbUsername.Text.Trim();
            string firstName = txbFirstName.Text.Trim();
            string lastName = txbLastName.Text.Trim();
            string image = (loadedImagePath != null ? Path.GetFileName(loadedImagePath) : string.Empty);
            long role_id = long.Parse(cmbRoles.SelectedValue != null ? cmbRoles.SelectedValue.ToString() : string.Empty);

            if (adminBLL.UpdateAdmin(username, firstName, lastName, image) && 
                adminBLL.UpdateUserAuthorization(username, role_id) && SaveImageToResources())
            {
                MessageBox.Show("Updated successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadUsersWithRoleIsNotAdmin();
            }
            else
            {
                MessageBox.Show("Update failed, please try again", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } 
        }

        private void DgvEmpList_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvEmpList.CurrentRow != null)
            {
                txbFirstName.Text = dgvEmpList.CurrentRow.Cells[0].Value != null ? dgvEmpList.CurrentRow.Cells[0].Value.ToString() : string.Empty;
                txbLastName.Text = dgvEmpList.CurrentRow.Cells[1].Value != null ? dgvEmpList.CurrentRow.Cells[1].Value.ToString() : string.Empty;
                txbUsername.Text = dgvEmpList.CurrentRow.Cells[2].Value != null ? dgvEmpList.CurrentRow.Cells[2].Value.ToString() : string.Empty;
                string avatarName = dgvEmpList.CurrentRow.Cells[3].Value != null ? dgvEmpList.CurrentRow.Cells[3].Value.ToString() : string.Empty;
                if (!string.IsNullOrEmpty(avatarName))
                {
                    string executablePath = AppDomain.CurrentDomain.BaseDirectory;
                    string projectPath = Directory.GetParent(executablePath).Parent.Parent.FullName;
                    string targetFolder = Path.Combine(projectPath, "Resources\\Avatar");
                    string targetPath = Path.Combine(targetFolder, avatarName);
                    pbAvatar.Image = Image.FromFile(targetPath);
                }
                else
                {
                    pbAvatar.Image = null;
                }    
                string roleName = dgvEmpList.CurrentRow.Cells[4].Value != null ? dgvEmpList.CurrentRow.Cells[4].Value.ToString() : "_";
                role r = roleBLL.FindRoleByRoleName(roleName);
                if (r != null)
                    cmbRoles.SelectedValue = r.role_id;
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            Frm_AddAUser addAUser = new Frm_AddAUser();
            addAUser.ShowDialog();
        }

        private void Frm_EmployeesManagement_Load(object sender, EventArgs e)
        {
            LoadUsersWithRoleIsNotAdmin();
            LoadComboRoles();
            LoadAllRoles();
            LoadAllPermissions();
            txbUsername.Enabled = false;
        }

        private void LoadUsersWithRoleIsNotAdmin()
        {
            dgvEmpList.DataSource = adminBLL.FindAllUsersByRoleNameIsNotAdmin();
            dgvEmpList.Font = new Font("Century Gothic", 10, FontStyle.Regular);
            dgvEmpList.DefaultCellStyle.ForeColor = Color.Black;
        }

        private void LoadComboRoles()
        {
            cmbRoles.DataSource = roleBLL.FindAllRoles();
            cmbRoles.DisplayMember = "name";
            cmbRoles.ValueMember = "role_id";
        }

        public void LoadAllRoles()
        {
            dgvRoleList.DataSource = roleBLL.FindAllRoles();
            dgvRoleList.Font = new Font("Century Gothic", 10, FontStyle.Regular);
            dgvRoleList.DefaultCellStyle.ForeColor = Color.Black;
        }

        public void LoadAllPermissions()
        {
            dgvPerList.DataSource = permissionBLL.LoadAllPermissions();
            dgvPerList.Font = new Font("Century Gothic", 10, FontStyle.Regular);
            dgvPerList.DefaultCellStyle.ForeColor = Color.Black;
        }
    }
}
