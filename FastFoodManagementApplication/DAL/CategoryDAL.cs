using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class CategoryDAL
    {
        private FastFoodManagementDBDataContext db = new FastFoodManagementDBDataContext();
        public CategoryDAL() { }

        public List<category> FindAllCategories()
        {
            return db.categories.Select(c => c).ToList();
        }
        public IQueryable<object> GetAllCategories()
        {
            var query = from c in db.categories
                        select new
                        {
                            CategoryrId = c.category_id,
                            IsActived = c.is_activated ,
                            IsDelete = c.is_deleted ,
                            Name = c.name
                        };

            return query;
        }

        public bool InsertCategory(string name, bool isActivated)
        {
            try
            {
                var existingCategory = db.categories.FirstOrDefault(c => c.name == name && c.is_deleted == true);

                if (existingCategory != null)
                {
                    existingCategory.is_deleted = false;
                    existingCategory.is_activated = true;

                    db.SubmitChanges();
                }
                else
                {
                    category newCategory = new category
                    {
                        name = name,
                        is_activated = isActivated,
                        is_deleted = false 
                    };

                    db.categories.InsertOnSubmit(newCategory);
                    db.SubmitChanges();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


        public bool UpdateCategory(long id, string name, bool isActivated)
        {
            try
            {
                var category = db.categories.FirstOrDefault(c => c.category_id == id);
                if (category == null) return false;

                category.name = name;
                category.is_activated = isActivated;

                db.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteCategory(long id)
        {
            try
            {
                var category = db.categories.FirstOrDefault(c => c.category_id == id);
                if (category == null) return false;

                bool hasProducts = db.products.Any(p => p.category_id == id);
                if (hasProducts) return false;

                category.is_deleted = true;
                category.is_activated = false;

                db.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public category FindRoleByCategoryName(string categoryName)
        {
            return db.categories.FirstOrDefault(r => r.name.Equals(categoryName));
        }
    }
}
