using Microsoft.EntityFrameworkCore;
using MJPnP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MJPnP.DAL
{
    public class CustomerRepository : IRepository<int, Customer>
    {
        private PnPDbContext db;
        IList<Customer> _customer;

        public CustomerRepository(PnPDbContext db)
        {
            this.db = db;
            _customer = new List<Customer>
            {
                new Customer{FirstName = "Jonas", LastName="Malatji",IdNumber="0002025683088",DateOfBirth="00/02/02", Gender="Male" }
            };
        }

        public Customer Create(Customer customer)
        {
            //_customer.Add(customer);
            db.Customers.Add(new Customer()
            {
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                IdNumber = customer.IdNumber,
                DateOfBirth = customer.DateOfBirth,
                Gender = customer.Gender,
                Email = customer.Email,
                Password = "Password01"
            });
            db.SaveChanges();


            return customer;
        }

        public void Delete(int id)
        {
            _customer.RemoveAt(id);
        }

        public Customer Get(int id)
        {
            var getCustomer = db.Customers.Where(c => c.CustomerID == id).FirstOrDefault();
           return getCustomer;
        }

        public IEnumerable<Customer> GetAll()
        {
            return db.Customers.ToList();
        }

        public string Login(string userName, string password)
        {
            var isLogged = db.Customers.Where(l => l.Email == userName && l.Password == password).FirstOrDefault();

            if (isLogged != null)
                return string.Format(isLogged.FirstName + " " + isLogged.LastName);
            else
                return "Failed to login";
        }

        public void Update(Customer cus)
        {
            Customer customer = Get(cus.CustomerID);
            customer.FirstName = cus.FirstName;
            customer.LastName = cus.LastName;
            
        }
    }

    
}
