using System;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
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
            var migrationsAssemblyName = typeof(RestaurantDbContext).Assembly.GetName().Name;

            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<RestaurantDbContext>(op
                    => op.UseSqlite(connectionString, sql
                        => sql.MigrationsAssembly(migrationsAssemblyName)));
        }
        
        public static void SetAngularSpa(this IApplicationBuilder builder, IWebHostEnvironment env)
        {
            builder.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";
                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });
        }
        
        public static async void EnsureMigrationsRunAsync(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<RestaurantDbContext>();
            await context.Database.MigrateAsync();
        }

        public static bool IsSwagger(this HttpContext context, string endpoint)
        {
            return !context.Request.Path.Value.StartsWith(endpoint, StringComparison.OrdinalIgnoreCase);
        }
    }
}
