using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MJPnP.DAL
{
    public interface ITrolleyRepository<Key, Value>
    {
        Value AddToTrolley(Value value);
        void UpdateTrolley(Key id);
        void DeleteFromTrolley(Key id);
        IQueryable<Value> Read();

    }
}
