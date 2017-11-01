using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MJPnP.Models
{
    public class PnPDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Login> Logins { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<SmartCard> SmartCards { get; set; }
        public DbSet<Address> Addresses { get; set; }

        public PnPDbContext(DbContextOptions<PnPDbContext> dbContextOptions) : base(dbContextOptions)
        {
            
        }

        
    }
}
