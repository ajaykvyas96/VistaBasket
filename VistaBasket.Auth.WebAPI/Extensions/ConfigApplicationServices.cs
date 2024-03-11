using Microsoft.AspNetCore.HttpsPolicy;
using VistaBasket.Auth.Service.Interface;
using VistaBasket.Auth.Service.Service;
using VistaBasket.Auth.WebAPI.Middleware;

namespace VistaBasket.Auth.WebAPI.Extensions
{
    public static class ConfigApplicationServices
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IAuthService, AuthService>();
            services.AddSingleton<IMessageBus, MessageBus>();
            services.AddScoped<IJwtAuthManager, JwtAuthManager>();
            services.AddTransient<ExceptionHandlingMiddleware>();

            return services;
        }
    }
}
