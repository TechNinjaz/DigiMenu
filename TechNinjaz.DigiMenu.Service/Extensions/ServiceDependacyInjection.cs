using Microsoft.Extensions.DependencyInjection;
using TechNinjaz.DigiMenu.Repository;

namespace TechNinjaz.DigiMenu.Service.Extensions
{
    public static class ServiceDependencyInjection
    {
        public static IServiceCollection InjectServicesDependency(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(IService<>), typeof(Service<>));
         
            return services;
        }
    }
}