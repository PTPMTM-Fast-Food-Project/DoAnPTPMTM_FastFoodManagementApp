using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using DTO;

namespace GUI
{
    public partial class Frm_OrdersManagement : Form
    {
        OrderBLL orderBLL = new OrderBLL();
        public Frm_OrdersManagement()
        {
            InitializeComponent();
            LoadComboBoxes();
            LoadOrders();

            dataGridView1.SelectionChanged += dataGridView1_SelectionChanged;
            buttonDetails.Click += buttonDetails_Click;
            buttonUpdate.Click += buttonUpdate_Click;
        }

        private void LoadComboBoxes()
        {
            comboBoxIsAccept.Items.Add("True");
            comboBoxIsAccept.Items.Add("False");

            comboBoxStatus.Items.Add("PENDING");
            comboBoxStatus.Items.Add("SHIPPING");
            comboBoxStatus.Items.Add("COMPLETE");
        }

        private void LoadOrders()
        {
            try
            {
                // Lấy danh sách đơn hàng
                List<OrderDTO> orders = orderBLL.GetAllOrders();

                // Gán danh sách đơn hàng cho DataGridView
                dataGridView1.DataSource = orders;

                dataGridView1.Columns["order_id"].HeaderText = "Order ID";
                dataGridView1.Columns["delivery_date"].HeaderText = "Delivery Date";
                dataGridView1.Columns["is_accept"].HeaderText = "Is Accepted";
                dataGridView1.Columns["order_date"].HeaderText = "Order Date";
                dataGridView1.Columns["order_status"].HeaderText = "Order Status";
                dataGridView1.Columns["payment_method"].HeaderText = "Payment Method";
                dataGridView1.Columns["quantity"].HeaderText = "Quantity";
                dataGridView1.Columns["tax"].HeaderText = "Tax";
                dataGridView1.Columns["total_price"].HeaderText = "Total Price";
                dataGridView1.Columns["customer_id"].HeaderText = "Customer ID";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading orders: " + ex.Message);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBoxId.Text = e.RowIndex.ToString();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                textBoxId.Text = dataGridView1.CurrentRow.Cells["order_id"].Value.ToString();
                textBoxDeliveryDate.Text = dataGridView1.CurrentRow.Cells["delivery_date"].Value != null ? dataGridView1.CurrentRow.Cells["delivery_date"].Value.ToString() : string.Empty;
                comboBoxIsAccept.SelectedItem = dataGridView1.CurrentRow.Cells["is_accept"].Value.ToString();
                textBoxOrderDate.Text = dataGridView1.CurrentRow.Cells["order_date"].Value.ToString();
                comboBoxStatus.Text = dataGridView1.CurrentRow.Cells["order_status"].Value.ToString();
                textBoxPayment.Text = dataGridView1.CurrentRow.Cells["payment_method"].Value.ToString();
                textBoxQuantity.Text = dataGridView1.CurrentRow.Cells["quantity"].Value.ToString();
                textBoxTax.Text = dataGridView1.CurrentRow.Cells["tax"].Value.ToString();
                textBoxTotalPrice.Text = dataGridView1.CurrentRow.Cells["total_price"].Value.ToString();
                textBoxCustomer.Text = dataGridView1.CurrentRow.Cells["customer_id"].Value.ToString();
            }
        }

        private void buttonDetails_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBoxId.Text, out int orderId))
            {
                Frm_OrderDetail orderDetailForm = new Frm_OrderDetail(orderId);
                orderDetailForm.Show();
            }
            else
            {
                MessageBox.Show("ID không hợp lệ");
            }
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBoxId.Text, out int id))
            {
                bool isAccept = comboBoxIsAccept.SelectedItem.ToString() == "True";
                string status = comboBoxStatus.SelectedItem.ToString();
                orderBLL.UpdateOrder(id, isAccept, status);

                MessageBox.Show("Đơn hàng đã được cập nhật thành công.");
            }
            else
            {
                MessageBox.Show("Vui lòng nhập một ID hợp lệ.");
            }
        }
    }
}
