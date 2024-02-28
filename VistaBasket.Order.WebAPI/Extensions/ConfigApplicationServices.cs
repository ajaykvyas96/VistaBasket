using VistaBasket.Order.WebAPI.Middleware;

namespace VistaBasket.Order.WebAPI.Extensions
{
    public static class ConfigApplicationServices
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            //services.AddScoped<IUnitOfWork, UnitOfWork>();
            //services.AddScoped<IBrandService, BrandService>();
            //services.AddScoped<IUserService, UserService>();
            services.AddTransient<ExceptionHandlingMiddleware>();
            //services.AddTransient<CurrentUserMiddleware>();

            return services;
        }
    }
}
    