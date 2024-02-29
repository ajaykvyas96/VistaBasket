using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VistaBasket.Catalog.Service.Interface;
using VistaBasket.Catalog.Service.Model.Product;

namespace VistaBasket.Catalog.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService brandService)
        {
            _productService = brandService;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _productService.GetAll());
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            return Ok(await _productService.Get(id));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromForm] ProductDto brand)
        {
            return Ok(await _productService.Create(brand));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, [FromBody] ProductDto brand)
        {
            return Ok(await _productService.Update(id, brand));
        }
    }
}
