using Microsoft.AspNetCore.Components;
using VistaBasket.Web.Models.Catalog;

namespace VistaBasket.Web.Pages.Category
{
    public partial class CategoriesComponent
    {
        private List<CategoryDto> categories = new List<CategoryDto>();
        [Inject]
        NavigationManager NavigationManager { get; set; }
        protected override async Task OnInitializedAsync()
        {
            categories = await _categoryService.GetAll();
            //NavigationManager.NavigateTo("/login");
        }

        private async Task NavigateToEdit(string id)
        {
            NavigationManager.NavigateTo($"/editcategory/{id}");
        }

        private async Task NavigateToAdd()
        {
            NavigationManager.NavigateTo("/addcategory");
        }
    }
}
