using Microsoft.AspNetCore.Components;
using VistaBasket.Web.Models.Auth;

namespace VistaBasket.Web.Pages.Auth
{
    public partial class LoginComponent
    {
        private LoginRequestDto loginModel = new LoginRequestDto();
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        private string errorMessage;
        private async Task HandleSubmit()
        {
            try
            {
                var loginResponse = await _authService.Login(loginModel);
                if (!loginResponse.IsSuccess)
                {
                    errorMessage = loginResponse.Message;
                }
                else
                {
                    NavigationManager.NavigateTo("/");
                }
            }
            catch (Exception ex)
            {
                errorMessage = "An error occurred while processing your request.";
                // Log the exception or handle it as needed
            }
        }
    }
}
