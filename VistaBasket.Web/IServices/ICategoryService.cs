using VistaBasket.Web.Models;
using VistaBasket.Web.Models.Catalog;

namespace VistaBasket.Web.IServices
{
    public interface ICategoryService
    {
        Task<ResponseDto> Create(CategoryDto categoryDto);
        Task<ResponseDto> Update(string id, CategoryDto categoryDto);
        Task<List<CategoryDto>> GetAll();
        Task<CategoryDto> Get(string id);
    }
}
