using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace TechNinjaz.DigiMenu.Infrastructure.Context
{
    public class DesignTimeContextFactory: IDesignTimeDbContextFactory<RestaurantDbContext>
    {
        public RestaurantDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<RestaurantDbContext>();
            optionsBuilder.UseSqlite(GetConnectionString(), sql
                => sql.MigrationsAssembly(typeof(RestaurantDbContext).Assembly.FullName));

            return new RestaurantDbContext(optionsBuilder.Options);
        }

        private static string GetConnectionString()
        {
            var environment = Environment.GetEnvironmentVariable("ConnectionString");
            // Build config
            return new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{environment}.json", optional: true)
                .AddEnvironmentVariables()
                .Build()
                .GetConnectionString("DefaultConnection");
            
        }
    }
}