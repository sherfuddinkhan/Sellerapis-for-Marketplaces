using Microsoft.AspNetCore.Mvc;
using Marketplacesellerportal.Models;
using Marketplacesellerportal.Warehouses.Interfaces;

namespace Marketplacesellerportal.Warehouses.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WarehouseController : ControllerBase
    {
        private readonly IWarehouseService _service;

        public WarehouseController(IWarehouseService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpGet("{warehouseId}")]
        public async Task<IActionResult> Get(int warehouseId)
        {
            var warehouse = await _service.GetByIdAsync(warehouseId);

            if (warehouse == null)
                return NotFound();

            return Ok(warehouse);
        }

        [HttpGet("seller/{sellerId}")]
        public async Task<IActionResult> GetBySeller(int sellerId)
        {
            return Ok(await _service.GetBySellerIdAsync(sellerId));
        }

        [HttpGet("{sellerId}/{warehouseId}")]
        public async Task<IActionResult> GetWarehouse(int sellerId, int warehouseId)
        {
            var warehouse = await _service.GetWarehouseAsync(sellerId, warehouseId);

            if (warehouse == null)
                return NotFound();

            return Ok(warehouse);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Warehouse warehouse)
        {
            return Ok(await _service.CreateAsync(warehouse));
        }

        [HttpPut("{warehouseId}")]
        public async Task<IActionResult> Update(int warehouseId, Warehouse warehouse)
        {
            if (!await _service.UpdateAsync(warehouseId, warehouse))
                return NotFound();

            return Ok();
        }

        [HttpDelete("{warehouseId}")]
        public async Task<IActionResult> Delete(int warehouseId)
        {
            if (!await _service.DeleteAsync(warehouseId))
                return NotFound();

            return Ok();
        }
    }
}
