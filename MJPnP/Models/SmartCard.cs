using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MJPnP.Models
{
    public class SmartCard
    {
        private int smartCardId;
        private int customerId;
        private string point;

        public int SmartCardId { get => smartCardId; set => smartCardId = value; }
        public int CustomerId { get => customerId; set => customerId = value; }
        public string Point { get => point; set => point = value; }
    }
}
