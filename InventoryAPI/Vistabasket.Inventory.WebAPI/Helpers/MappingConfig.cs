using AutoMapper;

namespace Vistabasket.Inventory.WebAPI.Helpers
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                //config.CreateMap<Brand, BrandDto>().ReverseMap();
                //config.CreateMap<Category, CategoryDto>().ReverseMap();
                //config.CreateMap<Product, ProductDto>().ReverseMap();
                //config.CreateMap<Product, ProductResponseDto>().ReverseMap();
            });

            return mappingConfig;
        }
    }
}
