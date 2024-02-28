using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VistaBasket.Catalog.Service.Model;
using VistaBasket.Catalog.Service.Model.Product;

namespace VistaBasket.Catalog.Service.Interface
{
    public interface IProductService
    {
        Task<ResponseDto<ProductDto>> Create(ProductDto productDto);
        Task<ResponseDto<ProductDto>> Update(string id, ProductDto productDto);
        Task<ResponseDto<List<ProductDto>>> GetAll();
        Task<ResponseDto<ProductDto>> Get(string id);
    }
}
