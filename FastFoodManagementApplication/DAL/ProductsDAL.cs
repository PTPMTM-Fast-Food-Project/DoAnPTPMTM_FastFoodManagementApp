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

        public bool InsertProduct(product p)
        {
            try
            {
                var existingProduct = db.products.FirstOrDefault(pr => pr.name == p.name && pr.category_id == p.category_id && pr.is_deleted == true);

                if (existingProduct != null)
                {
                    existingProduct.is_deleted = false;
                    existingProduct.is_activated = true;
                    existingProduct.cost_price = p.cost_price;
                    existingProduct.current_quantity = p.current_quantity;
                    existingProduct.description = p.description;
                    existingProduct.image = p.image;
                    existingProduct.sale_price = p.sale_price;

                    db.SubmitChanges();
                    return true;
                }
                else
                {
                    db.products.InsertOnSubmit(p);
                    db.SubmitChanges();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }


        public bool UpdateProduct(product p)
        {
            try
            {
                var product = db.products.FirstOrDefault(pr => pr.product_id == p.product_id);
                if (product == null)
                {
                    return false; 
                }

                product.name = p.name;
                product.cost_price = p.cost_price;
                product.current_quantity = p.current_quantity;
                product.description = p.description;
                product.image = p.image;
                product.sale_price = p.sale_price;
                product.category_id = p.category_id;
                product.is_activated = p.is_activated;
                product.is_deleted = false;

                db.SubmitChanges(); 
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteProduct(long productId)
        {
            try
            {
                var product = db.products.FirstOrDefault(pr => pr.product_id == productId);
                if (product == null)
                {
                    return false; 
                }

                product.is_deleted = true;
                product.is_activated = false;

                db.SubmitChanges(); 
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public product GetProductByNameAndCategory(string name, long? categoryId)
        {
            return db.products.FirstOrDefault(p => p.name == name && p.category_id == categoryId && p.is_deleted == true);
        }

    }
}
