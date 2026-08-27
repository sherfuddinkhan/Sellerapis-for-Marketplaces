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
        // =====================================================
        // SEARCH
        // GET: /api/WarehouseLocation/search?search=aisle
        // =====================================================

        [HttpGet("search")]
        public async Task<IActionResult> Search(
            [FromQuery] string search)
        {
            if (string.IsNullOrWhiteSpace(search))
            {
                return BadRequest(new
                {
                    message = "Search value is required"
                });
            }

            var result = await _service.SearchAsync(search);

            return Ok(result);
        }


        // =====================================================
        // SORT
        // GET: /api/WarehouseLocation/sort?sort=name_asc
        // =====================================================

        [HttpGet("sort")]
        public async Task<IActionResult> Sort(
            [FromQuery] string? sort)
        {
            var result = await _service.GetSortedAsync(sort);

            return Ok(result);
        }


        // =====================================================
        // PAGINATION
        // GET: /api/WarehouseLocation/page?page=1&limit=15
        // =====================================================

        [HttpGet("page")]
        public async Task<IActionResult> GetPaged(
            [FromQuery] int page = 1,
            [FromQuery] int limit = 15)
        {
            if (page < 1)
                page = 1;

            if (limit < 1)
                limit = 15;

            var result = await _service.GetPagedAsync(
                page,
                limit);

            return Ok(result);
        }


        // =====================================================
        // STATISTICS
        // GET: /api/WarehouseLocation/statistics
        // =====================================================

        [HttpGet("statistics")]
        public async Task<IActionResult> GetStatistics()
        {
            var result = await _service.GetStatisticsAsync();

            return Ok(result);
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
