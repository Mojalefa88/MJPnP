using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MJPnP.DAL
{
    public interface IProductRepository<Key, Value>
    {
        Value Create(Value newValue);
        Value Get(Key id);
        Value Get(string value);
        IEnumerable<Value> GetAll();
        void Update(Value value);
        void Delete(Value value);
    }
}
