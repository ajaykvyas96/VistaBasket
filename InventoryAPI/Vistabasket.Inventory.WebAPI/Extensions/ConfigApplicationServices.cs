using Vistabasket.Inventory.Data;
using Vistabasket.Inventory.Service.Interface;
using Vistabasket.Inventory.Service.Service;
using Vistabasket.Inventory.WebAPI.Middleware;
using VistaBasket.Common.Repository;

namespace Vistabasket.Inventory.WebAPI.Extensions
{
    public static class ConfigApplicationServices
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork<InventoryDbContext>, UnitOfWork<InventoryDbContext>>();
            
            services.AddScoped<IInventoryService, InventoryService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<CurrentUserMiddleware>();
            services.AddTransient<ExceptionHandlingMiddleware>();
            services.AddHttpContextAccessor();

            return services;
        }
    }
}
