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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GUI
{
    public partial class Frm_OrderDetail : Form
    {
        OrderBLL orderBLL = new OrderBLL();
        public Frm_OrderDetail(int id)
        {
            InitializeComponent();
            LoadOrderDetails(id);
            buttonPrint.Click += buttonPrint_Click;
        }
        private void LoadOrderDetails(int id)
        {
            try
            {
                var customer = orderBLL.GetCustomerByOrderId(id);

                if (customer != null)
                {
                    textBox1.Text = id.ToString();
                    txtCustomerId.Text = customer.customer_id.ToString();
                    txtFirstName.Text = customer.first_name;
                    txtLastName.Text = customer.last_name;
                    txtAdd.Text = customer.address;
                    txtPhone.Text = customer.phone_number;
                }
                else
                {
                    MessageBox.Show("Customer not found for the given order ID.");
                    return; // Exit if customer not found
                }

                var orderDetails = orderBLL.GetOrderDetailByOrderId(id).ToList();
                dataGridView1.DataSource = orderDetails;

                // Set column headers
                dataGridView1.Columns["order_detail_id"].HeaderText = "Order Detail ID";
                dataGridView1.Columns["product_id"].HeaderText = "Product ID";
                dataGridView1.Columns["name"].HeaderText = "Product Name";
                dataGridView1.Columns["cost_price"].HeaderText = "Product Price";
                dataGridView1.Columns["CategoryName"].HeaderText = "Category Name";
                dataGridView1.Columns["quantity"].HeaderText = "Quantity";
                dataGridView1.Columns["price"].HeaderText = "Price";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading orders: " + ex.Message);
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonPrint_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBox1.Text, out int orderId))
            {
                Frm_Bill bill = new Frm_Bill(orderId);
                bill.Show();
            }
            else
            {
                MessageBox.Show("ID không hợp lệ");
            }
        }
    }
}
