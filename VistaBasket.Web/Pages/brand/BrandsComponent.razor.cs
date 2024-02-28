using Microsoft.AspNetCore.Components;
using VistaBasket.Web.Models.Catalog;

namespace VistaBasket.Web.Pages.brand
{
    public partial class BrandsComponent
    {
        private List<BrandDto> brands = new List<BrandDto>();
        [Inject]
        NavigationManager NavigationManager { get; set; }
        protected override async Task OnInitializedAsync()
        {
            brands = await _brandService.GetAll();
            //NavigationManager.NavigateTo("/login");
        }

        private async Task NavigateToEdit(string id)
        {
            NavigationManager.NavigateTo($"/editbrand/{id}");
        }

        private async Task NavigateToAdd()
        {
            NavigationManager.NavigateTo("/addbrand");
        }
    }
}
