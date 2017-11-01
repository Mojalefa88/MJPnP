using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MJPnP.Models
{
    public class Product
    {
        private int productId;
        private string name;
        private double price;
        private string description;
        private byte[] image;
        private int categoryID;

        public int ProductId { get => productId; set => productId = value; }
        public string Name { get => name; set => name = value; }
        public double Price { get => price; set => price = value; }
        public string Description { get => description; set => description = value; }
        public byte[] Image { get => image; set => image = value; }
        public int CategoryID { get => categoryID; set => categoryID = value; }

        public virtual ICollection<ProductCategory> ProductCategories { get; set; }
    }
}
