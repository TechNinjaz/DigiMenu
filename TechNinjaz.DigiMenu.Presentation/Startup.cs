using System;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TechNinjaz.DigiMenu.Domain.DTO;
using TechNinjaz.DigiMenu.Repository;
using TechNinjaz.DigiMenu.Repository.Extensions;
using TechNinjaz.DigiMenu.Service;
using TechNinjaz.DigiMenu.Service.Extensions;

namespace TechNinjaz.DigiMenu.Presentation
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        private IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(Startup));
            services.InjectServicesDependencies(Configuration);
            services.AddMvc(options => options.EnableEndpointRouting = false);;
            services.AddControllersWithViews();
            services.AddSpaStaticFiles(config =>
            {
                config.RootPath = "ClientApp/dist";
            });
            services.AddSwaggerGen();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IConfiguration configuration)
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
                options.SwaggerEndpoint("/swagger/v1/swagger.json", configuration["ApplicationName"]);
            });

            app.UseRouting();
            app.UseMvc(routes =>
            {
                routes.MapRoute( "default",  "{controller}/{action=Index}/{id?}");
            });
            app.MapWhen(context=> context.IsSwagger("/swagger"),
                     builder  => builder.SetAngularSpa(env));

        }
    }
}