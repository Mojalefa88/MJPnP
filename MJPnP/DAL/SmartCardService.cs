using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MJPnP.Models;

namespace MJPnP.DAL
{
    public class SmartCardService : ISmartCard
    {
        private PnPDbContext db;

        public SmartCardService(PnPDbContext db)
        {
            this.db = db;
        }
        public SmartCard Create(SmartCard newSmartCart)
        {
            db.SmartCards.Add(new SmartCard
            {
                SmartCardId = newSmartCart.SmartCardId,
                Point = newSmartCart.Point,
                CustomerId = newSmartCart.CustomerId,
            });

            db.SaveChanges();
            return newSmartCart;
        }
    }
}
