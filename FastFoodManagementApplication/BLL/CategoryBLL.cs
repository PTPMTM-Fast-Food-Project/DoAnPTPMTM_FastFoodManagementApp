using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BLL
{
    public class CategoryBLL
    {
        private CategoryDAL categoryDAL = new CategoryDAL();
        public CategoryBLL() { }
        public IQueryable<object> GetAllCategories()
        {
            return categoryDAL.GetAllCategories();
        }
        public bool AddNewCategory(string name, bool isActivated)
        {
            return categoryDAL.InsertCategory(name, isActivated);
        }

        public bool UpdateCategory(long id, string name, bool isActivated)
        {
            return categoryDAL.UpdateCategory(id, name, isActivated);
        }

        public bool DeleteCategory(long id)
        {
            return categoryDAL.DeleteCategory(id);
        }

    }
}
