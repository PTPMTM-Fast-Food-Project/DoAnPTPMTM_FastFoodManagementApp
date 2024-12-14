using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ProductDTO
    {
        public long product_id { get; set; }
        public string name { get; set; }
        public double cost_price { get; set; }
        public int quantity { get; set; }
        public double price => cost_price * quantity;
    }
}
