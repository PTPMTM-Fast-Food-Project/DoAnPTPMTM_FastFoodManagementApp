using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BLL
{
    public class DashboardBLL
    {
        private DashboardDAL dashboardDAL = new DashboardDAL();
        public DashboardBLL() { }
        public int GetCustomerCount()
        {
            return dashboardDAL.GetCustomerCount();
        }
        public int GetOrderCount()
        {
            return dashboardDAL.GetOrderCount();
        }
        public int GetProductCount()
        {
            return dashboardDAL.GetProductCount();
        }
        public int GetTotalPriceCount()
        {
            return dashboardDAL.GetTotalPriceCount();
        }
        public double CalculateTotalSales(IEnumerable<OrderDTO> orders)
        {
            return dashboardDAL.CalculateTotalSales(orders);
        }
    }
}
