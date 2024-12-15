using BLL;
using Microsoft.Reporting.WinForms;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace GUI
{
    public partial class Frm_Bill : Form
    {
        private OrderBLL orderBLL;

        public Frm_Bill(int id)
        {
            InitializeComponent();
            orderBLL = new OrderBLL();
            LoadBill(id);
        }

        private void LoadBill(int id)
        {
            reportViewer1.RefreshReport();
            reportViewer1.LocalReport.DataSources.Clear();

            LoadCustomerData(id);
            LoadOrderDetails(id);
            LoadProductData(id);
            LoadOrderSummary(id);

            reportViewer1.RefreshReport();
        }

        private void LoadCustomerData(int id)
        {
            var customer = orderBLL.GetCustomerByOrderId(id);
            if (customer == null)
            {
                MessageBox.Show("Customer not found for the given order ID.");
                return;
            }

            DataTable dtCustomer = new DataTable();
            dtCustomer.Columns.Add("customer_id", typeof(long));
            dtCustomer.Columns.Add("first_name", typeof(string));
            dtCustomer.Columns.Add("last_name", typeof(string));
            dtCustomer.Columns.Add("address", typeof(string));
            dtCustomer.Columns.Add("phone_number", typeof(string));

            dtCustomer.Rows.Add(customer.customer_id, customer.first_name, customer.last_name, customer.address, customer.phone_number);
            reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSetCustomer", dtCustomer));
        }

        private void LoadOrderDetails(int id)
        {
            var details = orderBLL.GetOrderDetailBill(id);
            if (!details.Any())
            {
                MessageBox.Show("No order details found for the given order ID.");
                return;
            }

            DataTable dtDetails = new DataTable();
            dtDetails.Columns.Add("order_detail_id", typeof(long));
            dtDetails.Columns.Add("quantity", typeof(int));

            foreach (var detail in details)
            {
                dtDetails.Rows.Add(detail.order_detail_id, detail.quantity);
            }

            reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSetDetails", dtDetails));
        }

        private void LoadProductData(int id)
        {
            var products = orderBLL.GetProductBill(id);
            if (!products.Any())
            {
                MessageBox.Show("No product details found for the given order ID.");
                return;
            }

            DataTable dtProduct = new DataTable();
            dtProduct.Columns.Add("product_id", typeof(long));
            dtProduct.Columns.Add("name", typeof(string));
            dtProduct.Columns.Add("cost_price", typeof(double));
            dtProduct.Columns.Add("quantity", typeof(int));

            foreach (var product in products)
            {
                dtProduct.Rows.Add(product.product_id, product.name, product.cost_price, product.quantity);
            }

            reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSetProduct", dtProduct));
        }

        private void LoadOrderSummary(int id)
        {
            var order = orderBLL.GetOrderById(id);
            if (order == null)
            {
                MessageBox.Show("Order not found for the given ID.");
                return;
            }

            DataTable dtOrder = new DataTable();
            dtOrder.Columns.Add("total_price", typeof(double));

            dtOrder.Rows.Add(order.total_price);

            reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSetOrder", dtOrder));
        }
    }
}