using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VistaBasket.Catalog.Service.Interface;
using VistaBasket.Catalog.Service.Model;
using VistaBasket.Catalog.Service.Model.Category;

namespace VistaBasket.Catalog.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private ResponseDto _response;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
            _response = new ResponseDto();
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _categoryService.GetAll());
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            return Ok(await _categoryService.Get(id));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CategoryDto categoryDto)
        {
            return Ok(await _categoryService.Create(categoryDto));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, [FromBody] CategoryDto categoryDto)
        {
            return Ok(await _categoryService.Update(id, categoryDto));  
        }
    }
}
