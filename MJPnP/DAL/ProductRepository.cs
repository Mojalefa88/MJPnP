using System.Collections.Generic;
using MJPnP.Models;
using System.Linq;
using System;

namespace MJPnP.DAL
{
    public class ProductRepository : IProductRepository<int, Product>
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

        public Product Get(string value)
        {
            Product product = new Product();
            if ((!string.IsNullOrEmpty(value)) && (isNumeric(value, System.Globalization.NumberStyles.Float)))
            {
                var price = 0.0;
                bool convert = double.TryParse(value, out price);

                product = db.Products.Where(p => p.Price.Equals(price)).FirstOrDefault();
            }
                return db.Products.Where(p => p.Name.Contains(value)
                                    ||p.Name.StartsWith(value)).FirstOrDefault();

           
        }

        public IEnumerable<Product> GetAll()
        {
            return db.Products.ToList();
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

        public bool isNumeric(string val, System.Globalization.NumberStyles NumberStyle)
        {
            Double result;
            return Double.TryParse(val, NumberStyle,
                System.Globalization.CultureInfo.CurrentCulture, out result);
        }
    }
}