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
    public partial class Frm_ProductsManagement : Form
    {
        private ProductsBLL productsBLL = new ProductsBLL();
        public Frm_ProductsManagement()
        {
            InitializeComponent();
            this.Load += Frm_ProductsManagement_Load;
            btnUploadImage.Click += BtnSelectImage_Click;
        }

        private void Frm_ProductsManagement_Load(object sender, EventArgs e)
        {
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
        private void BtnSelectImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pbProductImage.ImageLocation = openFileDialog.FileName;
            }
        }
    }
}
