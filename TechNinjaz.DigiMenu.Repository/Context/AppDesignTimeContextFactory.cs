using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace TechNinjaz.DigiMenu.Repository.Context
{
    public class AppDesignTimeContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {

        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var migrationsAssemblyName = typeof(ApplicationDbContext).Assembly.GetName().Name;
            
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseSqlite(GetConnectionString(), sql
                => sql.MigrationsAssembly(migrationsAssemblyName));

            return new ApplicationDbContext(optionsBuilder.Options);
        }

        private static string GetConnectionString()
        {
            var environment = Environment.GetEnvironmentVariable("ConnectionString");
            var basePath =Path.Combine(Directory.GetCurrentDirectory(), "../TechNinjaz.DigiMenu.Presentation");
            // Build config
            return new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{environment}.json", optional: true)
                .AddEnvironmentVariables()
                .Build()
                .GetConnectionString("DefaultConnection");
            
        }
    }
    
}