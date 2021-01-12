using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComputerShopMvc.Data
{
    public class ComputerShopContext : DbContext
    {
        public DbSet<Models.Country> Countries { get; set; }
        public DbSet<Models.Manufacturer> Manufacturers { get; set; }
        public DbSet<Models.ComponentType> ComponentTypes { get; set; }
        public DbSet<Models.Component> Components { get; set; }

        public ComputerShopContext(DbContextOptions<ComputerShopContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
