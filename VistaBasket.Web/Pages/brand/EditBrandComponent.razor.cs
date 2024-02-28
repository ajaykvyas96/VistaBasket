using Microsoft.AspNetCore.Components;
using VistaBasket.Web.Models.Catalog;

namespace VistaBasket.Web.Pages.brand
{
    public partial class EditBrandComponent
    {
        [Parameter]
        public string Id { get; set; }
        private BrandDto brandDto = new BrandDto();

        protected override async Task OnInitializedAsync()
        {
            brandDto = await _brandService.GetBrand(Id);
            //NavigationManager.NavigateTo("/login");
        }
    }
}
