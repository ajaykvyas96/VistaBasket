using VistaBasket.Catalog.Data;
using VistaBasket.Catalog.Service.Interface;
using VistaBasket.Catalog.Service.Service;
using VistaBasket.Catalog.WebAPI.Middleware;
using VistaBasket.Common.Repository;

namespace VistaBasket.Catalog.WebAPI.Extensions
{
    public static class ConfigApplicationServices
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork<CatalogDbContext>, UnitOfWork<CatalogDbContext>>();
            services.AddScoped<IBrandService, BrandService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IUserService, UserService>();

            services.AddScoped<CurrentUserMiddleware>();
            services.AddTransient<ExceptionHandlingMiddleware>();
            services.AddHttpContextAccessor();

            return services;
        }
    }
}
