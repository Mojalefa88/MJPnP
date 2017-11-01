using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MJPnPMVC.Models
{
    public class Customer
    {
        public int customerID{ get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string idNumber { get; set; }
        public string dateOfBirth { get; set; }
        public string gender { get; set; }
        public string email { get; set; }
        public string password { get; set; }


    }
}
