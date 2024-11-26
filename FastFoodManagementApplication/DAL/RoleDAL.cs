using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class RoleDAL
    {
        private FastFoodManagementDBDataContext db = new FastFoodManagementDBDataContext();

        public RoleDAL()
        {

        }

        public List<role> FindAllRoles()
        {
            return db.roles.Select(r => r).ToList();
        }

        public role FindRoleByRoleName(string roleName)
        {
            return db.roles.FirstOrDefault(r => r.name.Equals(roleName));
        }

        public bool InsertRole(role r)
        {
            try
            {
                db.roles.InsertOnSubmit(r);
                db.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool UpdateRole(role r)
        {
            try
            {
                role rObtained = db.roles.FirstOrDefault(e => e.role_id == r.role_id);
                if (rObtained == null)
                    return false;

                rObtained.name = r.name;
                db.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteRole(long role_id)
        {
            try
            {
                role rObtained = db.roles.FirstOrDefault(e => e.role_id == role_id);
                if (rObtained == null)
                    return false;

                db.roles.DeleteOnSubmit(rObtained);
                db.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool RemoveRoleAllUsers(long role_id)
        {
            try
            {
                var arObtained = db.admin_roles.Where(e => e.role_id == role_id);
                if (!arObtained.Any())
                    return false;

                db.admin_roles.DeleteAllOnSubmit(arObtained);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
