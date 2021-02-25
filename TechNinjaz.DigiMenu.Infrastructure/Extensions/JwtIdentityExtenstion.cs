using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using TechNinjaz.DigiMenu.Core.Entities.Identity;
using TechNinjaz.DigiMenu.Infrastructure.Context;

namespace TechNinjaz.DigiMenu.Infrastructure.Extensions
{
    public static class IdentityServiceExtenstion
    {
        public static void AddIdentityWithJwt(this IServiceCollection services, IConfiguration config)
        {
            var builder = services.AddIdentityCore<AuthUser>();

            builder = new IdentityBuilder(builder.UserType, builder.Services);
            builder.AddEntityFrameworkStores<RestaurantDbContext>();
            builder.AddSignInManager<SignInManager<AuthUser>>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"])),
                        ValidateAudience = true,
                        ValidAudience = config["Jwt:Audience"],
                        ValidIssuer = config["Jwt:Issuer"],
                        ValidateIssuer = true
                    };
                });
        }
    }
}