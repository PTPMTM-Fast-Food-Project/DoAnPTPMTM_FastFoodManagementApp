using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class OrderDTO
    {
        public string STT { get; set; }
        public long order_id { get; set; }
        public DateTime? delivery_date { get; set; }
        public bool is_accept { get; set; }
        public DateTime? order_date { get; set; }
        public string order_status { get; set; }
        public string payment_method { get; set; }
        public int quantity { get; set; }
        public double tax { get; set; }
        public double total_price { get; set; }
        public long customer_id { get; set; }
    }
}
