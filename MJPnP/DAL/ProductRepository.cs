using System.Collections.Generic;
using MJPnP.Models;
using System.Linq;

namespace MJPnP.DAL
{
    public class ProductRepository : IRepository<int, Product>
    {
        private PnPDbContext db;
        public ProductRepository(PnPDbContext db)
        {
            this.db = db;
        }
        public Product Create(Product product)
        {
            db.Products.Add(new Product()
            {
                Name = product.Name,
                Price = product.Price,
                Description = product.Description,
                Image = product.Image,
                CategoryID = product.CategoryID,

            });

            db.SaveChanges();

            return product;
        }

        public void Delete(Product prod)
        {
            Product product = Get(prod.ProductId);
            product.Status = "Deleted";
        }

        public Product Get(int id)
        {
            return db.Products.Where(p => p.ProductId == id).FirstOrDefault();
        }

        public IEnumerable<Product> GetAll()
        {
            return db.Products.ToList();
        }

        public string Login(string userName, string password)
        {
            throw new System.NotImplementedException();
        }

        public void Update(Product prod)
        {
            Product product = Get(prod.ProductId);
            product.Name = prod.Name;
            prod.Price = prod.Price;
            product.Description = prod.Description;
            product.Image = prod.Image;
            product.CategoryID = prod.CategoryID;
        }
    }
}