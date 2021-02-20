using Microsoft.AspNetCore.Builder;
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
            services.AddScoped(typeof(IJwtFactory), typeof(JwtFactoryService));
        }

        public static void AddDefaultDatabaseContext(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<RestaurantDbContext>(op
                => op.UseLazyLoadingProxies()
                    .UseSqlServer(config.GetConnectionString("DefaultConnection"), sql
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