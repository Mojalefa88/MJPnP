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
            db.Customers.Add(new Customer()
            {
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                IdNumber = customer.IdNumber,
                DateOfBirth = customer.DateOfBirth,
                Gender = customer.Gender,
                Email = customer.Email,
                Password = "Password01",
                Status = "Active"
            });
            db.SaveChanges();

            var customerID = db.Customers.LastOrDefault().CustomerID;

            CreateSmartCard(customerID);

            return customer;
        }

        public void Delete(Customer cus)
        {
            Customer customer = Get(cus.CustomerID);
            customer.Status = "Deleted";
            db.SaveChanges();
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

        public void Update(Customer customer)
        {
            int customerID = customer.CustomerID;
            var existingCustomer = Get(customerID);
            existingCustomer.FirstName = customer.FirstName;
            existingCustomer.LastName = customer.LastName;
            existingCustomer.Email = customer.Email;
            existingCustomer.Gender = customer.Gender;
            existingCustomer.DateOfBirth = customer.DateOfBirth;
            //db.Entry(existingCustomer).State = EntityState.Modified;
            db.SaveChanges();
           
        }

        public void CreateSmartCard(int customerID)
        {
            var date = DateTime.Now;
            //var month = date.Month;
            //var year = date.Year;
            //var day = date.Day;
            //var hour = date.Hour;
            //var minute = date.Minute;
            //var second = date.Second;

            //var tempSmartId = day + "" + month + "" + year + "" + hour + "" + minute + "" + second;

           var tempSmartId = date.ToString("yyMMddHHmmss");

            db.SmartCards.Add(new SmartCard
            {
                SmartCardId = tempSmartId,
                Point = "0",
                CustomerId = customerID,
            });

            
            db.SaveChanges();
        }
    }

    
}
