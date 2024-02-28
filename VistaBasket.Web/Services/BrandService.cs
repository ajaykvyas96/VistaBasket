using Newtonsoft.Json;
using VistaBasket.Web.IServices;
using VistaBasket.Web.Models;
using VistaBasket.Web.Models.Catalog;
using VistaBasket.Web.Models.Enums;
using VistaBasket.Web.Utility;

namespace VistaBasket.Web.Services
{
    public class BrandService : IBrandService
    {
        private readonly IBaseService _baseService;
        public BrandService(IBaseService baseService)
        {

            _baseService = baseService;

        }
        public async Task<ResponseDto> Create(BrandDto brand)
        {
            var result = await _baseService.SendAsync(new RequestDto
            {
                ApiType = ApiType.POST,
                Data = brand,
                Url = BaseUrls.CatalogAPIBase + "api/Brand"
            });
            return result;
        }
        public async Task<ResponseDto> Update(string id, BrandDto brand)
        {
            var result = await _baseService.SendAsync(new RequestDto
            {
                ApiType = ApiType.PUT,
                Data = brand,
                Url = BaseUrls.CatalogAPIBase + "api/Brand/" + id,
            });
            return result;
        }

        public async Task<List<BrandDto>> GetAll()
        {
            var brandResponse = await _baseService.SendAsync(new RequestDto
            {
                ApiType = ApiType.GET,
                Url = BaseUrls.CatalogAPIBase + "api/Brand",
            });
            if (brandResponse.IsSuccess)
            {
                var brandResult = JsonConvert.DeserializeObject<List<BrandDto>>(brandResponse?.Result.ToString());
                return brandResult;
            }
            return new List<BrandDto>();
        }

        public async Task<BrandDto> GetBrand(string id)
        {
            var brandResponse = await _baseService.SendAsync(new RequestDto
            {
                ApiType = ApiType.GET,
                Url = BaseUrls.CatalogAPIBase + "api/Brand/" + id,
            });
            if (brandResponse.IsSuccess)
            {
                var brandResult = JsonConvert.DeserializeObject<BrandDto>(brandResponse?.Result.ToString());
                return brandResult;
            }
            return new BrandDto();
        }
    }
}
