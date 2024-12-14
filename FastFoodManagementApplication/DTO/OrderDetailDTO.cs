using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class OrderDetailDTO
    {
        public long order_detail_id { get; set; }
        public long product_id { get; set; }
        public string name { get; set; }
        public int quantity { get; set; }
        public decimal cost_price { get; set; }
        public string CategoryName { get; set; }
    }
}
