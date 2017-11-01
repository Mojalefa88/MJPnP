using System.Collections.Generic;
using MJPnP.Models;

namespace MJPnP.DAL
{
    public class ProductRepository : IRepository<int, Product>
    {
        private PnPDbContext db;
        public ProductRepository(PnPDbContext db)
        {
            this.db = db;
        }
        public Product Create(Product newValue)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public Product Get(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Product> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public string Login(string userName, string password)
        {
            throw new System.NotImplementedException();
        }

        public void Update(Product value)
        {
            throw new System.NotImplementedException();
        }
    }
}