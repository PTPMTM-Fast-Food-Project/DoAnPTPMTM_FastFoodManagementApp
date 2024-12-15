namespace GUI
{
    partial class Frm_EmployeesManagement
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dgvEmpList = new System.Windows.Forms.DataGridView();
            this.cmbRoles = new System.Windows.Forms.ComboBox();
            this.btnResetPassword = new System.Windows.Forms.Button();
            this.btnUploadAvatar = new System.Windows.Forms.Button();
            this.txbFirstName = new System.Windows.Forms.TextBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.pbAvatar = new System.Windows.Forms.PictureBox();
            this.txbLastName = new System.Windows.Forms.TextBox();
            this.txbUsername = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnDeleteRole = new System.Windows.Forms.Button();
            this.btnUpdateRole = new System.Windows.Forms.Button();
            this.btnAddRole = new System.Windows.Forms.Button();
            this.dgvRoleList = new System.Windows.Forms.DataGridView();
            this.txbRoleName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.btnAuthorize = new System.Windows.Forms.Button();
            this.txbDescription = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnClearPerInfo = new System.Windows.Forms.Button();
            this.btnDeletePermission = new System.Windows.Forms.Button();
            this.btnUpdatePermission = new System.Windows.Forms.Button();
            this.btnAddPermission = new System.Windows.Forms.Button();
            this.dgvPerList = new System.Windows.Forms.DataGridView();
            this.txbPerName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmpList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAvatar)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRoleList)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPerList)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1511, 845);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(39)))), ((int)(((byte)(40)))));
            this.tabPage1.Controls.Add(this.dgvEmpList);
            this.tabPage1.Controls.Add(this.cmbRoles);
            this.tabPage1.Controls.Add(this.btnResetPassword);
            this.tabPage1.Controls.Add(this.btnUploadAvatar);
            this.tabPage1.Controls.Add(this.txbFirstName);
            this.tabPage1.Controls.Add(this.btnDelete);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.btnUpdate);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.btnAdd);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.pbAvatar);
            this.tabPage1.Controls.Add(this.txbLastName);
            this.tabPage1.Controls.Add(this.txbUsername);
            this.tabPage1.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage1.Location = new System.Drawing.Point(4, 27);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage1.Size = new System.Drawing.Size(1503, 814);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Employees Management";
            // 
            // dgvEmpList
            // 
            this.dgvEmpList.AllowUserToAddRows = false;
            this.dgvEmpList.AllowUserToDeleteRows = false;
            this.dgvEmpList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle17.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle17.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle17.ForeColor = System.Drawing.Color.Gold;
            dataGridViewCellStyle17.SelectionBackColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle17.SelectionForeColor = System.Drawing.Color.Gold;
            dataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvEmpList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle17;
            this.dgvEmpList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle18.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle18.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle18.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle18.SelectionBackColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle18.SelectionForeColor = System.Drawing.Color.Gold;
            dataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvEmpList.DefaultCellStyle = dataGridViewCellStyle18;
            this.dgvEmpList.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvEmpList.Location = new System.Drawing.Point(4, 553);
            this.dgvEmpList.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvEmpList.Name = "dgvEmpList";
            this.dgvEmpList.ReadOnly = true;
            this.dgvEmpList.RowHeadersWidth = 51;
            this.dgvEmpList.RowTemplate.Height = 24;
            this.dgvEmpList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEmpList.Size = new System.Drawing.Size(1495, 257);
            this.dgvEmpList.TabIndex = 33;
            // 
            // cmbRoles
            // 
            this.cmbRoles.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbRoles.FormattingEnabled = true;
            this.cmbRoles.Location = new System.Drawing.Point(144, 228);
            this.cmbRoles.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbRoles.Name = "cmbRoles";
            this.cmbRoles.Size = new System.Drawing.Size(255, 27);
            this.cmbRoles.TabIndex = 20;
            // 
            // btnResetPassword
            // 
            this.btnResetPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(8)))), ((int)(((byte)(55)))));
            this.btnResetPassword.FlatAppearance.BorderSize = 0;
            this.btnResetPassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnResetPassword.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResetPassword.Location = new System.Drawing.Point(920, 147);
            this.btnResetPassword.Margin = new System.Windows.Forms.Padding(4);
            this.btnResetPassword.Name = "btnResetPassword";
            this.btnResetPassword.Size = new System.Drawing.Size(203, 44);
            this.btnResetPassword.TabIndex = 32;
            this.btnResetPassword.Text = "Reset Password";
            this.btnResetPassword.UseVisualStyleBackColor = false;
            // 
            // btnUploadAvatar
            // 
            this.btnUploadAvatar.BackColor = System.Drawing.Color.Gold;
            this.btnUploadAvatar.FlatAppearance.BorderSize = 0;
            this.btnUploadAvatar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUploadAvatar.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUploadAvatar.ForeColor = System.Drawing.Color.Black;
            this.btnUploadAvatar.Location = new System.Drawing.Point(455, 220);
            this.btnUploadAvatar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnUploadAvatar.Name = "btnUploadAvatar";
            this.btnUploadAvatar.Size = new System.Drawing.Size(163, 38);
            this.btnUploadAvatar.TabIndex = 17;
            this.btnUploadAvatar.Text = "Choose avatar";
            this.btnUploadAvatar.UseVisualStyleBackColor = false;
            // 
            // txbFirstName
            // 
            this.txbFirstName.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbFirstName.Location = new System.Drawing.Point(144, 49);
            this.txbFirstName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txbFirstName.Name = "txbFirstName";
            this.txbFirstName.Size = new System.Drawing.Size(255, 28);
            this.txbFirstName.TabIndex = 26;
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(8)))), ((int)(((byte)(55)))));
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(920, 72);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(203, 44);
            this.btnDelete.TabIndex = 33;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(29, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 19);
            this.label1.TabIndex = 22;
            this.label1.Text = "First name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(29, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 19);
            this.label2.TabIndex = 23;
            this.label2.Text = "Last name:";
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(8)))), ((int)(((byte)(55)))));
            this.btnUpdate.FlatAppearance.BorderSize = 0;
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.Location = new System.Drawing.Point(684, 147);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(203, 44);
            this.btnUpdate.TabIndex = 31;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(29, 172);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 19);
            this.label3.TabIndex = 24;
            this.label3.Text = "Username:";
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(8)))), ((int)(((byte)(55)))));
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(684, 72);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(203, 44);
            this.btnAdd.TabIndex = 30;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(29, 236);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 19);
            this.label4.TabIndex = 25;
            this.label4.Text = "Role:";
            // 
            // pbAvatar
            // 
            this.pbAvatar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbAvatar.Location = new System.Drawing.Point(430, 49);
            this.pbAvatar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pbAvatar.Name = "pbAvatar";
            this.pbAvatar.Size = new System.Drawing.Size(217, 157);
            this.pbAvatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbAvatar.TabIndex = 29;
            this.pbAvatar.TabStop = false;
            // 
            // txbLastName
            // 
            this.txbLastName.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbLastName.Location = new System.Drawing.Point(144, 112);
            this.txbLastName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txbLastName.Name = "txbLastName";
            this.txbLastName.Size = new System.Drawing.Size(255, 28);
            this.txbLastName.TabIndex = 27;
            // 
            // txbUsername
            // 
            this.txbUsername.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbUsername.Location = new System.Drawing.Point(144, 172);
            this.txbUsername.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txbUsername.Name = "txbUsername";
            this.txbUsername.Size = new System.Drawing.Size(255, 28);
            this.txbUsername.TabIndex = 28;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(39)))), ((int)(((byte)(40)))));
            this.tabPage2.Controls.Add(this.btnClear);
            this.tabPage2.Controls.Add(this.btnDeleteRole);
            this.tabPage2.Controls.Add(this.btnUpdateRole);
            this.tabPage2.Controls.Add(this.btnAddRole);
            this.tabPage2.Controls.Add(this.dgvRoleList);
            this.tabPage2.Controls.Add(this.txbRoleName);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Location = new System.Drawing.Point(4, 27);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage2.Size = new System.Drawing.Size(1503, 814);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Roles Management";
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(8)))), ((int)(((byte)(55)))));
            this.btnClear.FlatAppearance.BorderSize = 0;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.Location = new System.Drawing.Point(970, 88);
            this.btnClear.Margin = new System.Windows.Forms.Padding(4);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(155, 44);
            this.btnClear.TabIndex = 27;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            // 
            // btnDeleteRole
            // 
            this.btnDeleteRole.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(8)))), ((int)(((byte)(55)))));
            this.btnDeleteRole.FlatAppearance.BorderSize = 0;
            this.btnDeleteRole.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteRole.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteRole.ForeColor = System.Drawing.Color.White;
            this.btnDeleteRole.Location = new System.Drawing.Point(807, 88);
            this.btnDeleteRole.Margin = new System.Windows.Forms.Padding(4);
            this.btnDeleteRole.Name = "btnDeleteRole";
            this.btnDeleteRole.Size = new System.Drawing.Size(155, 44);
            this.btnDeleteRole.TabIndex = 26;
            this.btnDeleteRole.Text = "Delete";
            this.btnDeleteRole.UseVisualStyleBackColor = false;
            // 
            // btnUpdateRole
            // 
            this.btnUpdateRole.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(8)))), ((int)(((byte)(55)))));
            this.btnUpdateRole.FlatAppearance.BorderSize = 0;
            this.btnUpdateRole.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdateRole.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateRole.ForeColor = System.Drawing.Color.White;
            this.btnUpdateRole.Location = new System.Drawing.Point(644, 88);
            this.btnUpdateRole.Margin = new System.Windows.Forms.Padding(4);
            this.btnUpdateRole.Name = "btnUpdateRole";
            this.btnUpdateRole.Size = new System.Drawing.Size(155, 44);
            this.btnUpdateRole.TabIndex = 25;
            this.btnUpdateRole.Text = "Update";
            this.btnUpdateRole.UseVisualStyleBackColor = false;
            // 
            // btnAddRole
            // 
            this.btnAddRole.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(8)))), ((int)(((byte)(55)))));
            this.btnAddRole.FlatAppearance.BorderSize = 0;
            this.btnAddRole.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddRole.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddRole.ForeColor = System.Drawing.Color.White;
            this.btnAddRole.Location = new System.Drawing.Point(482, 88);
            this.btnAddRole.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddRole.Name = "btnAddRole";
            this.btnAddRole.Size = new System.Drawing.Size(155, 44);
            this.btnAddRole.TabIndex = 24;
            this.btnAddRole.Text = "Add";
            this.btnAddRole.UseVisualStyleBackColor = false;
            // 
            // dgvRoleList
            // 
            this.dgvRoleList.AllowUserToAddRows = false;
            this.dgvRoleList.AllowUserToDeleteRows = false;
            this.dgvRoleList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRoleList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRoleList.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvRoleList.Location = new System.Drawing.Point(4, 441);
            this.dgvRoleList.Margin = new System.Windows.Forms.Padding(4);
            this.dgvRoleList.Name = "dgvRoleList";
            this.dgvRoleList.ReadOnly = true;
            this.dgvRoleList.RowHeadersWidth = 51;
            this.dgvRoleList.RowTemplate.Height = 24;
            this.dgvRoleList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRoleList.Size = new System.Drawing.Size(1495, 369);
            this.dgvRoleList.TabIndex = 23;
            // 
            // txbRoleName
            // 
            this.txbRoleName.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbRoleName.Location = new System.Drawing.Point(144, 95);
            this.txbRoleName.Margin = new System.Windows.Forms.Padding(4);
            this.txbRoleName.Name = "txbRoleName";
            this.txbRoleName.Size = new System.Drawing.Size(284, 28);
            this.txbRoleName.TabIndex = 22;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(17, 95);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(103, 19);
            this.label5.TabIndex = 21;
            this.label5.Text = "Role name:";
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(39)))), ((int)(((byte)(40)))));
            this.tabPage3.Controls.Add(this.btnAuthorize);
            this.tabPage3.Controls.Add(this.txbDescription);
            this.tabPage3.Controls.Add(this.label7);
            this.tabPage3.Controls.Add(this.btnClearPerInfo);
            this.tabPage3.Controls.Add(this.btnDeletePermission);
            this.tabPage3.Controls.Add(this.btnUpdatePermission);
            this.tabPage3.Controls.Add(this.btnAddPermission);
            this.tabPage3.Controls.Add(this.dgvPerList);
            this.tabPage3.Controls.Add(this.txbPerName);
            this.tabPage3.Controls.Add(this.label6);
            this.tabPage3.Location = new System.Drawing.Point(4, 27);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(1503, 814);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Permissions Management";
            // 
            // btnAuthorize
            // 
            this.btnAuthorize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(8)))), ((int)(((byte)(55)))));
            this.btnAuthorize.FlatAppearance.BorderSize = 0;
            this.btnAuthorize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAuthorize.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAuthorize.ForeColor = System.Drawing.Color.White;
            this.btnAuthorize.Location = new System.Drawing.Point(745, 181);
            this.btnAuthorize.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAuthorize.Name = "btnAuthorize";
            this.btnAuthorize.Size = new System.Drawing.Size(347, 44);
            this.btnAuthorize.TabIndex = 38;
            this.btnAuthorize.Text = "Authorization";
            this.btnAuthorize.UseVisualStyleBackColor = false;
            // 
            // txbDescription
            // 
            this.txbDescription.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbDescription.Location = new System.Drawing.Point(197, 84);
            this.txbDescription.Margin = new System.Windows.Forms.Padding(4);
            this.txbDescription.Multiline = true;
            this.txbDescription.Name = "txbDescription";
            this.txbDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txbDescription.Size = new System.Drawing.Size(496, 141);
            this.txbDescription.TabIndex = 36;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(19, 88);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(105, 19);
            this.label7.TabIndex = 35;
            this.label7.Text = "Description:";
            // 
            // btnClearPerInfo
            // 
            this.btnClearPerInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(8)))), ((int)(((byte)(55)))));
            this.btnClearPerInfo.FlatAppearance.BorderSize = 0;
            this.btnClearPerInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearPerInfo.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearPerInfo.ForeColor = System.Drawing.Color.White;
            this.btnClearPerInfo.Location = new System.Drawing.Point(937, 101);
            this.btnClearPerInfo.Margin = new System.Windows.Forms.Padding(4);
            this.btnClearPerInfo.Name = "btnClearPerInfo";
            this.btnClearPerInfo.Size = new System.Drawing.Size(155, 44);
            this.btnClearPerInfo.TabIndex = 34;
            this.btnClearPerInfo.Text = "Clear";
            this.btnClearPerInfo.UseVisualStyleBackColor = false;
            // 
            // btnDeletePermission
            // 
            this.btnDeletePermission.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(8)))), ((int)(((byte)(55)))));
            this.btnDeletePermission.FlatAppearance.BorderSize = 0;
            this.btnDeletePermission.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeletePermission.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeletePermission.ForeColor = System.Drawing.Color.White;
            this.btnDeletePermission.Location = new System.Drawing.Point(745, 101);
            this.btnDeletePermission.Margin = new System.Windows.Forms.Padding(4);
            this.btnDeletePermission.Name = "btnDeletePermission";
            this.btnDeletePermission.Size = new System.Drawing.Size(155, 44);
            this.btnDeletePermission.TabIndex = 33;
            this.btnDeletePermission.Text = "Delete";
            this.btnDeletePermission.UseVisualStyleBackColor = false;
            // 
            // btnUpdatePermission
            // 
            this.btnUpdatePermission.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(8)))), ((int)(((byte)(55)))));
            this.btnUpdatePermission.FlatAppearance.BorderSize = 0;
            this.btnUpdatePermission.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdatePermission.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdatePermission.ForeColor = System.Drawing.Color.White;
            this.btnUpdatePermission.Location = new System.Drawing.Point(937, 23);
            this.btnUpdatePermission.Margin = new System.Windows.Forms.Padding(4);
            this.btnUpdatePermission.Name = "btnUpdatePermission";
            this.btnUpdatePermission.Size = new System.Drawing.Size(155, 44);
            this.btnUpdatePermission.TabIndex = 32;
            this.btnUpdatePermission.Text = "Update";
            this.btnUpdatePermission.UseVisualStyleBackColor = false;
            // 
            // btnAddPermission
            // 
            this.btnAddPermission.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(8)))), ((int)(((byte)(55)))));
            this.btnAddPermission.FlatAppearance.BorderSize = 0;
            this.btnAddPermission.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddPermission.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddPermission.ForeColor = System.Drawing.Color.White;
            this.btnAddPermission.Location = new System.Drawing.Point(745, 23);
            this.btnAddPermission.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddPermission.Name = "btnAddPermission";
            this.btnAddPermission.Size = new System.Drawing.Size(155, 44);
            this.btnAddPermission.TabIndex = 31;
            this.btnAddPermission.Text = "Add";
            this.btnAddPermission.UseVisualStyleBackColor = false;
            // 
            // dgvPerList
            // 
            this.dgvPerList.AllowUserToAddRows = false;
            this.dgvPerList.AllowUserToDeleteRows = false;
            this.dgvPerList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPerList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPerList.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvPerList.Location = new System.Drawing.Point(0, 493);
            this.dgvPerList.Margin = new System.Windows.Forms.Padding(4);
            this.dgvPerList.Name = "dgvPerList";
            this.dgvPerList.ReadOnly = true;
            this.dgvPerList.RowHeadersWidth = 51;
            this.dgvPerList.RowTemplate.Height = 24;
            this.dgvPerList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPerList.Size = new System.Drawing.Size(1503, 321);
            this.dgvPerList.TabIndex = 30;
            // 
            // txbPerName
            // 
            this.txbPerName.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbPerName.Location = new System.Drawing.Point(197, 24);
            this.txbPerName.Margin = new System.Windows.Forms.Padding(4);
            this.txbPerName.Name = "txbPerName";
            this.txbPerName.Size = new System.Drawing.Size(496, 28);
            this.txbPerName.TabIndex = 29;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(19, 27);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(154, 19);
            this.label6.TabIndex = 28;
            this.label6.Text = "Permission name:";
            // 
            // Frm_EmployeesManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(39)))), ((int)(((byte)(40)))));
            this.ClientSize = new System.Drawing.Size(1511, 845);
            this.Controls.Add(this.tabControl1);
            this.ForeColor = System.Drawing.Color.White;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Frm_EmployeesManagement";
            this.Text = "Frm_EmployeesManagement";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmpList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAvatar)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRoleList)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPerList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ComboBox cmbRoles;
        private System.Windows.Forms.Button btnUploadAvatar;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnResetPassword;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.PictureBox pbAvatar;
        private System.Windows.Forms.TextBox txbUsername;
        private System.Windows.Forms.TextBox txbLastName;
        private System.Windows.Forms.TextBox txbFirstName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnDeleteRole;
        private System.Windows.Forms.Button btnUpdateRole;
        private System.Windows.Forms.Button btnAddRole;
        private System.Windows.Forms.DataGridView dgvRoleList;
        private System.Windows.Forms.TextBox txbRoleName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TextBox txbDescription;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnClearPerInfo;
        private System.Windows.Forms.Button btnDeletePermission;
        private System.Windows.Forms.Button btnUpdatePermission;
        private System.Windows.Forms.Button btnAddPermission;
        private System.Windows.Forms.DataGridView dgvPerList;
        private System.Windows.Forms.TextBox txbPerName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dgvEmpList;
        private System.Windows.Forms.Button btnAuthorize;
    }
}