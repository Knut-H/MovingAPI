﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovingAPI.Models
{
    public class ServiceType
    {
        public int ServiceTypeID { get; set; }
        public string Name { get; set; }

        public ICollection<OrderServiceType> OrderServices { get; set; }
    }
}
