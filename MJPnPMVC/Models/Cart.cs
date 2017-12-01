using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MJPnPMVC.Models
{
    public class Cart
    {
        private int cartId;
        private int productId;
        private int quantity;
        private int customerId;

        public int CartId { get => cartId; set => cartId = value; }
        public int ProductId { get => productId; set => productId = value; }
        public int Quantity { get => quantity; set => quantity = value; }
        public int CustomerId { get => customerId; set => customerId = value; }
    }
}
