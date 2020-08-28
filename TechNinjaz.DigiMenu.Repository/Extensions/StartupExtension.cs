using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TechNinjaz.DigiMenu.Repository.Context;

namespace TechNinjaz.DigiMenu.Repository.Extensions
{
    public static class StartupExtension
    {
       public static void AddDefaultDatabaseContext(this IServiceCollection services, IConfiguration configuration)
        {
            var migrationsAssemblyName = typeof(ApplicationDbContext).GetTypeInfo().Assembly.GetName().Name;
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<ApplicationDbContext>(op
                => op.UseSqlite(connectionString, sql
                    => sql.MigrationsAssembly(migrationsAssemblyName))
                );
        }

    }
}
