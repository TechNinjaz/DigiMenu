
using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace TechNinjaz.DigiMenu.Infrastructure.Extensions
{
    public static class SwaggerExtension
    {
        public static void AddSwaggerDoc(this IServiceCollection services, IConfiguration config)
        {
            services.AddSwaggerGen(sw => {
                sw.SwaggerDoc("v1", new OpenApiInfo {Title = config["ApplicationName"]});
            });
        }

        public static void SwaggerConfig(this IApplicationBuilder app, IConfiguration config , IWebHostEnvironment env)
        {
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", config["ApplicationName"]);
            });
  
            app.MapWhen(context=> context.IsSwagger("/swagger"),
                builder  => builder.SetAngularSpa(env));
        }

        private static void SetAngularSpa(this IApplicationBuilder builder, IHostEnvironment env)
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

        private static bool IsSwagger(this HttpContext context, string endpoint)
        {
            return !context.Request.Path.Value.StartsWith(endpoint, StringComparison.OrdinalIgnoreCase);
        }
    }
}