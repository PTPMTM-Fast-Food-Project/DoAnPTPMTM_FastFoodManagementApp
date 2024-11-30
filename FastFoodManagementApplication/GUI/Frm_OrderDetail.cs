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
    public partial class Frm_OrderDetail : Form
    {
        OrderBLL orderBLL = new OrderBLL();
        public Frm_OrderDetail(int id)
        {
            InitializeComponent();
            LoadOrderDetails(id);
        }
        private void LoadOrderDetails(int id)
        {
            try
            {
                textBox1.Text = id.ToString();

                dataGridView1.DataSource = orderBLL.GetOrderDetailByOrderId(id).ToList();

                dataGridView1.Columns["order_detail_id"].HeaderText = "Order Detail ID";
                dataGridView1.Columns["product_id"].HeaderText = "Product ID";
                dataGridView1.Columns["name"].HeaderText = "Product Name";
                dataGridView1.Columns["cost_price"].HeaderText = "Product Price";
                dataGridView1.Columns["CategoryName"].HeaderText = "Category Name";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading orders: " + ex.Message);
            }
        }
    }
}
