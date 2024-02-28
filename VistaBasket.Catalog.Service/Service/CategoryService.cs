using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VistaBasket.Catalog.Entities.Entities;
using VistaBasket.Catalog.Repository.Interface;
using VistaBasket.Catalog.Service.Interface;
using VistaBasket.Catalog.Service.Model;
using VistaBasket.Catalog.Service.Model.Category;

namespace VistaBasket.Catalog.Service.Service
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        public CategoryService(IUnitOfWork unitOfWork, IMapper mapper, IUserService userService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _userService = userService;

        }
        public async Task<ResponseDto<CategoryDto>> Create(CategoryDto categoryDto)
        {
            var category = _mapper.Map<CategoryDto, Category>(categoryDto);
            await _unitOfWork.Repository<Category>().AddAsync(category, "");
            await _unitOfWork.Complete(_userService.GetCurrentUserId());

            return new ResponseDto<CategoryDto>()
            {
                Result = categoryDto,
                Message = "Record created successfully."
            };
        }

        public async Task<ResponseDto<List<CategoryDto>>> GetAll()
        {
            var result = await _unitOfWork.Repository<Category>().ListAllAsync();
            var categories = _mapper.Map<IReadOnlyList<Category>, List<CategoryDto>>(result);
            return new ResponseDto<List<CategoryDto>>()
            {
                Result = categories
            };
        }

        public async Task<ResponseDto<CategoryDto>> Get(string id)
        {
            var category = await _unitOfWork.Repository<Category>().GetSingleItemsAsync(x => x.Id == new Guid(id));
            var categoryDto = _mapper.Map<Category, CategoryDto>(category);
            return new ResponseDto<CategoryDto>()
            {
                Result = categoryDto
            };
        }

        public async Task<ResponseDto<CategoryDto>> Update(string id, CategoryDto categoryDto)
        {
            var existingCategory = await _unitOfWork.Repository<Category>().GetSingleItemsAsync(x => x.Id == new Guid(id));
            var category = _mapper.Map<CategoryDto, Category>(categoryDto, existingCategory);

            await _unitOfWork.Repository<Category>().UpdateAsync(category, "");
            await _unitOfWork.Complete(_userService.GetCurrentUserId());

            return new ResponseDto<CategoryDto>()
            {
                Result = categoryDto,
                Message = "Record updated successfully."
            };
        }
    }
}
