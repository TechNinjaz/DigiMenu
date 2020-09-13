using System;
using Microsoft.EntityFrameworkCore;
using TechNinjaz.DigiMenu.Domain.DTO;

namespace TechNinjaz.DigiMenu.Domain.Extensions
{
    public static class FluentExtension
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