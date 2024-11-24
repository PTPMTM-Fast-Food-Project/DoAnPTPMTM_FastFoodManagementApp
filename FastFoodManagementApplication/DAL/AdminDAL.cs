using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class AdminDAL
    {
        private FastFoodManagementDBDataContext db = new FastFoodManagementDBDataContext();

        public AdminDAL()
        {

        }

        public admin FindAdminByUsername(string username)
        {
            return db.admins.FirstOrDefault(e => e.username.Equals(username));
        }

        public bool InsertAdmin(admin a)
        {
            try
            {
                db.admins.InsertOnSubmit(a);
                db.SubmitChanges();
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }
    }
}
