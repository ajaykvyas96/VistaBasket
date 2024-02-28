using Microsoft.AspNetCore.Components.Authorization;
using VistaBasket.Web.IServices;
using VistaBasket.Web.Providers;
using VistaBasket.Web.Services;
using VistaBasket.Web.Utility;

namespace VistaBasket.Web.Extensions
{
    public static class ConfigApplicationServices
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IBaseService, BaseService>();
            services.AddScoped<ILocalStorageService, LocalStorageService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IBrandService, BrandService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ApiAuthenticationStateProvider>();
            services.AddScoped<AuthenticationStateProvider>(sp => sp.GetRequiredService<ApiAuthenticationStateProvider>());
            //services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7060/") });
            BaseUrls.AuthAPIBase = "https://localhost:7250/";
            BaseUrls.CatalogAPIBase = "https://localhost:7275/";
            BaseUrls.OrderAPIBase = "https://localhost:44365";
            return services;
        }
    }
}
