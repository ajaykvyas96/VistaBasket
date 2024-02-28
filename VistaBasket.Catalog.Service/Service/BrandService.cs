using AutoMapper;
using Azure.Core;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VistaBasket.Catalog.Entities.Entities;
using VistaBasket.Catalog.Repository.Interface;
using VistaBasket.Catalog.Service.Interface;
using VistaBasket.Catalog.Service.Model;
using VistaBasket.Catalog.Service.Model.Brand;

namespace VistaBasket.Catalog.Service.Service
{
    public class BrandService : IBrandService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        public BrandService(IUnitOfWork unitOfWork, IMapper mapper, IUserService userService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _userService = userService;

        }
        public async Task<ResponseDto<BrandDto>> Create(BrandDto brandDto)
        {
            var brand = _mapper.Map<BrandDto, Brand>(brandDto);
            //brand.CreatedBy = "Admin";
            await _unitOfWork.Repository<Brand>().AddAsync(brand, "");
            await _unitOfWork.Complete(_userService.GetCurrentUserId());

            return new ResponseDto<BrandDto>()
            {
                Result = brandDto,
                Message = "Record created successfully."               
            };
        }

        public async Task<ResponseDto<List<BrandDto>>> GetAll()
        {
            var result = await _unitOfWork.Repository<Brand>().ListAllAsync();
            var brands = _mapper.Map<IReadOnlyList<Brand>, List<BrandDto>>(result);
            return new ResponseDto<List<BrandDto>>()
            {
                Result = brands
            };
        }

        public async Task<ResponseDto<BrandDto>> Get(string id)
        {
            var brand = await _unitOfWork.Repository<Brand>().GetSingleItemsAsync(x => x.Id == new Guid(id));
            var brandDto = _mapper.Map<Brand, BrandDto>(brand);
            return new ResponseDto<BrandDto>()
            {
                Result = brandDto
            };
        }

        public async Task<ResponseDto<BrandDto>> Update(string id, BrandDto brandDto)
        {
            var existingBrand = await _unitOfWork.Repository<Brand>().GetSingleItemsAsync(x => x.Id == new Guid(id));
            var brand = _mapper.Map<BrandDto, Brand>(brandDto, existingBrand);

            await _unitOfWork.Repository<Brand>().UpdateAsync(brand, "");
            await _unitOfWork.Complete(_userService.GetCurrentUserId());

            return new ResponseDto<BrandDto>()
            {
                Result = brandDto,
                Message = "Record updated successfully."
            };
        }
    }
}
