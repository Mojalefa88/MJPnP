using MJPnP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MJPnP.DAL
{
     public interface ICartProductRepository<Key, Value>
    {
        IQueryable<Value> Read(Key id);
    }
}
