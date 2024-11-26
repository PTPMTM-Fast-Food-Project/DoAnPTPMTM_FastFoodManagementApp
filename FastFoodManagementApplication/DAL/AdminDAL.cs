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

        public bool UpdateAdmin(admin a)
        {
            try
            {
                admin aObtained = FindAdminByUsername(a.username);
                if (aObtained == null)
                    return false;

                aObtained.first_name = a.first_name;
                aObtained.last_name = a.last_name;
                aObtained.image = a.image;
                db.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteAdmin(string username)
        {
            try
            {
                admin aObtained = FindAdminByUsername(username);
                if (aObtained == null)
                    return false;

                db.admins.DeleteOnSubmit(aObtained);
                db.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public IQueryable<object> FindAllUsersByRoleNameIsNotAdmin()
        {
            var query = from a in db.admins
                        join ar in db.admin_roles
                        on a.admin_id equals ar.admin_id into arGroup
                        from ar in arGroup.DefaultIfEmpty()
                        join r in db.roles
                        on ar.role_id equals r.role_id into rGroup
                        from r in rGroup.DefaultIfEmpty()
                        where r == null || r.name != "ADMIN"
                        select new
                        {
                            FirstName = a.first_name,
                            LastName = a.last_name,
                            Username = a.username,
                            Avatar = a.image,
                            Role = r != null ? r.name : "No Role"
                        };
            return query;
        }

        public bool AuthorizeForUser(admin_role ar)
        {
            try
            {
                db.admin_roles.InsertOnSubmit(ar);
                db.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool UpdateUserAuthorization(admin_role ar)
        {
            try
            {
                admin_role arObtained = db.admin_roles.FirstOrDefault(e => e.admin_id == ar.admin_id);

                if (arObtained == null)
                {
                    db.admin_roles.InsertOnSubmit(ar);
                    db.SubmitChanges();
                    return true;
                }

                arObtained.role_id = ar.role_id;
                db.SubmitChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool RevokeUserPermissions(long admin_id)
        {
            try
            {
                admin_role arObtained = db.admin_roles.FirstOrDefault(e => e.admin_id == admin_id);

                if (arObtained == null)
                    return false;

                db.admin_roles.DeleteOnSubmit(arObtained);
                db.SubmitChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool ChangePassword(string password)
        {
            try
            {
                

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
