using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using VistaBasket.Web.Models.Catalog;

namespace VistaBasket.Web.Pages.Product
{
    public partial class ProductFormComponent
    {
        [Parameter]
        public ProductDto ProductDto { get; set; }
        private List<CategoryDto> categories = new();
        private List<BrandDto> brands = new();
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        private string errorMessage;
        private string successMessage;

        protected async override Task OnInitializedAsync()
        {
            categories = await _categoryService.GetAll();
            brands = await _brandService.GetAll();
        }
        //private void HandleFileChange(InputFileChangeEventArgs e)
        //{
        //    // Handle the file change event and update the product's ProductImage property
        //    var file = e.File;
        //    ProductDto.ProductImage = file;
        //}

        private async Task HandleSubmit()
        {
            try
            {
                if (!string.IsNullOrEmpty(ProductDto.Id))
                {
                    var result = await _productService.Update(ProductDto.Id, ProductDto);
                    if (!result.IsSuccess)
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
                    var result = await _productService.Create(ProductDto);
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
            NavigationManager.NavigateTo("/products");
        }
    }
}
