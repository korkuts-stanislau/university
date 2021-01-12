using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Data
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
        public virtual DbSet<Models.Manufacturer> Manufacturers { get; set; }
    }
}
