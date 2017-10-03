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

        public PnPDbContext(DbContextOptions<PnPDbContext> dbContextOptions) : base(dbContextOptions)
        {

        }
    }
}
