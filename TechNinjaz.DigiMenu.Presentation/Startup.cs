using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TechNinjaz.DigiMenu.Infrastructure.Extensions;

namespace TechNinjaz.DigiMenu.Presentation
{
    public class Startup
    {
        private readonly IConfiguration _config;

        public Startup(IConfiguration config)
        {
            _config = config;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(Startup));
            services.InjectServicesDependencies();
            services.AddDefaultDatabaseContext(_config);
            services.AddMvc(options => options.EnableEndpointRouting = false);;
            services.AddControllersWithViews();
            services.AddSpaStaticFiles(config =>
            {
                config.RootPath = "ClientApp/dist";
            });
            services.AddSwaggerGen();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            if (!env.IsDevelopment())
            {
                app.UseSpaStaticFiles();
            }
            
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", _config["ApplicationName"]);
            });

            app.UseRouting();
            app.UseMvc(routes =>
            {
                routes.MapRoute( "default",  "{controller}/{action=Index}/{id?}");
            });
            app.MapWhen(context=> context.IsSwagger("/swagger"),
                     builder  => builder.SetAngularSpa(env));

            app.EnsureMigrationsRunAsync();

        }
    }
}