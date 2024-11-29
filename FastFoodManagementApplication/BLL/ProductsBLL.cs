using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;
namespace BLL
{
    public class ProductsBLL
    {
        private ProductsDAL productDAL = new ProductsDAL();
        public ProductsBLL() { }
        public IQueryable<object> GetAllProducts()
        {
            return productDAL.GetAllProducts();
        }
    }
}
