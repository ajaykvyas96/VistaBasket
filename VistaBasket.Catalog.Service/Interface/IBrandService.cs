using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VistaBasket.Catalog.Service.Model;
using VistaBasket.Catalog.Service.Model.Brand;

namespace VistaBasket.Catalog.Service.Interface
{
    public interface IBrandService
    {
        Task<ResponseDto<BrandDto>> Create(BrandDto brand);
        Task<ResponseDto<BrandDto>> Update(string id, BrandDto brand);
        Task<ResponseDto<List<BrandDto>>> GetAll();
        Task<ResponseDto<BrandDto>> Get(string id);
    }
}
