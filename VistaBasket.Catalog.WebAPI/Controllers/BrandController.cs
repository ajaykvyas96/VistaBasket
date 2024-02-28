using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VistaBasket.Catalog.Service.Interface;
using VistaBasket.Catalog.Service.Model;
using VistaBasket.Catalog.Service.Model.Brand;

namespace VistaBasket.Catalog.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BrandController : ControllerBase
    {
        private readonly IBrandService _brandService;
        private ResponseDto _response;
        public BrandController(IBrandService brandService)
        {
            _brandService = brandService;
            _response = new ResponseDto();
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _brandService.GetAll());
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            return Ok(await _brandService.Get(id));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] BrandDto brand)
        {
            return Ok(await _brandService.Create(brand));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, [FromBody] BrandDto brand)
        {
            return Ok(await _brandService.Update(id, brand));
            
        }
    }
}
