using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MovingAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace MovingAPI.Data
{
    public class MovingContext : DbContext
    {
        public MovingContext(DbContextOptions<MovingContext> options)
            : base(options)
        {

        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<ServiceType> Services { get; set; }
        public DbSet<OrderServiceType> OrderServiceTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().ToTable("Customer");
            modelBuilder.Entity<Order>().ToTable("Order")
                .HasOne(o => o.Customer)
                .WithMany(c => c.Orders);

            modelBuilder.Entity<ServiceType>().ToTable("ServiceType");

            modelBuilder.Entity<OrderServiceType>().ToTable("OrderServiceType");
            modelBuilder.Entity<OrderServiceType>()
                .HasKey(k => new { k.OrderID, k.ServiceTypeID });

            modelBuilder.Entity<OrderServiceType>()
                .HasOne(ost => ost.Order)
                .WithMany(o => o.OrderServices);

            modelBuilder.Entity<OrderServiceType>()
                .HasOne(ost => ost.ServiceType)
                .WithMany(st => st.OrderServices);
        }
    }
}
