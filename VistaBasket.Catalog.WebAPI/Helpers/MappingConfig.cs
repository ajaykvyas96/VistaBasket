using AutoMapper;
using VistaBasket.Catalog.Entities.Entities;
using VistaBasket.Catalog.Service.Model.Brand;
using VistaBasket.Catalog.Service.Model.Category;
using VistaBasket.Catalog.Service.Model.Product;

namespace VistaBasket.Catalog.WebAPI.Helpers
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<Brand, BrandDto>().ReverseMap();
                config.CreateMap<Category, CategoryDto>().ReverseMap();
                config.CreateMap<Product, ProductDto>().ReverseMap();
            });

            return mappingConfig;
        }
    }
}
