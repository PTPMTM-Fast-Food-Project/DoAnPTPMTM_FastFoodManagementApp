using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class PermissionDAL
    {
        private FastFoodManagementDBDataContext db = new FastFoodManagementDBDataContext();

        public PermissionDAL()
        {

        }

        public permission FindPermissionByPermissionName(string perName)
        {
            return db.permissions.FirstOrDefault(p => p.name.Equals(perName));
        }

        public IQueryable<permission> LoadAllPermissions()
        {
            return db.permissions.Select(p => p);
        }

        public bool InsertPermission(permission p)
        {
            try
            {
                db.permissions.InsertOnSubmit(p);
                db.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool UpdatePermission(permission p)
        {
            try
            {
                permission pObtained = db.permissions.FirstOrDefault(e => e.permission_id == p.permission_id);
                if (pObtained == null)
                    return false;

                pObtained.name = p.name;
                pObtained.description = p.description;
                db.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeletePermission(long permission_id)
        {
            try
            {
                permission pObtained = db.permissions.FirstOrDefault(e => e.permission_id == permission_id);
                if (pObtained == null)
                    return false;

                db.permissions.DeleteOnSubmit(pObtained);
                db.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool RemovePermissionFromTheRole(long permission_id)
        {
            try
            {
                var rpObtained = db.role_permissions.Where(e => e.permission_id == permission_id);
                if (!rpObtained.Any())
                    return true;

                db.role_permissions.DeleteAllOnSubmit(rpObtained);
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
