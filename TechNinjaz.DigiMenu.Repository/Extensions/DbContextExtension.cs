using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TechNinjaz.DigiMenu.Domain;
using TechNinjaz.DigiMenu.Domain.DTO;

namespace TechNinjaz.DigiMenu.Repository.Extensions
{
    public static class DbContextExtension
    {
        public static void ChangeIdentityTableNames(this ModelBuilder builder)
        {
            builder.Entity<User>().Property(p => p.Id).HasColumnName("UserId");
            builder.Entity<IdentityRole>().ToTable(nameof(IdentityRole));
        } 
    }
}