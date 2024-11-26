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
        private string loadedImagePath = null;
        public Frm_EmployeesManagement()
        {
            InitializeComponent();
            this.Load += Frm_EmployeesManagement_Load;
            btnAdd.Click += BtnAdd_Click;
            dgvEmpList.SelectionChanged += DgvEmpList_SelectionChanged;
            btnUpdate.Click += BtnUpdate_Click;
            btnDelete.Click += BtnDelete_Click;
            btnUploadAvatar.Click += BtnUploadAvatar_Click;
            btnRolesMana.Click += BtnRolesMana_Click;
        }

        private void BtnRolesMana_Click(object sender, EventArgs e)
        {
            Frm_RolesManagement rolesMana = new Frm_RolesManagement();
            rolesMana.ShowDialog();
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
    }
}
