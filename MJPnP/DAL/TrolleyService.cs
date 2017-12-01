using MJPnP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MJPnP.Models;
namespace MJPnP.DAL
{
    public class TrolleyService : ITrolleyRepository<int, Cart>, ICartProductRepository<int, CartProductViewModel>
    {
        private PnPDbContext dbContext;
        public TrolleyService(PnPDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public Cart AddToTrolley(Cart value)
        {
            // var trolley = dbContext.ca
            var trolley = dbContext.Carts.Add(value);
            dbContext.SaveChanges();

            return value;
        }

        public void DeleteFromTrolley(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Cart> Read()
        {
            throw new NotImplementedException();
        }

        public IQueryable<CartProductViewModel> Read(int id)
        {
            var trolley = (from c in dbContext.Carts
                           where c.CartId == id
                           join p in dbContext.Products
                           on c.ProductId equals p.ProductId
                           join pc in dbContext.ProductCategories
                           on p.CategoryID equals pc.CategoryId
                           select new CartProductViewModel
                           {
                               CartId = c.CartId,
                               CustomerId = c.CustomerId,
                               Quantity = c.Quantity,
                               ProductId = p.ProductId,
                               Name = p.Name,
                               Price = p.Price,
                               Description = p.Description,
                               Image = p.Image,
                               Category = pc.Category,
                               CategoryID = pc.CategoryId,
                               Status = p.Status,
                           });

            return trolley;
        }

        public void UpdateTrolley(int id)
        {
            throw new NotImplementedException();
        }

    }
}
