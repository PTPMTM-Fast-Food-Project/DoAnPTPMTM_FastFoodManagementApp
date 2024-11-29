using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
namespace DAL
{
    public class ProductsDAL
    {
        private FastFoodManagementDBDataContext db = new FastFoodManagementDBDataContext();
        public ProductsDAL() { }

        public IQueryable<object> GetAllProducts()
        {
            var query = from p in db.products
                        select new
                        {
                            ProductId = p.product_id,
                            CostPrice = p.cost_price ,
                            CurrentQuantity = p.current_quantity,
                            Description = p.description ?? string.Empty,
                            Image = p.image ?? string.Empty,
                            IsActived = p.is_activated,
                            IsDelete = p.is_deleted,
                            Name = p.name ?? string.Empty,
                            SalePrice = p.sale_price,
                            CategoryId = p.category_id.HasValue ? (long?)p.category_id : null
                        };

            return query;
        }
    }
}
