using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TechNinjaz.DigiMenu.Core.Entities;
using TechNinjaz.DigiMenu.Infrastructure.Extensions;

namespace TechNinjaz.DigiMenu.Infrastructure.Context
{
    public sealed class RestaurantDbContext : IdentityDbContext<User,IdentityRole<int>,int>
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

        public RestaurantDbContext(DbContextOptions<RestaurantDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ConfigTable();
 
        }
    }
}