using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MJPnP.Models
{
    public class Customer
    {
        private int customerID;
        private string firstName;
        private string lastName;
        private string idNumber;
        private string dateOfBirth;
        private string gender;
        private string email;
        private string password;
        private string status;

        public int CustomerID { get => customerID; set => customerID = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string IdNumber { get => idNumber; set => idNumber = value; }
        public string DateOfBirth { get => dateOfBirth; set => dateOfBirth = value; }
        public string Gender { get => gender; set => gender = value; }
        public string Email { get => email; set => email = value; }
        public string Password { get => password; set => password = value; }
        public string Status { get => status; set => status = value; }

        public virtual ICollection<SmartCard> SmartCards { get; set; }
    }
}
