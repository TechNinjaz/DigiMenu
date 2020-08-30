using System.Reflection;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TechNinjaz.DigiMenu.Domain.DTO;
using TechNinjaz.DigiMenu.Repository.Context;

namespace TechNinjaz.DigiMenu.Repository.Extensions
{
    public static class DbContextExtension
    {
        public static void AddDefaultDatabaseContext(this IServiceCollection services, IConfiguration configuration)
        {
            var migrationsAssemblyName = typeof(ApplicationDbContext).GetTypeInfo().Assembly.GetName().Name;
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddEntityFrameworkSqlite()
                .AddDbContext<ApplicationDbContext>(op
                    => op.UseSqlite(connectionString, sql
                        => sql.MigrationsAssembly(migrationsAssemblyName)));
        }
        public static void ChangeIdentityTableNames(this ModelBuilder builder)
        {
            builder.Entity<User>().Property(p => p.Id).HasColumnName("UserId");
            builder.Entity<IdentityRole>().ToTable(nameof(IdentityRole));
        } 
    }
}