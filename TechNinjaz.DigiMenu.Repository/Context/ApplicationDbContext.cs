using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TechNinjaz.DigiMenu.Domain.DTO;
using TechNinjaz.DigiMenu.Domain.Extensions;
using TechNinjaz.DigiMenu.Repository.Extensions;

namespace TechNinjaz.DigiMenu.Repository.Context
{
    public sealed class ApplicationDbContext : IdentityDbContext<User,IdentityRole<int>,int>
    {
        public DbSet<MenuCategory> Menus { get; set; }
        public DbSet<Shift> Shifts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<SittingTable> SittingTables { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<User> ApplicationUsers { get; set; }
        public DbSet<OrderDetail> OrderDetail { get; set; }
        public DbSet<OrderStatus> OrderStatuses { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ConfigTable();
 
        }
    }
}