using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class RolePermissionBLL
    {
        private RolePermissionDAL rolePermissionDAL = new RolePermissionDAL();

        public RolePermissionBLL()
        {

        }

        public IQueryable<role> LoadAllRoles()
        {
            return rolePermissionDAL.LoadAllRoles();
        }

        public IQueryable<permission> LoadAllPermissions()
        {
            return rolePermissionDAL.LoadAllPermissions();
        }

        public IQueryable<object> LoadAllRolesFollowingPermissions()
        {
            return rolePermissionDAL.LoadAllRolesFollowingPermissions();
        }

        public bool CheckRolePermissionExists(long roleId, long permissionId)
        {
            role_permission rp = new role_permission();
            rp.role_id = roleId;
            rp.permission_id = permissionId;

            return rolePermissionDAL.CheckRolePermissionExists(rp) != null;
        }

        public bool HandleAuthorize(long roleId, long permissionId, bool isPermit)
        {
            role_permission rp = new role_permission();
            rp.role_id = roleId;
            rp.permission_id = permissionId;
            rp.is_permit = isPermit;

            return rolePermissionDAL.HandleAuthorize(rp);
        }

        public bool UpdateAuthorization(long roleId, long permissionId, bool isPermit)
        {
            role_permission rp = new role_permission();
            rp.role_id = roleId;
            rp.permission_id = permissionId;
            rp.is_permit = isPermit;

            return rolePermissionDAL.UpdateAuthorization(rp);
        }

        public bool DeleteAuthorization(long roleId, long permissionId)
        {
            return rolePermissionDAL.DeleteAuthorization(roleId, permissionId);
        }
    }
}
