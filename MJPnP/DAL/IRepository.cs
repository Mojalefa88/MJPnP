using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MJPnP.DAL
{
    public interface IRepository<Key, Value>
    {
        Value Create(Value newValue);
        Value Get(Key id);
        IEnumerable<Value> GetAll();
        void Update(Value value);
        void Delete(Key id);

        string Login(string userName, string password);
    }
}
