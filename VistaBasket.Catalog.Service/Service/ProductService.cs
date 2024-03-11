using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VistaBasket.Catalog.Data;
using VistaBasket.Catalog.Entities.Entities;
//using VistaBasket.Catalog.Repository.Interface;
using VistaBasket.Catalog.Service.Extensions;
using VistaBasket.Catalog.Service.Interface;
using VistaBasket.Catalog.Service.Model;
using VistaBasket.Catalog.Service.Model.Product;
using VistaBasket.Common.Repository;

namespace VistaBasket.Catalog.Service.Service
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork<CatalogDbContext> _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        public ProductService(IUnitOfWork<CatalogDbContext> unitOfWork, IMapper mapper, IUserService userService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _userService = userService;
        }
        public async Task<ResponseDto<ProductDto>> Create(ProductDto ProductDto)
        {
            var product = _mapper.Map<ProductDto, Product>(ProductDto);
            product.ImageBlob = ProductDto.ProductImage.ReadFileContentAsByteArray();
            product.ImageName = ProductDto.ProductImage.Name;
            await _unitOfWork.Repository<Product>().AddAsync(product, "");
            await _unitOfWork.Complete();
            //await _unitOfWork.Complete(_userService.GetCurrentUserId());

            return new ResponseDto<ProductDto>()
            {
                Result = ProductDto,
                Message = "Record created successfully."
            };
        }

        public async Task<ResponseDto<List<ProductResponseDto>>> GetAll()
        {
            var result = await _unitOfWork.Repository<Product>().ListAllAsync();
            var products = _mapper.Map<IReadOnlyList<Product>, List<ProductResponseDto>>(result);
            return new ResponseDto<List<ProductResponseDto>>()
            {
                Result = products
            };
        }

        public async Task<ResponseDto<ProductDto>> Get(string id)
        {
            var product = await _unitOfWork.Repository<Product>().GetSingleItemsAsync(x => x.Id == new Guid(id));
            var ProductDto = _mapper.Map<Product, ProductDto>(product);
            return new ResponseDto<ProductDto>()
            {
                Result = ProductDto
            };
        }

        public async Task<ResponseDto<ProductDto>> Update(string id, ProductDto productDto)
        {
            var existingProduct = await _unitOfWork.Repository<Product>().GetSingleItemsAsync(x => x.Id == new Guid(id));
            var product = _mapper.Map<ProductDto, Product>(productDto, existingProduct);

            await _unitOfWork.Repository<Product>().UpdateAsync(product, "");
            await _unitOfWork.Complete();
            //await _unitOfWork.Complete(_userService.GetCurrentUserId());

            return new ResponseDto<ProductDto>()
            {
                Result = productDto,
                Message = "Record updated successfully."
            };
        }
    }
}
