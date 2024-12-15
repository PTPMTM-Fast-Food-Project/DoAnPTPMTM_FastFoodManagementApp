using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BLL
{
    public class OrderBLL
    {
        private OrderDAL orderDAL = new OrderDAL();
        public OrderBLL() { }
        public List<OrderDTO> GetAllOrders()
        {
            return orderDAL.GetAllOrders();
        }
        public List<OrderDTO> GetOrdersReport(DateTime datefrom, DateTime dateto)
        {
            return orderDAL.GetOrdersReport(datefrom, dateto);
        }
        public IQueryable<object> UpdateOrder(long id, bool is_accept, string order_status)
        {
            return orderDAL.UpdateOrder(id, is_accept, order_status);
        }
        public IQueryable<object> GetOrderDetailByOrderId(int id)
        {
            return orderDAL.GetOrderDetailByOrderId(id);
        }
        public CustomerDTO GetCustomerByOrderId(long orderId)
        {
            return orderDAL.GetCustomerByOrderId(orderId);
        }
        public List<OrderDetailDTO> GetOrderDetailBill(int id)
        {
            return orderDAL.GetOrderDetailBill(id);
        }
        public List<ProductDTO> GetProductBill(int orderId)
        {
            return orderDAL.GetProductBill(orderId);
        }
        public OrderDTO GetOrderById(long orderId)
        {
            return orderDAL.GetOrderById(orderId);
        }
    }
}
