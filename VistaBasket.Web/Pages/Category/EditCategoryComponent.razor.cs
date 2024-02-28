using Microsoft.AspNetCore.Components;
using VistaBasket.Web.Models.Catalog;

namespace VistaBasket.Web.Pages.Category
{
    public partial class EditCategoryComponent
    {
        [Parameter]
        public string Id { get; set; }
        private CategoryDto categoryDto = new CategoryDto();

        protected override async Task OnInitializedAsync()
        {
            categoryDto = await _categoryService.Get(Id);
            //NavigationManager.NavigateTo("/login");
        }
    }
}
