using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class RoleBLL
    {
        private RoleDAL roleDAL = new RoleDAL();
        public RoleBLL()
        {

        }

        public List<role> FindAllRoles()
        {
            return roleDAL.FindAllRoles();
        }

        public role FindRoleByRoleName(string roleName)
        {
            return roleDAL.FindRoleByRoleName(roleName);
        }

        public bool InsertRole(string roleName)
        {
            role r = new role();
            r.name = roleName;

            return roleDAL.InsertRole(r);
        }

        public bool UpdateRole(long roleId, string roleName)
        {
            role r = new role();
            r.role_id = roleId;
            r.name = roleName;

            return roleDAL.UpdateRole(r);
        }

        public bool DeleteRole(long role_id)
        {
            return roleDAL.DeleteRole(role_id);
        }

        public bool RemoveRoleAllUsers(long role_id)
        {
            return roleDAL.RemoveRoleAllUsers(role_id);
        }
    }
}
