using System.Collections.Generic;
using MJPnP.Models;
using System.Linq;
using System;

namespace MJPnP.DAL
{
    public class ProductRepository : IProductRepository<int, Product>, IProductCategoryRepository<int, ProductCategoryViewModel>
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
                Status = "Active",
                Quantity = product.Quantity
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

        public string Get(string value)
        {

            if ((!string.IsNullOrEmpty(value)) && (isNumeric(value, System.Globalization.NumberStyles.Float)))
            {
                var price = 0.0;
                bool convert = double.TryParse(value, out price);
                var getProducts = GetProducts();
                getProducts = getProducts.Where(p => p.Price.Equals(price));

                return getProducts.ToString();
            }
            else if ((!string.IsNullOrEmpty(value)) && (value.ToLower() != "all"))
            {
                var getProducts = GetProducts();
                getProducts = getProducts.Where(p => p.Name.StartsWith(value)
                                                   || p.Name.StartsWith(value)
                                                   || p.Description.StartsWith(value)
                                                   || p.Description.Contains(value)
                                                   || p.Category.Contains(value)
                                                   || p.Category.StartsWith(value)
                                                   );
                return getProducts.ToString();
            }
            else if ((!string.IsNullOrEmpty(value)) && (value.ToLower() == "all"))
            {
                var getProducts = GetProducts();
                return getProducts.ToString();
            }
            else
            {
                var getProducts = GetProducts();

                return getProducts.ToString();
            }

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
            product.Quantity = prod.Quantity;
        }

        public bool isNumeric(string val, System.Globalization.NumberStyles NumberStyle)
        {
            Double result;
            return Double.TryParse(val, NumberStyle,
                System.Globalization.CultureInfo.CurrentCulture, out result);
        }

        public IQueryable<ProductCategoryViewModel> GetProducts()
        {
            var getProducts = (from p in db.Products
                               where p.Status == "Active"
                               join pc in db.ProductCategories
                               on p.CategoryID equals pc.CategoryId
                               select new ProductCategoryViewModel
                               {
                                   ProductId = p.ProductId,
                                   Name = p.Name,
                                   Price = p.Price,
                                   Description = p.Description,
                                   Image = p.Image,
                                   CategoryID = pc.CategoryId,
                                   Status = p.Status,
                                   Category = pc.Category,
                                   Quantity = p.Quantity
                               });

            var mm = getProducts;

            return getProducts;
        }

        public IQueryable<ProductCategoryViewModel> GetProd(string value)
        {
            if ((!string.IsNullOrEmpty(value)) && (isNumeric(value, System.Globalization.NumberStyles.Float)))
            {
                var price = 0.0;
                bool convert = double.TryParse(value, out price);
                var getProducts = GetProducts();
                getProducts = getProducts.Where(p => p.Price.Equals(price));

                return getProducts;
            }
            else if ((!string.IsNullOrEmpty(value)) && (value.ToLower() != "all"))
            {
                var getProducts = GetProducts();
                getProducts = getProducts.Where(p => p.Name.StartsWith(value)
                                                   || p.Name.StartsWith(value)
                                                   || p.Description.StartsWith(value)
                                                   || p.Description.Contains(value)
                                                   || p.Category.Contains(value)
                                                   || p.Category.StartsWith(value)
                                                   );
                return getProducts;
            }
            else if ((!string.IsNullOrEmpty(value)) && (value.ToLower() == "all"))
            {
                var getProducts = GetProducts();
                return getProducts;
            }
            else
            {
                var getProducts = GetProducts();

                return getProducts;
            }
        }


        //public IQueryable<ProductCategoryViewModel> GetProd(string value)
        //{

        //    if ((!string.IsNullOrEmpty(value)) && (isNumeric(value, System.Globalization.NumberStyles.Float)))
        //    {
        //        var price = 0.0;
        //        bool convert = double.TryParse(value, out price);
        //        var getProducts = GetProducts();
        //        getProducts = getProducts.Where(p => p.Price.Equals(price));

        //        return getProducts;
        //    }
        //    else if ((!string.IsNullOrEmpty(value)) && (value.ToLower() != "all"))
        //    {
        //        var getProducts = GetProducts();
        //        getProducts = getProducts.Where(p => p.Name.StartsWith(value)
        //                                           || p.Name.StartsWith(value)
        //                                           || p.Description.StartsWith(value)
        //                                           || p.Description.Contains(value)
        //                                           || p.Category.Contains(value)
        //                                           || p.Category.StartsWith(value)
        //                                           );
        //        return getProducts;
        //    }
        //    else if ((!string.IsNullOrEmpty(value)) && (value.ToLower() == "all"))
        //    {
        //        var getProducts = GetProducts();
        //        return getProducts;
        //    }
        //    else
        //    {
        //        var getProducts = GetProducts();

        //        return getProducts;
        //    }

        //}


    }
}