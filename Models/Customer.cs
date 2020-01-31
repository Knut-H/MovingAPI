using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovingAPI.Models
{
    public class Customer
    {
        public int CustomerID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public int PhoneNr { get; set; }
        public string Email { get; set; }

        //Foreign key and data structures
        public ICollection<Order> Orders { get; set; }
    }
}
