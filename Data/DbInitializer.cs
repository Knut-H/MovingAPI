using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MovingAPI.Data;
using MovingAPI.Models;

namespace MovingAPI.Data
{
    public class DbInitializer
    {
        public static void Initialize(MovingContext context)
        {
            context.Database.EnsureCreated();

            if (context.Services.Any())
            {
                //Services set as seed check. This is because ServiceTypes is not to be changed by vendor
                //Has to be set manually and must be present for the project to work properly
                return;
            }

            var services = new ServiceType[]
            {
                new ServiceType{Name="Moving" },
                new ServiceType{Name="Packing" },
                new ServiceType{Name="Cleaning" }
            };

            foreach (ServiceType st in services)
            {
                context.Services.Add(st);
            }

            context.SaveChanges();

            var customer = new Customer[]
            {
                new Customer{LastName="Testesen", FirstName="Test", Email="Test@Test.test", PhoneNr=12345678},
                new Customer{LastName="IkkeTestesen", FirstName="Testia", Email="Testia@Test.test", PhoneNr=12345678}
            };

            foreach (Customer c in customer)
            {
                context.Customers.Add(c);
            }

            context.SaveChanges();

            var order = new Order[]
            {
                new Order{ CustomerID=2, DateOfService= new DateTime(2020,4,4), FromAddress="Testveien 4", ToAddress="Testveien 3" }
            };

            foreach (Order o in order)
            {
                context.Orders.Add(o);
            }

            context.SaveChanges();

            var orderServices = new OrderServiceType[]
            {
                new OrderServiceType{ OrderID=1, ServiceTypeID=2}
            };

            foreach (OrderServiceType ost in orderServices)
            {
                context.OrderServiceTypes.Add(ost);
            }

            context.SaveChanges();
        }
    }
}
