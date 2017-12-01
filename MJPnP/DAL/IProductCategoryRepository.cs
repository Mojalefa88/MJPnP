using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MJPnP.DAL
{
    public interface IProductCategoryRepository<Key, Value>
    {
        IQueryable<Value> GetProd(string value);
    }
}
