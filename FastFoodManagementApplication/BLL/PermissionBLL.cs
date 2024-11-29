using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class PermissionBLL
    {
        private PermissionDAL permissionDAL = new PermissionDAL();

        public PermissionBLL()
        {

        }

        public permission FindPermissionByPermissionName(string perName)
        {
            return permissionDAL.FindPermissionByPermissionName(perName);
        }
        public IQueryable<permission> LoadAllPermissions()
        {
            return permissionDAL.LoadAllPermissions();
        }

        public bool InsertPermission(string name, string description)
        {
            permission p = new permission();
            p.name = name;
            p.description = description;

            return permissionDAL.InsertPermission(p);
        }

        public bool UpdatePermission(long permission_id, string name, string description)
        {
            permission p = new permission();
            p.permission_id = permission_id;
            p.name = name;
            p.description = description;

            return permissionDAL.UpdatePermission(p);
        }

        public bool DeletePermission(long permission_id)
        {
            return permissionDAL.DeletePermission(permission_id);
        }

        public bool RemovePermissionFromTheRole(long permission_id)
        {
            return permissionDAL.RemovePermissionFromTheRole(permission_id);
        }
    }
}
