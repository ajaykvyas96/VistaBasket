using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using VistaBasket.Web.IServices;
using VistaBasket.Web.Models;
using VistaBasket.Web.Models.Catalog;
using VistaBasket.Web.Models.Enums;
using VistaBasket.Web.Utility;

namespace VistaBasket.Web.Services
{
    public class ProductService : IProductService
    {
        private readonly IBaseService _baseService;
        public ProductService(IBaseService baseService)
        {

            _baseService = baseService;

        }
        public async Task<ResponseDto> Create([FromForm] ProductDto productDto)
        {
            var result = await _baseService.SendAsync(new RequestDto
            {
                ApiType = ApiType.POST,
                Data = productDto,
                Url = BaseUrls.CatalogAPIBase + "api/Product",
                ContentType = ContentType.MultipartFormData
            });
            return result;
        }
        public async Task<ResponseDto> Update(string id, ProductDto ProductDto)
        {
            var result = await _baseService.SendAsync(new RequestDto
            {
                ApiType = ApiType.PUT,
                Data = ProductDto,
                Url = BaseUrls.CatalogAPIBase + "api/Product/" + id,
            });
            return result;
        }

        public async Task<List<ProductResponseDto>> GetAll()
        {
            var productResponse = await _baseService.SendAsync(new RequestDto
            {
                ApiType = ApiType.GET,
                Url = BaseUrls.CatalogAPIBase + "api/Product",
            });
            if (productResponse.IsSuccess)
            {
                var productResult = JsonConvert.DeserializeObject<List<ProductResponseDto>>(productResponse?.Result.ToString());
                return productResult;
            }
            return new List<ProductResponseDto>();
        }

        public async Task<ProductDto> Get(string id)
        {
            var productResponse = await _baseService.SendAsync(new RequestDto
            {
                ApiType = ApiType.GET,
                Url = BaseUrls.CatalogAPIBase + "api/Product/" + id,
            });
            if (productResponse.IsSuccess)
            {
                var productResult = JsonConvert.DeserializeObject<ProductDto>(productResponse?.Result.ToString());
                return productResult;
            }
            return new ProductDto();
        }
    }
}
