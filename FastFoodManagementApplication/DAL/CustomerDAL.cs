using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class CustomerDAL
    {
        private FastFoodManagementDBDataContext db = new FastFoodManagementDBDataContext();
        public CustomerDAL() { }

        public IQueryable<object> GetAllCustomers()
        {
            var query = from c in db.customers
                        select new
                        {
                            CustomerId = c.customer_id,
                            FirstName = c.first_name ?? string.Empty,
                            LastName = c.last_name ?? string.Empty,
                            Username = c.username,
                            PhoneNumber = c.phone_number ?? string.Empty,
                            Address = c.address ?? string.Empty,
                            Country = c.country ?? string.Empty
                        };

            return query;
        }


        public customer FindCustomerByUsername(string username)
        {
            return db.customers.FirstOrDefault(e => e.username.Equals(username));
        }

        public bool InsertCustomer(customer c)
        {
            try
            {
                db.customers.InsertOnSubmit(c);
                db.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool UpdateCustomer(customer c)
        {
            try
            {
                customer aObtained = FindCustomerByUsername(c.username);
                if (aObtained == null)
                    return false;

                aObtained.first_name = c.first_name;
                aObtained.last_name = c.last_name;
                aObtained.phone_number = c.phone_number;
                aObtained.address = c.address;
                aObtained.country = c.country;
                db.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteCustomer(string username)
        {
            try
            {
                customer aObtained = FindCustomerByUsername(username);
                if (aObtained == null)
                    return false;

                db.customers.DeleteOnSubmit(aObtained);
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
