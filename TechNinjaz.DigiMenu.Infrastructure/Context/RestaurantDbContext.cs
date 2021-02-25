using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TechNinjaz.DigiMenu.Core.Entities;
using TechNinjaz.DigiMenu.Core.Entities.Identity;
using TechNinjaz.DigiMenu.Core.Entities.OrderEntities;
using TechNinjaz.DigiMenu.Infrastructure.Extensions;

namespace TechNinjaz.DigiMenu.Infrastructure.Context
{
    public sealed class RestaurantDbContext : IdentityDbContext<AuthUser>
    {
        
        public DbSet<MenuCategory> Menus { get; set; }
        public DbSet<Shift> Shifts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<SittingTable> SittingTables { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<SelectedMenuOption> SelectedMenuOptions { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<OrderStatus> OrderStatuses { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }
        public DbSet<MenuItemOption> MenuItemOptions { get; set; }

        public RestaurantDbContext(DbContextOptions<RestaurantDbContext> options) : base(options)
        {
        }
    }
}