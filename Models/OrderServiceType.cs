using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovingAPI.Models
{
    public class OrderServiceType
    {
        public int OrderID { get; set; }
        public int ServiceTypeID { get; set; }
        public Order Order { get; set; }
        public ServiceType ServiceType { get; set; }
    }
}
