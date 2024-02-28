using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VistaBasket.Catalog.Service.Model;
using VistaBasket.Catalog.Service.Model.Category;

namespace VistaBasket.Catalog.Service.Interface
{
    public interface ICategoryService
    {
        Task<ResponseDto<CategoryDto>> Create(CategoryDto categoryDto);
        Task<ResponseDto<CategoryDto>> Update(string id, CategoryDto categoryDto);
        Task<ResponseDto<List<CategoryDto>>> GetAll();
        Task<ResponseDto<CategoryDto>> Get(string id);
    }
}
