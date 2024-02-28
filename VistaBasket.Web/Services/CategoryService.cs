using Newtonsoft.Json;
using VistaBasket.Web.IServices;
using VistaBasket.Web.Models;
using VistaBasket.Web.Models.Catalog;
using VistaBasket.Web.Models.Enums;
using VistaBasket.Web.Utility;

namespace VistaBasket.Web.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IBaseService _baseService;
        public CategoryService(IBaseService baseService)
        {

            _baseService = baseService;

        }
        public async Task<ResponseDto> Create(CategoryDto categoryDto)
        {
            var result = await _baseService.SendAsync(new RequestDto
            {
                ApiType = ApiType.POST,
                Data = categoryDto,
                Url = BaseUrls.CatalogAPIBase + "api/Category"
            });
            return result;
        }
        public async Task<ResponseDto> Update(string id, CategoryDto categoryDto)
        {
            var result = await _baseService.SendAsync(new RequestDto
            {
                ApiType = ApiType.PUT,
                Data = categoryDto,
                Url = BaseUrls.CatalogAPIBase + "api/Category/" + id,
            });
            return result;
        }

        public async Task<List<CategoryDto>> GetAll()
        {
            var categoryResponse = await _baseService.SendAsync(new RequestDto
            {
                ApiType = ApiType.GET,
                Url = BaseUrls.CatalogAPIBase + "api/Category",
            });
            if (categoryResponse.IsSuccess)
            {
                var categoryResult = JsonConvert.DeserializeObject<List<CategoryDto>>(categoryResponse?.Result.ToString());
                return categoryResult;
            }
            return new List<CategoryDto>();
        }

        public async Task<CategoryDto> Get(string id)
        {
            var categoryResponse = await _baseService.SendAsync(new RequestDto
            {
                ApiType = ApiType.GET,
                Url = BaseUrls.CatalogAPIBase + "api/Category/" + id,
            });
            if (categoryResponse.IsSuccess)
            {
                var categoryResult = JsonConvert.DeserializeObject<CategoryDto>(categoryResponse?.Result.ToString());
                return categoryResult;
            }
            return new CategoryDto();
        }
    }
}
