using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Vistabasket.Inventory.Service.Interface;
using Vistabasket.Inventory.Service.Model;
using Vistabasket.Inventory.Service.Model.Supplier;

namespace Vistabasket.Inventory.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        private readonly ISupplierService _supplierService;
        private ResponseDto _response;
        public SupplierController(ISupplierService supplierService)
        {
            _supplierService = supplierService;
            _response = new ResponseDto();
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _supplierService.GetAll());
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            return Ok(await _supplierService.Get(id));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] SupplierDto Supplier)
        {
            return Ok(await _supplierService.Create(Supplier));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, [FromBody] SupplierDto Supplier)
        {
            return Ok(await _supplierService.Update(id, Supplier));

        }
    }
}
