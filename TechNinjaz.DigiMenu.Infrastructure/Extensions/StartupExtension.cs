using System;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TechNinjaz.DigiMenu.Core.Interfaces;
using TechNinjaz.DigiMenu.Infrastructure.Context;
using TechNinjaz.DigiMenu.Infrastructure.Repository;
using TechNinjaz.DigiMenu.Infrastructure.Services;

namespace TechNinjaz.DigiMenu.Infrastructure.Extensions
{
    public static class StartupExtension
    {
        public static void InjectServicesDependencies(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped(typeof(IGenericService<>), typeof(GenericService<>));
        }

        public static void AddDefaultDatabaseContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<RestaurantDbContext>(op
                    => op.UseSqlite(configuration.GetConnectionString("DefaultConnection"), sql
                        => sql.MigrationsAssembly(typeof(RestaurantDbContext).Assembly.FullName)));
        }

        public static async void EnsureMigrationsRunAsync(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<RestaurantDbContext>();
            await context.Database.MigrateAsync();
        }
    }
}
