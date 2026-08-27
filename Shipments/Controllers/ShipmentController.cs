using Microsoft.AspNetCore.Mvc;
using Marketplacesellerportal.Models;
using Marketplacesellerportal.Shipments.Interfaces;

namespace Marketplacesellerportal.Shipments.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShipmentController : ControllerBase
    {
        private readonly IShipmentService _service;

        public ShipmentController(IShipmentService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _service.GetByIdAsync(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpGet("order/{orderId}")]
        public async Task<IActionResult> GetByOrder(int orderId)
        {
            return Ok(await _service.GetByOrderAsync(orderId));
        }

        [HttpGet("status/{status}")]
        public async Task<IActionResult> GetByStatus(string status)
        {
            return Ok(await _service.GetByStatusAsync(status));
        }

        [HttpGet("tracking/{trackingNumber}")]
        public async Task<IActionResult> GetByTrackingNumber(string trackingNumber)
        {
            var result = await _service.GetByTrackingNumberAsync(trackingNumber);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Shipment shipment)
        {
            return Ok(await _service.CreateAsync(shipment));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Shipment shipment)
        {
            if (!await _service.UpdateAsync(id, shipment))
                return NotFound();

            return Ok();
        }
        // =====================================================
        // SEARCH
        // GET: /api/Shipment/search?search=ABC
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

            var result =
                await _service.SearchAsync(search);

            return Ok(result);
        }


        // =====================================================
        // SORT
        // GET: /api/Shipment/sort?sort=id_asc
        // =====================================================

        [HttpGet("sort")]
        public async Task<IActionResult> Sort(
            [FromQuery] string? sort)
        {
            var result =
                await _service.GetSortedAsync(sort);

            return Ok(result);
        }


        // =====================================================
        // PAGINATION
        // GET: /api/Shipment/page?page=1&limit=15
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

            var result =
                await _service.GetPagedAsync(
                    page,
                    limit);

            return Ok(result);
        }


        // =====================================================
        // STATISTICS
        // GET: /api/Shipment/statistics
        // =====================================================

        [HttpGet("statistics")]
        public async Task<IActionResult> GetStatistics()
        {
            var result =
                await _service.GetStatisticsAsync();

            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (!await _service.DeleteAsync(id))
                return NotFound();

            return Ok();
        }
    }
}
