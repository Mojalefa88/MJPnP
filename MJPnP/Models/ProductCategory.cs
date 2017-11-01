using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MJPnP.Models
{
    public class ProductCategory
    {
        
        private int categoryId;
        private string category;

        [Key]
        public int CategoryId { get => categoryId; set => categoryId = value; }
        public string Category { get => category; set => category = value; }
    }
}
