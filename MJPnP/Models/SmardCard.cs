using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MJPnP.Models
{
    public class SmartCard
    {
        private int id;
        private string smartCardId;
        private int customerId;
        private string point;

        [Key]
        public int Id { get => id; set => id = value; }
        [Range(1, 12)]
        public string SmartCardId { get => smartCardId; set => smartCardId = value; }
        public int CustomerId { get => customerId; set => customerId = value; }
        public string Point { get => point; set => point = value; }

        //public virtual ICollection<Customer> Customers { get; set; }

    }
}
