using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MJPnP.Models
{
    public class Address
    {
        private int addressId;
        private string line1;
        private string line2;
        private string city;
        private string country;
        private string zipcode;
        private int customerId;

        public int AddressId { get => addressId; set => addressId = value; }
        public string Line1 { get => line1; set => line1 = value; }
        public string Line2 { get => line2; set => line2 = value; }
        public string City { get => city; set => city = value; }
        public string Country { get => country; set => country = value; }
        public string Zipcode { get => zipcode; set => zipcode = value; }
        public int CustomerId { get => customerId; set => customerId = value; }
    }
}
