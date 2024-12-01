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

        public bool AddProduct(string name, double costPrice, int quantity, string description, string image, double salePrice, long? categoryId, bool isActivated)
        {
            var newProduct = new product
            {
                name = name,
                cost_price = costPrice,
                current_quantity = quantity,
                description = description,
                image = image,
                sale_price = salePrice,
                category_id = categoryId,
                is_activated = isActivated,
                is_deleted = false 
            };

            return productDAL.InsertProduct(newProduct);
        }


        public bool UpdateProduct(long productId, string name, double costPrice, int quantity, string description, string image, double salePrice, long? categoryId, bool isActivated)
        {
            var productToUpdate = new product
            {
                product_id = productId,  // Sử dụng ID từ giao diện
                name = name,
                cost_price = costPrice,
                current_quantity = quantity,
                description = description,
                image = image,
                sale_price = salePrice,
                category_id = categoryId,
                is_activated = isActivated,
                is_deleted = false
            };

            return productDAL.UpdateProduct(productToUpdate);
        }

        public bool DeleteProduct(long productId)
        {
            return productDAL.DeleteProduct(productId);
        }

    }
}
