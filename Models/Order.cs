using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovingAPI.Models
{
    public class Order
    {
        public int OrderID { get; set; }
        public string FromAddress { get; set; }
        public string ToAddress { get; set; }
        public string Notes { get; set; }
        public DateTime DateOfService { get; set; }

        //Foreign keys and data structures
        public Customer Customer { get; set; }
        public int CustomerID { get; set; }

        public ICollection<OrderServiceType> OrderServices { get; set; }
    }
}
