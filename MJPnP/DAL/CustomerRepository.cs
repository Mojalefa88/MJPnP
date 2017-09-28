using MJPnP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MJPnP.DAL
{
    public class CustomerRepository : IRepository<int, Customer>
    {
        IList<Customer> _customer;

        public CustomerRepository()
        {
            _customer = new List<Customer>
            {
                new Customer{FirstName = "Jonas", LastName="Malatji",IdNumber="0002025683088",DateOfBirth="00/02/02", Gender="Male" }
            };
        }

        public Customer Create(Customer customer)
        {
            _customer.Add(customer);

            return customer;
        }

        public void DeleteCustomer(int id)
        {
            _customer.RemoveAt(id);
        }

        public Customer Get(int id)
        {
           return _customer.Where(c => c.CustomerID == id).FirstOrDefault();
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            return _customer;
        }

        public void UpdateCustomer(Customer cus)
        {
            Customer customer = Get(cus.CustomerID);
            customer.FirstName = cus.FirstName;
            customer.LastName = cus.LastName;
            
        }
    }
}
