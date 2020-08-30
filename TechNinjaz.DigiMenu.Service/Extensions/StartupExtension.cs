using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TechNinjaz.DigiMenu.Repository;
using TechNinjaz.DigiMenu.Repository.Extensions;
using TechNinjaz.DigiMenu.Service.Interface;

namespace TechNinjaz.DigiMenu.Service.Extensions
{
    public static class StartupExtension
    {
        public static void InjectServicesDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDefaultDatabaseContext(configuration);

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(IGenericService<>), typeof(GenericService<>));
            services.AddScoped(typeof(OrderStatusService));
            services.AddScoped(typeof(MenuItemService));
            services.AddScoped(typeof(OrderService));
            services.AddScoped(typeof(MenuService));
            services.AddScoped(typeof(UserService));
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

        public static bool IsSwagger(this HttpContext context, string endpoint)
        {
            return !context.Request.Path.Value.StartsWith(endpoint, StringComparison.OrdinalIgnoreCase);
        }
    }
}
