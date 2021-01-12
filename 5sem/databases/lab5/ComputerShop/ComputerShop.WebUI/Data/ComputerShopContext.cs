using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComputerShop.WebUI.Data
{
    public class ComputerShopContext : DbContext
    {
        public ComputerShopContext(DbContextOptions<ComputerShopContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public virtual DbSet<Models.ComponentType> ComponentTypes { get; set; }
        public virtual DbSet<Models.Component> Components { get; set; }
        public virtual DbSet<Models.Country> Countries { get; set; }
        public virtual DbSet<Models.Customer> Customers { get; set; }
        public virtual DbSet<Models.Employee> Employees { get; set; }
        public virtual DbSet<Models.Manufacturer> Manufacturers { get; set; }
        public virtual DbSet<Models.OrderComponent> OrderComponents { get; set; }
        public virtual DbSet<Models.OrderService> OrderServices { get; set; }
        public virtual DbSet<Models.Order> Orders { get; set; }
        public virtual DbSet<Models.Service> Services { get; set; }
    }
}
