using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;
using Domain.Entities;
using Domain.Entities.Pizza;
using Domain.Entities.SalesOrder;

namespace Infrastructure.Persistence
{
    public class TestAppDbContext : DbContext
    {
        public TestAppDbContext(DbContextOptions<TestAppDbContext> options) : base(options)
        { }
        public DbSet<User> Users { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Device> Devices { get; set; }
        public DbSet<TokenInfo> TokenInfos { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Pizza> Pizza => Set<Pizza>();
        public DbSet<PizzaType> PizzaType => Set<PizzaType>();
        public DbSet<Orders> Orders => Set<Orders>();
        public DbSet<OrderDetails> OrderDetails => Set<OrderDetails>();
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>(e =>
            {
                e.OwnsMany(u => u.Benefits, owned =>
                {
                    owned.ToJson();
                }).ToTable("Users").HasKey(s => s.UserId);
            });
            modelBuilder.Entity<AppUser>().ToTable("AppUser");
            modelBuilder.Entity<Department>().ToTable("Departments").HasKey(s => s.DepartmentId);
            modelBuilder.Entity<Device>().ToTable("Devices").HasKey(s => s.DeviceId);
            modelBuilder.Entity<Project>().ToTable("Projects").HasKey(s => s.ProjectId);
            modelBuilder.Entity<Pizza>().ToTable("Pizza").HasKey(s => s.Id);
            modelBuilder.Entity<PizzaType>().ToTable("PizzaType").HasKey(s => s.Id);
            modelBuilder.Entity<Orders>().ToTable("Orders").HasKey(s => s.Id);
            modelBuilder.Entity<OrderDetails>().ToTable("OrderDetails").HasKey(s => s.Id);

            modelBuilder.Entity<Pizza>()
        .Property(p => p.price)
        .HasColumnType("decimal(10,2)");
        }

     

       

        
    }
}
