using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using BLL;

namespace GUI
{
    public partial class Frm_Dashboard : Form
    {
        private DashboardBLL dashboardBLL = new DashboardBLL();
        private OrderBLL orderBLL = new OrderBLL();
        public Frm_Dashboard()
        {
            InitializeComponent();
            btnLogout.Click += BtnLogout_Click;
            btnEmpManaPage.Click += BtnEmpManaPage_Click;
            btnCusManaPage.Click += BtnCusManaPage_Click;
            btnCateManaPage.Click += BtnCateManaPage_Click;
            btnProManaPage.Click += BtnProManaPage_Click;

            Load();
        }

        private void BtnProManaPage_Click(object sender, EventArgs e)
        {
            Frm_ProductsManagement f = new Frm_ProductsManagement();
            OpenChildForm(f);
            ClearButtonBackColor();
            btnProManaPage.BackColor = Color.FromArgb(178, 8, 55);
        }

        private void BtnCateManaPage_Click(object sender, EventArgs e)
        {
            Frm_CategoryManagement f = new Frm_CategoryManagement();
            OpenChildForm(f);
            ClearButtonBackColor();
            btnCateManaPage.BackColor = Color.FromArgb(178, 8, 55);
        }

        private void BtnCusManaPage_Click(object sender, EventArgs e)
        {
            Frm_CustomersManagement f = new Frm_CustomersManagement();
            OpenChildForm(f);
            ClearButtonBackColor();
            btnCusManaPage.BackColor = Color.FromArgb(178, 8, 55);
        }

        private void BtnEmpManaPage_Click(object sender, EventArgs e)
        {
            Frm_EmployeesManagement f = new Frm_EmployeesManagement();
            OpenChildForm(f);
            ClearButtonBackColor();
            btnEmpManaPage.BackColor = Color.FromArgb(178, 8, 55);
        }

        private void ClearButtonBackColor()
        {
            foreach (Control c in pnlSidebar.Controls)
            {
                if (c is Button)
                {
                    Button b = (Button)c;
                    b.BackColor = Color.FromArgb(41, 39, 40);
                }
            }
        }

        private void OpenChildForm(Form childForm)
        {
            // Xóa các điều khiển con hiện tại trong Panel
            pnlMain.Controls.Clear();

            // Thiết lập Form con
            childForm.TopLevel = false; // Không phải cửa sổ độc lập
            childForm.FormBorderStyle = FormBorderStyle.None; // Loại bỏ viền của Form
            childForm.Dock = DockStyle.Fill; // Làm cho Form con chiếm toàn bộ Panel

            // Thêm Form con vào Panel và hiển thị
            pnlMain.Controls.Add(childForm);
            pnlMain.Tag = childForm; // Lưu tham chiếu để sử dụng sau
            childForm.BringToFront(); // Đưa Form con lên trên
            childForm.Show();
        }


        private void BtnLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to log out?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result == DialogResult.Yes)
            {
                Frm_Login login = new Frm_Login();
                login.Show();
                this.Dispose();
            }
        }

        public void SetUsername(string username)
        {
            lblUsername.Text += username;
        }
        private void Load()
        {
            // Lấy số lượng khách hàng
            labelUser.Text = dashboardBLL.GetCustomerCount().ToString();

            // Lấy số lượng đơn hàng
            labelOrder.Text = dashboardBLL.GetOrderCount().ToString();

            // Lấy số lượng sản phẩm
            labelProduct.Text = dashboardBLL.GetProductCount().ToString();

            // Giả sử 'orders' là danh sách các đơn hàng (IEnumerable<OrderDTO>)
            var order = orderBLL.GetAllOrders(); // Phương thức này cần trả về danh sách các đơn hàng
            labelPriceTotal.Text = dashboardBLL.CalculateTotalSales(order).ToString("C"); // Định dạng tiền tệ
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void labelPriceTotal_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void labelProduct_Click(object sender, EventArgs e)
        {

        }
    }
}
