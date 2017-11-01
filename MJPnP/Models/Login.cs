using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MJPnP.Models
{
    public class Login
    {
        [Key]
        public int ID { get; set; }
        public int CustomerID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
