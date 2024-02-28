using VistaBasket.Web.Models;

namespace VistaBasket.Web.IServices
{
    public interface IBaseService
    {
        Task<ResponseDto?> SendAsync(RequestDto requestDto, bool withBearer = true);
    }
}
