using Microsoft.AspNetCore.Components;
using VistaBasket.Web.Models.Catalog;

namespace VistaBasket.Web.Pages.Product
{
    public partial class ProductsComponent
    {
        private List<ProductResponseDto> products = new List<ProductResponseDto>();
        [Inject]
        NavigationManager NavigationManager { get; set; }
        protected override async Task OnInitializedAsync()
        {
            products = await _productService.GetAll();
            //NavigationManager.NavigateTo("/login");
        }

        private async Task NavigateToEdit(string id)
        {
            NavigationManager.NavigateTo($"/editproduct/{id}");
        }

        private async Task NavigateToAdd()
        {
            NavigationManager.NavigateTo("/addproduct");
        }
    }
}
