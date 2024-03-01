using VistaBasket.Web.Models;
using VistaBasket.Web.Models.Catalog;

namespace VistaBasket.Web.IServices
{
    public interface IProductService
    {
        Task<ResponseDto> Create(ProductDto productDto);
        Task<ResponseDto> Update(string id, ProductDto productDto);
        Task<List<ProductResponseDto>> GetAll();
        Task<ProductDto> Get(string id);
    }
}
