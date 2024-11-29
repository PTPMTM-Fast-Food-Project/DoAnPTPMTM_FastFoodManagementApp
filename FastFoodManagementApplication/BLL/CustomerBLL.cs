using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BLL
{
    public class CustomerBLL
    {
        private CustomerDAL customerDAL = new CustomerDAL();
        public CustomerBLL() { }
        public IQueryable<object> GetAllCustomers()
        {
            return customerDAL.GetAllCustomers();
        }

        public customer FindCustomerByUsername(string username)
        {
            return customerDAL.FindCustomerByUsername(username);
        }

        public bool HandleRegister(string username, string password)
        {
            customer c = new customer();
            c.username = username;
            c.password = PasswordHelper.HashPassword(password);

            return customerDAL.InsertCustomer(c);
        }

        public bool UpdateCustomer(string username, string firstName, string lastName, string phone_number, string address, string country)
        {
            customer c = new customer();
            c.username = username;
            c.first_name = firstName;
            c.last_name = lastName;
            c.phone_number = phone_number;
            c.address = address;
            c.country = country;
            return customerDAL.UpdateCustomer(c);
        }

        public bool DeleteAdmin(string username)
        {
            return customerDAL.DeleteCustomer(username);
        }
    }
}
