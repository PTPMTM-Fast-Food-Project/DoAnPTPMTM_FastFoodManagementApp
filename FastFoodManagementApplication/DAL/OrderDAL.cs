using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class OrderDAL
    {
        private FastFoodManagementDBDataContext db = new FastFoodManagementDBDataContext();
        public OrderDAL() { }

        public List<OrderDTO> GetAllOrders()
        {
            var orders = from o in db.orders
                         join c in db.customers on o.customer_id equals c.customer_id
                         select new OrderDTO
                         {
                             order_id = o.order_id,
                             delivery_date = o.delivery_date,
                             is_accept = o.is_accept,
                             order_date = o.order_date,
                             order_status = o.order_status,
                             payment_method = o.payment_method,
                             quantity = o.quantity,
                             tax = o.tax,
                             total_price = o.total_price,
                             customer_id = c.customer_id,
                         };

            return orders.ToList(); // Ensure to return a List<OrderDTO>
        }
        public List<OrderDTO> GetOrdersReport(DateTime datefrom, DateTime dateto)
        {
            var orders = from o in db.orders
                         join c in db.customers on o.customer_id equals c.customer_id
                         where o.order_date >= datefrom && o.order_date <= dateto && o.is_accept == true && o.order_status == "Hoàn thành"
                         select new OrderDTO
                         {
                             order_id = o.order_id,
                             delivery_date = o.delivery_date,
                             is_accept = o.is_accept,
                             order_date = o.order_date,
                             order_status = o.order_status,
                             payment_method = o.payment_method,
                             quantity = o.quantity,
                             tax = o.tax,
                             total_price = o.total_price,
                             customer_id = c.customer_id,
                         };

            return orders.ToList(); // Trả về danh sách OrderDTO
        }

        public IQueryable<object> UpdateOrder(long id, bool is_accept, string order_status)
        {
            var order = db.orders.SingleOrDefault(d => d.order_id == id);

            if (order != null)
            {
                order.is_accept = is_accept;
                order.order_status = order_status;
                db.SubmitChanges();
            }

            return db.orders;
        }

        public IQueryable<object> GetOrderDetailByOrderId(int id)
        {
            var orderDetails = from od in db.order_details
                               where od.order_id == id
                               join p in db.products on od.product_id equals p.product_id
                               join c in db.categories on p.category_id equals c.category_id into categoryGroup
                               from category in categoryGroup
                               select new
                               {
                                   od.order_detail_id,
                                   od.product_id,
                                   p.name,
                                   p.cost_price,
                                   CategoryName = category != null ? category.name : "Không xác định"
                               };

            return orderDetails;
        }
    }
}
