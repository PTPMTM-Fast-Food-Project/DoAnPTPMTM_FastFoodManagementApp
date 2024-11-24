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

        public AdminBLL()
        {

        }

        public admin FindAdminByUsername(string username)
        {
            return adminDAL.FindAdminByUsername(username);
        }

        public bool HandleLogin(string username, string password)
        {
            string hashPassword = PasswordHelper.HashPassword(password);
            admin e = adminDAL.FindAdminByUsername(username);
            
            return (e != null && PasswordHelper.VerifyPassword(password, e.password));
        }

        public bool HandleRegister(string username, string password)
        {
            admin a = new admin();
            a.username = username;
            a.password = PasswordHelper.HashPassword(password);

            return adminDAL.InsertAdmin(a);
        }
    }
}
