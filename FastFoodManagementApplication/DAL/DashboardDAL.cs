using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class DashboardDAL
    {
        private FastFoodManagementDBDataContext db = new FastFoodManagementDBDataContext();
        public int GetCustomerCount()
        {
            var count = db.customers.Count();
            return count;
        }
        public int GetOrderCount()
        {
            var count = db.orders.Count();
            return count;
        }
        public int GetProductCount()
        {
            var count = db.products.Count();
            return count;
        }
        public int GetTotalPriceCount()
        {
            var count = db.orders.Count();
            return count;
        }
        public double CalculateTotalSales(IEnumerable<OrderDTO> orders)
        {
            double totalSales = orders
                .Where(order => order.is_accept)
                .Sum(order => order.total_price);

            return totalSales;
        }
    }
}
