using Microsoft.EntityFrameworkCore;
using TechNinjaz.DigiMenu.Core.Entities;

namespace TechNinjaz.DigiMenu.Infrastructure.Extensions
{
    public static class FluentModelBuilderExtension
    {
        public static void ConfigTable(this ModelBuilder builder)
        {
            builder.Entity<Order>()
                .HasMany<OrderDetail>()
                .WithOne()
                .HasForeignKey(orderDetail => orderDetail.Id);
              
        }
    }
}