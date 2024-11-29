using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class AdminBLL
    {
        private AdminDAL adminDAL = new AdminDAL();
        private RoleDAL roleDAL = new RoleDAL();

        public AdminBLL()
        {

        }

        public admin FindAdminByUsername(string username)
        {
            return adminDAL.FindAdminByUsername(username);
        }

        public LoginResult HandleLogin(string username, string password)
        {
            string hashPassword = PasswordHelper.HashPassword(password);
            admin e = adminDAL.FindAdminByUsername(username);

            return (e != null && PasswordHelper.VerifyPassword(password, e.password) ?
                    LoginResult.Success : LoginResult.Invalid);
        }

        public bool HandleRegister(string username, string password)
        {
            admin a = new admin();
            a.username = username;
            a.password = PasswordHelper.HashPassword(password);

            return adminDAL.InsertAdmin(a);
        }

        public bool UpdateAdmin(string username, string firstName, string lastName, string image)
        {
            admin a = new admin();
            a.username = username;
            a.first_name = firstName;
            a.last_name = lastName;
            a.image = image;

            return adminDAL.UpdateAdmin(a);
        }

        public bool DeleteAdmin(string username)
        {
            return adminDAL.DeleteAdmin(username);
        }

        public IQueryable<object> FindAllUsersByRoleNameIsNotAdmin()
        {
            return adminDAL.FindAllUsersByRoleNameIsNotAdmin();
        }

        public bool AuthorizeForUser(string username, long role)
        {
            admin a = adminDAL.FindAdminByUsername(username);

            if (a == null)
                return false;

            admin_role ar = new admin_role();
            ar.admin_id = a.admin_id;
            ar.role_id = role;

            return adminDAL.AuthorizeForUser(ar);
        }

        public bool UpdateUserAuthorization(string username, long role_id)
        {
            admin a = FindAdminByUsername(username);

            if (a == null)
                return false;

            admin_role ar = new admin_role();
            ar.admin_id = a.admin_id;
            ar.role_id = role_id;

            return adminDAL.UpdateUserAuthorization(ar);
        }

        public bool RevokeUserPermissions(string username)
        {
            admin a = FindAdminByUsername(username);

            if (a == null)
                return false;

            return adminDAL.RevokeUserPermissions(a.admin_id);
        }

        public bool ChangePassword(string username, string password)
        {
            string hashPassword = PasswordHelper.HashPassword(password);
            return adminDAL.ChangePassword(username, hashPassword);
        }
    }
}
