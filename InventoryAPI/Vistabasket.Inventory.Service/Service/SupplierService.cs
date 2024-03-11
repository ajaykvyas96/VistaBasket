using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vistabasket.Inventory.Data;
using Vistabasket.Inventory.Entities.Entities;
using Vistabasket.Inventory.Service.Interface;
using Vistabasket.Inventory.Service.Model;
using Vistabasket.Inventory.Service.Model.Supplier;
using VistaBasket.Common.Repository;

namespace Vistabasket.Inventory.Service.Service
{
    public class SupplierService : ISupplierService
    {
        private readonly IUnitOfWork<InventoryDbContext> _unitOfWork;
        private readonly IMapper _mapper;
        public SupplierService(IUnitOfWork<InventoryDbContext> unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<ResponseDto<SupplierDto>> Create(SupplierDto supplierDto)
        {
            var supplier = _mapper.Map<SupplierDto, Supplier>(supplierDto);
            //brand.CreatedBy = "Admin";
            await _unitOfWork.Repository<Supplier>().AddAsync(supplier, "");
            await _unitOfWork.Complete();
            //await _unitOfWork.Complete(_userService.GetCurrentUserId());

            return new ResponseDto<SupplierDto>()
            {
                Result = supplierDto,
                Message = "Record created successfully."
            };
        }

        public async Task<ResponseDto<SupplierDto>> Get(string id)
        {
            var supplier = await _unitOfWork.Repository<Supplier>().GetSingleItemsAsync(x => x.Id == new Guid(id));
            var supplierDto = _mapper.Map<Supplier, SupplierDto>(supplier);
            return new ResponseDto<SupplierDto>()
            {
                Result = supplierDto
            };
        }

        public async Task<ResponseDto<List<SupplierDto>>> GetAll()
        {
            var result = await _unitOfWork.Repository<Supplier>().ListAllAsync();
            var suppliers = _mapper.Map<IReadOnlyList<Supplier>, List<SupplierDto>>(result);
            return new ResponseDto<List<SupplierDto>>()
            {
                Result = suppliers
            };
        }

        public async Task<ResponseDto<SupplierDto>> Update(string id, SupplierDto supplierDto)
        {
            var existingSupplier = await _unitOfWork.Repository<Supplier>().GetSingleItemsAsync(x => x.Id == new Guid(id));
            var supplier = _mapper.Map<SupplierDto, Supplier>(supplierDto, existingSupplier);

            await _unitOfWork.Repository<Supplier>().UpdateAsync(supplier, "");
            //await _unitOfWork.Complete(_userService.GetCurrentUserId());
            await _unitOfWork.Complete();

            return new ResponseDto<SupplierDto>()
            {
                Result = supplierDto,
                Message = "Record updated successfully."
            };
        }
    }
}
