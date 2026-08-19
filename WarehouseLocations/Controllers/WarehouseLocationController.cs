using Microsoft.AspNetCore.Mvc;
using Marketplacesellerportal.Models;
using Marketplacesellerportal.WarehouseLocations.Interfaces;

namespace Marketplacesellerportal.WarehouseLocations.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WarehouseLocationController : ControllerBase
    {
        private readonly IWarehouseLocationService _service;

        public WarehouseLocationController(IWarehouseLocationService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpGet("{locationId}")]
        public async Task<IActionResult> Get(int locationId)
        {
            var result = await _service.GetByIdAsync(locationId);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpGet("warehouse/{warehouseId}")]
        public async Task<IActionResult> GetByWarehouse(int warehouseId)
        {
            return Ok(await _service.GetByWarehouseIdAsync(warehouseId));
        }

        [HttpGet("{warehouseId}/{locationId}")]
        public async Task<IActionResult> GetLocation(int warehouseId, int locationId,int customerId)
        {
            var result = await _service.GetLocationAsync(warehouseId,customerId,locationId);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(WarehouseLocation location)
        {
            return Ok(await _service.CreateAsync(location));
        }

        [HttpPut("{locationId}")]
        public async Task<IActionResult> Update(int locationId, WarehouseLocation location)
        {
            if (!await _service.UpdateAsync(locationId, location))
                return NotFound();

            return Ok();
        }

        [HttpDelete("{locationId}")]
        public async Task<IActionResult> Delete(int locationId)
        {
            if (!await _service.DeleteAsync(locationId))
                return NotFound();

            return Ok();
        }
    }
}
