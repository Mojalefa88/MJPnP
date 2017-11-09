using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MJPnPMVC.Models
{
    public class Customer
    {
        public int customerID{ get; set; }
        [Required]
        public string firstName { get; set; }
        [Required]
        public string lastName { get; set; }
        [Required]
        public string idNumber { get; set; }
        [Required]
        public string dateOfBirth { get; set; }
        [Required]
        public string gender { get; set; }
        [Required]
        public string email { get; set; }
        [Required]
        public string password { get; set; }


    }
}
