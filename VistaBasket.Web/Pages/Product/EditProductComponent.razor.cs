using Microsoft.AspNetCore.Components;
using VistaBasket.Web.Models.Catalog;

namespace VistaBasket.Web.Pages.Product
{
    public partial class EditProductComponent
    {
        [Parameter]
        public string Id { get; set; }
        private ProductDto productDto = new ProductDto();

        protected override async Task OnInitializedAsync()
        {
            productDto = await _productService.Get(Id);
            //NavigationManager.NavigateTo("/login");
        }
    }
}
