using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TechNinjaz.DigiMenu.Domain.DTO;
using TechNinjaz.DigiMenu.Repository.Extensions;

namespace TechNinjaz.DigiMenu.Repository.Context
{
    public class ApplicationDbContext : IdentityDbContext<User,IdentityRole<Guid>,Guid>
    {
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Shift> Shifts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<SittingTable> SittingTables { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<User> ApplicationUsers { get; set; }
        public DbSet<OrderStatus> OrderStatuses { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            base.Database.EnsureCreated();
            // base.Database.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ChangeIdentityTableNames();
            base.OnModelCreating(builder);
        }
    }
}