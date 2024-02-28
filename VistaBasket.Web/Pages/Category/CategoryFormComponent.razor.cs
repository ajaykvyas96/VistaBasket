using Microsoft.AspNetCore.Components;
using VistaBasket.Web.Models.Catalog;

namespace VistaBasket.Web.Pages.Category
{
    public partial class CategoryFormComponent
    {
        [Parameter]
        public CategoryDto CategoryDto { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        private string errorMessage;
        private string successMessage;
        private async Task HandleSubmit()
        {
            try
            {
                if (!string.IsNullOrEmpty(CategoryDto.Id))
                {
                    var result = await _categoryService.Update(CategoryDto.Id, CategoryDto);
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
                    var result = await _categoryService.Create(CategoryDto);
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
            NavigationManager.NavigateTo("/categories");
        }
    }
}
