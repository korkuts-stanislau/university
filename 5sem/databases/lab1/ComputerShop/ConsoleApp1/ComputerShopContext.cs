using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ConsoleApp1
{
    public partial class ComputerShopContext : DbContext
    {
        public ComputerShopContext()
        {
        }

        public ComputerShopContext(DbContextOptions<ComputerShopContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ComponentTypes> ComponentTypes { get; set; }
        public virtual DbSet<Components> Components { get; set; }
        public virtual DbSet<Countries> Countries { get; set; }
        public virtual DbSet<Customers> Customers { get; set; }
        public virtual DbSet<Employees> Employees { get; set; }
        public virtual DbSet<GetAllComponentsInfo> GetAllComponentsInfo { get; set; }
        public virtual DbSet<Manufacturers> Manufacturers { get; set; }
        public virtual DbSet<OrderComponents> OrderComponents { get; set; }
        public virtual DbSet<OrderServices> OrderServices { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<Services> Services { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=tcp:computershopdb.database.windows.net,1433;Initial Catalog=ComputerShop;Persist Security Info=False;User ID=korkuts;Password=stas2001!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ComponentTypes>(entity =>
            {
                entity.HasKey(e => e.ComponentTypeId)
                    .HasName("PK__Componen__37B2DD865CCFB254");

                entity.Property(e => e.ComponentTypeDescription)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ComponentTypeName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Components>(entity =>
            {
                entity.HasKey(e => e.ComponentId)
                    .HasName("PK__Componen__D79CF04E5FFEAA07");

                entity.Property(e => e.ComponentCharacteristics)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ComponentDescription)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ComponentModel)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ComponentPrice).HasColumnType("money");

                entity.Property(e => e.ComponentReleaseDate).HasColumnType("date");

                entity.HasOne(d => d.ComponentCountry)
                    .WithMany(p => p.Components)
                    .HasForeignKey(d => d.ComponentCountryId)
                    .HasConstraintName("FK__Component__Compo__607251E5");

                entity.HasOne(d => d.ComponentManufacturer)
                    .WithMany(p => p.Components)
                    .HasForeignKey(d => d.ComponentManufacturerId)
                    .HasConstraintName("FK__Component__Compo__5F7E2DAC");

                entity.HasOne(d => d.ComponentType)
                    .WithMany(p => p.Components)
                    .HasForeignKey(d => d.ComponentTypeId)
                    .HasConstraintName("FK__Component__Compo__5E8A0973");
            });

            modelBuilder.Entity<Countries>(entity =>
            {
                entity.HasKey(e => e.CountryId)
                    .HasName("PK__Countrie__10D1609F058DF78C");

                entity.Property(e => e.CountryName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Customers>(entity =>
            {
                entity.HasKey(e => e.CustomerId)
                    .HasName("PK__Customer__A4AE64D84C427C04");

                entity.Property(e => e.CustomerAddress)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CustomerFullName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CustomerPhoneNumber)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Employees>(entity =>
            {
                entity.HasKey(e => e.EmployeeId)
                    .HasName("PK__Employee__7AD04F11CD709A24");

                entity.Property(e => e.EmployeeFullName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<GetAllComponentsInfo>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("GetAllComponentsInfo");

                entity.Property(e => e.ComponentCharacteristics)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ComponentDescription)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ComponentModel)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ComponentPrice).HasColumnType("money");

                entity.Property(e => e.ComponentReleaseDate).HasColumnType("date");

                entity.Property(e => e.ComponentTypeDescription)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ComponentTypeName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CountryName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ManufacturerName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Manufacturers>(entity =>
            {
                entity.HasKey(e => e.ManufacturerId)
                    .HasName("PK__Manufact__357E5CC11B370098");

                entity.Property(e => e.ManufacturerName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<OrderComponents>(entity =>
            {
                entity.HasKey(e => e.OrderComponentId)
                    .HasName("PK__OrderCom__77259463611A59B4");

                entity.HasOne(d => d.Component)
                    .WithMany(p => p.OrderComponents)
                    .HasForeignKey(d => d.ComponentId)
                    .HasConstraintName("FK__OrderComp__Compo__719CDDE7");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderComponents)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK__OrderComp__Order__70A8B9AE");
            });

            modelBuilder.Entity<OrderServices>(entity =>
            {
                entity.HasKey(e => e.OrderServiceId)
                    .HasName("PK__OrderSer__F065F7EBFA915314");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderServices)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK__OrderServ__Order__6CD828CA");

                entity.HasOne(d => d.Service)
                    .WithMany(p => p.OrderServices)
                    .HasForeignKey(d => d.ServiceId)
                    .HasConstraintName("FK__OrderServ__Servi__6DCC4D03");
            });

            modelBuilder.Entity<Orders>(entity =>
            {
                entity.HasKey(e => e.OrderId)
                    .HasName("PK__Orders__C3905BCF49E0833F");

                entity.Property(e => e.OrderExecutionDate).HasColumnType("date");

                entity.Property(e => e.OrderPrepayment).HasColumnType("money");

                entity.Property(e => e.OrderStartDate).HasColumnType("date");

                entity.HasOne(d => d.OrderCustomer)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.OrderCustomerId)
                    .HasConstraintName("FK__Orders__OrderCus__690797E6");

                entity.HasOne(d => d.OrderExecutingEmployee)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.OrderExecutingEmployeeId)
                    .HasConstraintName("FK__Orders__OrderExe__69FBBC1F");
            });

            modelBuilder.Entity<Services>(entity =>
            {
                entity.HasKey(e => e.ServiceId)
                    .HasName("PK__Services__C51BB00AE3B527CC");

                entity.Property(e => e.ServiceDescription)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ServiceName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ServicePrice).HasColumnType("money");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
