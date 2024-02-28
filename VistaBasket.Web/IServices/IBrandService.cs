using VistaBasket.Web.Models;
using VistaBasket.Web.Models.Catalog;

namespace VistaBasket.Web.IServices
{
    public interface IBrandService
    {
        Task<ResponseDto> Create(BrandDto brand);
        Task<ResponseDto> Update(string id, BrandDto brand);
        Task<List<BrandDto>> GetAll();
        Task<BrandDto> GetBrand(string id);
    }
}
