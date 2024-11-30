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
    public partial class Frm_ProductsManagement : Form
    {
        private ProductsBLL productsBLL = new ProductsBLL();
        private CategoryBLL categoriesBLL = new CategoryBLL();
        public Frm_ProductsManagement()
        {
            InitializeComponent();
            this.Load += Frm_ProductsManagement_Load;
            btnUploadImage.Click += BtnSelectImage_Click;
            dgvProductList.SelectionChanged += DgvProductList_SelectionChanged;
            btnAdd.Click += BtnAdd_Click;
            btnUpdate.Click += BtnUpdate_Click;
            btnDelete.Click += BtnDelete_Click;
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (dgvProductList.CurrentRow != null)
            {
                long productId = Convert.ToInt64(dgvProductList.CurrentRow.Cells[0].Value); 

                bool result = productsBLL.DeleteProduct(productId);

                if (result)
                {
                    MessageBox.Show("Product deleted successfully.");
                    LoadProductList(); 
                }
                else
                {
                    MessageBox.Show("Error deleting product.");
                }
            }
            else
            {
                MessageBox.Show("Please select a product to delete.");
            }
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvProductList.CurrentRow != null)
            {
                // Lấy thông tin sản phẩm từ dòng đã chọn
                long productId = Convert.ToInt64(dgvProductList.CurrentRow.Cells[0].Value); // Lấy product_id từ dòng chọn

                string name = txbProductName.Text;
                double costPrice = Convert.ToDouble(txbCostPrice.Text);
                int quantity = Convert.ToInt32(txbQuantity.Text);
                string description = txbDescription.Text;
                string image = Path.GetFileName(pbProductImage.ImageLocation); // Lấy tên ảnh mà không phải đường dẫn đầy đủ
                double salePrice = Convert.ToDouble(txbSalePrice.Text);
                long? categoryId = (long?)cmbCategory.SelectedValue;
                bool isActivated = chkIsActivated.Checked;

                // Cập nhật sản phẩm
                bool result = productsBLL.UpdateProduct(productId, name, costPrice, quantity, description, image, salePrice, categoryId, isActivated);

                if (result)
                {
                    MessageBox.Show("Product updated successfully.");
                    LoadProductList();
                }
                else
                {
                    MessageBox.Show("Error updating product.");
                }
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            string name = txbProductName.Text;
            double costPrice = Convert.ToDouble(txbCostPrice.Text);
            int quantity = Convert.ToInt32(txbQuantity.Text);
            string description = txbDescription.Text;
            string image = Path.GetFileName(pbProductImage.ImageLocation);
            double salePrice = Convert.ToDouble(txbSalePrice.Text);
            long? categoryId = (long?)cmbCategory.SelectedValue;
            bool isActivated = chkIsActivated.Checked;

            bool result = productsBLL.AddProduct(name, costPrice, quantity, description, image, salePrice, categoryId, isActivated);

            if (result)
            {
                MessageBox.Show("Product added or restored successfully.");
                LoadProductList(); 
            }
            else
            {
                MessageBox.Show("Error adding product.");
            }
        }

        private void DgvProductList_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvProductList.CurrentRow != null)
            {
                txbProductName.Text = dgvProductList.CurrentRow.Cells[0].Value != null ? dgvProductList.CurrentRow.Cells[7].Value.ToString() : string.Empty;
                txbCostPrice.Text = dgvProductList.CurrentRow.Cells[1].Value != null ? dgvProductList.CurrentRow.Cells[1].Value.ToString() : string.Empty;
                txbSalePrice.Text = dgvProductList.CurrentRow.Cells[2].Value != null ? dgvProductList.CurrentRow.Cells[8].Value.ToString() : string.Empty;
                txbQuantity.Text = dgvProductList.CurrentRow.Cells[3].Value != null ? dgvProductList.CurrentRow.Cells[2].Value.ToString() : string.Empty;
                txbDescription.Text = dgvProductList.CurrentRow.Cells[4].Value != null ? dgvProductList.CurrentRow.Cells[3].Value.ToString() : string.Empty;

                string imageName = dgvProductList.CurrentRow.Cells[5].Value != null ? dgvProductList.CurrentRow.Cells[4].Value.ToString() : string.Empty;
                if (!string.IsNullOrEmpty(imageName))
                {
                    string executablePath = AppDomain.CurrentDomain.BaseDirectory;
                    string projectPath = Directory.GetParent(executablePath).Parent.Parent.FullName;
                    string targetFolder = Path.Combine(projectPath, "Resources");
                    string targetPath = Path.Combine(targetFolder, imageName);
                    pbProductImage.Image = Image.FromFile(targetPath);
                }
                else
                {
                    pbProductImage.Image = null;
                }

                string categoryName = dgvProductList.CurrentRow.Cells[6].Value != null ? dgvProductList.CurrentRow.Cells[9].Value.ToString() : "_";
                category c = categoriesBLL.FindRoleByCategoryName(categoryName);
                if (c != null)
                    cmbCategory.SelectedValue = c.category_id;

                bool isActivated = dgvProductList.CurrentRow.Cells[7].Value != null && Convert.ToBoolean(dgvProductList.CurrentRow.Cells[5].Value);
                chkIsActivated.Checked = isActivated;
            }
        }

        private void Frm_ProductsManagement_Load(object sender, EventArgs e)
        {
            LoadComboCategoriees();
            LoadProductList();
        }

        private void LoadProductList()
        {
            try
            {
                var customers = productsBLL.GetAllProducts().ToList();

                dgvProductList.DataSource = customers;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading customers: " + ex.Message);
            }
        }

        private void LoadComboCategoriees()
        {
            cmbCategory.DataSource = categoriesBLL.FindAllCategories();
            cmbCategory.DisplayMember = "name";
            cmbCategory.ValueMember = "category_id";
        }
        private void BtnSelectImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = Path.GetFileName(openFileDialog.FileName); 
                string targetDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources"); 

                if (!Directory.Exists(targetDirectory))
                {
                    Directory.CreateDirectory(targetDirectory);
                }

                string targetPath = Path.Combine(targetDirectory, fileName);

                File.Copy(openFileDialog.FileName, targetPath, true);

                pbProductImage.ImageLocation = targetPath;
            }
        }
    }
}
