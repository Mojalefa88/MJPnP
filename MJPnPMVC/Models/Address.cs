using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MJPnPMVC.Models
{
    public class Address
    {
        public int addressId { get; set; }
        public string line1 { get; set; }
        public string line2 { get; set; }
        public string city { get; set; }
        public string country { get; set; }
        public string zipcode { get; set; }
        public int customerId { get; set; }
    }
}
