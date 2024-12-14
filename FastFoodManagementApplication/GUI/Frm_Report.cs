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
    public partial class Frm_Report : Form
    {
        OrderBLL orderBLL = new OrderBLL();
        public Frm_Report()
        {
            InitializeComponent();
            buttonExcel.Click += new EventHandler(buttonExcel_Click);
            buttonWord.Click += new EventHandler(buttonWord_Click);
            buttonReport.Click += buttonReport_Click;
        }

        private void Frm_Report_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'fastFoodManagementDBDataSet.orders' table. You can move, or remove it, as needed.
            this.ordersTableAdapter.Fill(this.fastFoodManagementDBDataSet.orders);

            this.reportViewer1.RefreshReport();
        }

        private void buttonReport_Click(object sender, EventArgs e)
        {
            DateTime fromDate = dateTimePickerTuNgay.Value;
            DateTime toDate = dateTimePickerDenNgay.Value;

            // Lấy tất cả các đơn hàng trong khoảng thời gian đã chọn
            var allOrders = orderBLL.GetOrdersReport(fromDate, toDate);

            // Thiết lập nguồn dữ liệu cho report viewer
            reportViewer1.LocalReport.DataSources.Clear();

            // Tạo DataTable từ danh sách đơn hàng
            DataTable dtOrders = new DataTable();
            dtOrders.Columns.Add("order_id", typeof(long));
            dtOrders.Columns.Add("customer_id", typeof(long));
            dtOrders.Columns.Add("order_date", typeof(DateTime));
            dtOrders.Columns.Add("quantity", typeof(int));
            dtOrders.Columns.Add("total_price", typeof(double));

            // Thêm dữ liệu vào DataTable
            foreach (var order in allOrders)
            {
                dtOrders.Rows.Add(order.order_id, order.customer_id, order.order_date, order.quantity, order.total_price);
            }

            // Thêm DataTable vào nguồn dữ liệu của report viewer
            reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("Order", dtOrders));

            // Cập nhật và hiển thị báo cáo
            reportViewer1.RefreshReport();
        }

        private void buttonWord_Click(object sender, EventArgs e)
        {
            DateTime fromDate = dateTimePickerTuNgay.Value;
            DateTime toDate = dateTimePickerDenNgay.Value;
            // Get all orders using the BLL
            var allOrders = orderBLL.GetOrdersReport(fromDate, toDate); // Retrieve orders as a list

            WordExport dt = new WordExport();
            dt.BCTK(fromDate, toDate, allOrders);
        }

        private void buttonExcel_Click(object sender, EventArgs e)
        {
            DateTime fromDate = dateTimePickerTuNgay.Value;
            DateTime toDate = dateTimePickerDenNgay.Value;
            // Get all orders using the BLL
            var allOrders = orderBLL.GetOrdersReport(fromDate, toDate); // Retrieve orders as a list


            // Proceed to export the filtered orders
            ExcelExport excel = new ExcelExport();
            string path = string.Empty;

            excel.ExportOrder(allOrders, ref path, false);

            // Confirm if the user wants to open the exported file
            if (!string.IsNullOrEmpty(path) &&
                MessageBox.Show("Bạn có muốn mở file không?", "Thông tin", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                System.Diagnostics.Process.Start(path);
            }
        }
    }
}
