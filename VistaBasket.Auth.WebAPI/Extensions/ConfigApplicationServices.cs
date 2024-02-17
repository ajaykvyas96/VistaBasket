using VistaBasket.Auth.Repository.Interface;
using VistaBasket.Auth.Repository.Service;
using VistaBasket.Auth.Service.Interface;
using VistaBasket.Auth.Service.Service;

namespace VistaBasket.Auth.WebAPI.Extensions
{
    public static class ConfigApplicationServices
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IAuthService, AuthService>();
            return services;
        }
    }
}
