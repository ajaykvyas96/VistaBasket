using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vistabasket.Inventory.Service.Model;
using Vistabasket.Inventory.Service.Model.Supplier;

namespace Vistabasket.Inventory.Service.Interface
{
    public interface ISupplierService
    {
        Task<ResponseDto<SupplierDto>> Create(SupplierDto brand);
        Task<ResponseDto<SupplierDto>> Update(string id, SupplierDto brand);
        Task<ResponseDto<List<SupplierDto>>> GetAll();
        Task<ResponseDto<SupplierDto>> Get(string id);
    }
}
