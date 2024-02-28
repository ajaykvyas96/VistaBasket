using Microsoft.AspNetCore.Components;
using VistaBasket.Web.Models.Catalog;

namespace VistaBasket.Web.Pages.brand
{
    public partial class BrandFormComponent
    {
        //private BrandDto brandDto = new BrandDto();
        [Parameter]
        public BrandDto BrandDto { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        private string errorMessage;
        private string successMessage;
        private async Task HandleSubmit()
        {
            try
            {
                if (!string.IsNullOrEmpty(BrandDto.Id))
                {
                    var result = await _brandService.Update(BrandDto.Id, BrandDto);
                    if(!result.IsSuccess)
                    {
                        errorMessage = result.Message;
                    }
                    else
                    {
                        successMessage = result.Message;
                    }
                }
                else
                {
                    var result = await _brandService.Create(BrandDto);
                    if (!result.IsSuccess)
                    {
                        errorMessage = result.Message;
                    }
                    else
                    {
                        successMessage = result.Message;
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        private async Task NavigateToBack()
        {
            NavigationManager.NavigateTo("/brands");
        }
    }
}
