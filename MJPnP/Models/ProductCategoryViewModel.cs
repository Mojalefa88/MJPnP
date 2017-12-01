using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MJPnP.Models
{
    public class ProductCategoryViewModel
    {
        public int ProductId { get; set ; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public byte[] Image { get; set; }
        public int CategoryID { get; set; }
        public string Status { get; set; }
        public string Category { get; set; }
        public int Quantity { get; set; }
    }
}
