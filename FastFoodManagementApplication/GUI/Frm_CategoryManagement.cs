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
    public partial class Frm_CategoryManagement : Form
    {
        private CategoryBLL categoriesBLL = new CategoryBLL();
        public Frm_CategoryManagement()
        {
            InitializeComponent();
            this.Load += Frm_CategoryManagement_Load;
            btnAdd.Click += BtnAdd_Click;
            dgvCategoryList.SelectionChanged += DgvCategoryList_SelectionChanged;
            btnUpdate.Click += BtnUpdate_Click;
            btnDelete.Click += BtnDelete_Click;
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvCategoryList.CurrentRow != null)
                {
                    long categoryId = Convert.ToInt64(dgvCategoryList.CurrentRow.Cells[0].Value);

                    var confirmResult = MessageBox.Show("Are you sure to delete this category?", "Confirm Delete", MessageBoxButtons.YesNo);
                    if (confirmResult == DialogResult.Yes)
                    {
                        bool result = categoriesBLL.DeleteCategory(categoryId);
                        if (result)
                        {
                            MessageBox.Show("Category deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadCategoryList(); 
                        }
                        else
                        {
                            MessageBox.Show("Failed to delete category. It may be associated with existing products.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvCategoryList.CurrentRow != null)
                {
                    long categoryId = Convert.ToInt64(dgvCategoryList.CurrentRow.Cells[0].Value);
                    string name = txtCategoryName.Text.Trim();
                    bool isActivated = chkIsActivated.Checked;

                    if (string.IsNullOrEmpty(name))
                    {
                        MessageBox.Show("Category name cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    bool result = categoriesBLL.UpdateCategory(categoryId, name, isActivated);
                    if (result)
                    {
                        MessageBox.Show("Category updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadCategoryList(); 
                    }
                    else
                    {
                        MessageBox.Show("Failed to update category.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DgvCategoryList_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvCategoryList.CurrentRow != null)
                {
                    txtCategoryName.Text = dgvCategoryList.CurrentRow.Cells[0].Value != null
                        ? dgvCategoryList.CurrentRow.Cells[3].Value.ToString()
                        : string.Empty;

                    if (dgvCategoryList.CurrentRow.Cells[1].Value != null)
                    {
                        chkIsActivated.Checked = Convert.ToBoolean(dgvCategoryList.CurrentRow.Cells[1].Value);
                    }
                    else
                    {
                        chkIsActivated.Checked = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error during selection change: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            string name = txtCategoryName.Text.Trim();
            bool isActivated = chkIsActivated.Checked; 

            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Category name cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                bool result = categoriesBLL.AddNewCategory(name, isActivated);
                if (result)
                {
                    MessageBox.Show("Category added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadCategoryList(); 
                }
                else
                {
                    MessageBox.Show("Failed to add category.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Frm_CategoryManagement_Load(object sender, EventArgs e)
        {
            LoadCategoryList();
        }

        private void LoadCategoryList()
        {
            try
            {
                var customers = categoriesBLL.GetAllCategories().ToList();

                dgvCategoryList.DataSource = customers;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading customers: " + ex.Message);
            }
        }
    }
}
