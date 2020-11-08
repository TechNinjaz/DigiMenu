using Microsoft.EntityFrameworkCore;
using TechNinjaz.DigiMenu.Core.Entities;
using TechNinjaz.DigiMenu.Core.Entities.OrderEntities;

namespace TechNinjaz.DigiMenu.Infrastructure.Extensions
{
    public static class DbContextExtension
    {
        public static void ConfigTable(this ModelBuilder builder)
        {
            // builder.Entity<Order>()
            //     .HasOne(order => order.Waiter)
            //     .WithOne()
            //     .OnDelete(DeleteBehavior.NoAction);
            //
            // builder.Entity<Order>()
            //     .HasOne(order => order.Customer)
            //     .WithOne()
            //     .OnDelete(DeleteBehavior.NoAction);

        }
    }
}