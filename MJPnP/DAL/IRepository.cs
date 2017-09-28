using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MJPnP.DAL
{
    public interface IRepository<Key, Value>
    {
        Value Create(Value newValue);
        Value Get(int id);
        IEnumerable<Value> GetAllCustomers();
        void UpdateCustomer(Value value);
        void DeleteCustomer(Key id);
    }
}
