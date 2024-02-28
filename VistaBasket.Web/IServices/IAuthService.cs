using VistaBasket.Web.Models;
using VistaBasket.Web.Models.Auth;

namespace VistaBasket.Web.IServices
{
    public interface IAuthService
    {
        Task<ResponseDto> Register(RegistrationRequestDto registrationRequestDto);
        Task<ResponseDto<LoginResponseDto>> Login(LoginRequestDto login);
        Task Logout();
    }
}
