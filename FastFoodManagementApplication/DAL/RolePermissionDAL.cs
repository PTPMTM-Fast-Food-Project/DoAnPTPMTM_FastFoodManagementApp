using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class RolePermissionDAL
    {
        private FastFoodManagementDBDataContext db = new FastFoodManagementDBDataContext();

        public RolePermissionDAL()
        {

        }

        public IQueryable<role> LoadAllRoles()
        {
            return db.roles.Select(r => r);
        }

        public IQueryable<permission> LoadAllPermissions()
        {
            return db.permissions.Select(p => p);
        }

        public IQueryable<object> LoadAllRolesFollowingPermissions()
        {
            return (from r in db.roles join rp in db.role_permissions 
                    on r.role_id equals rp.role_id join p in db.permissions
                    on rp.permission_id equals p.permission_id
                    select new
                    {
                        RoleName = r.name,
                        PermissionName = p.name,
                        IsPermit = rp.is_permit
                    });
        }

        public role_permission CheckRolePermissionExists(role_permission rp)
        {
            return db.role_permissions.FirstOrDefault(e => e.role_id == rp.role_id &&
                                                        e.permission_id == rp.permission_id);
        }

        public bool HandleAuthorize(role_permission rp)
        {
            try
            {
                db.role_permissions.InsertOnSubmit(rp);
                db.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool UpdateAuthorization(role_permission rp)
        {
            try
            {
                role_permission rpObtainted = db.role_permissions.FirstOrDefault(e => e.role_id == rp.role_id && 
                                                                            e.permission_id == rp.permission_id);
                if (rpObtainted == null)
                    return false;

                rpObtainted.is_permit = rp.is_permit;
                db.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteAuthorization(long roleId, long permissionId)
        {
            try
            {
                role_permission rpObtainted = db.role_permissions.FirstOrDefault(e => e.role_id == roleId &&
                                                                            e.permission_id == permissionId);
                if (rpObtainted == null)
                    return false;

                db.role_permissions.DeleteOnSubmit(rpObtainted);
                db.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
