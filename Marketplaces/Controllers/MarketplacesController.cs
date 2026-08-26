using Marketplacesellerportal.Marketplaces.Interfaces;
using Marketplacesellerportal.Models;
using Microsoft.AspNetCore.Mvc;

namespace Marketplacesellerportal.Marketplaces.Controllers
{
    [ApiController]
    [Route("api/marketplaces")]
    public class MarketplacesController
        : ControllerBase
    {
        private readonly IMarketplaceService _service;

        public MarketplacesController(
            IMarketplaceService service)
        {
            _service = service;
        }

        // GET: api/marketplaces
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(
                await _service.GetAllAsync());
        }

        // GET: api/marketplaces/1
        [HttpGet("{marketplaceId}")]
        public async Task<IActionResult> GetById(
            int marketplaceId)
        {
            var result =
                await _service.GetByIdAsync(
                    marketplaceId);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        // GET: api/marketplaces/code/AMAZON
        [HttpGet("code/{marketplaceCode}")]
        public async Task<IActionResult> GetByCode(
            string marketplaceCode)
        {
            var result =
                await _service.GetByCodeAsync(
                    marketplaceCode);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        // GET: api/marketplaces/active
        [HttpGet("active")]
        public async Task<IActionResult> GetActive()
        {
            return Ok(
                await _service.GetActiveAsync());
        }

        // GET: api/marketplaces/search?search=amazon
        [HttpGet("search")]
        public async Task<IActionResult> Search(
            [FromQuery] string? search)
        {
            return Ok(
                await _service.SearchAsync(search));
        }

        // GET: api/marketplaces/sort?sort=name_asc
        [HttpGet("sort")]
        public async Task<IActionResult> Sort(
            [FromQuery] string? sort)
        {
            return Ok(
                await _service.GetSortedAsync(sort));
        }

        // POST: api/marketplaces
        [HttpPost]
        public async Task<IActionResult> Create(
            [FromBody] Marketplace marketplace)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result =
                await _service.CreateAsync(
                    marketplace);

            return CreatedAtAction(
                nameof(GetById),
                new
                {
                    marketplaceId =
                        result.MarketplaceId
                },
                result);
        }

        // PUT: api/marketplaces/1
        [HttpPut("{marketplaceId}")]
        public async Task<IActionResult> Update(
            int marketplaceId,
            [FromBody] Marketplace marketplace)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var updated =
                await _service.UpdateAsync(
                    marketplaceId,
                    marketplace);

            if (!updated)
                return NotFound();

            return Ok(
                "Marketplace updated successfully.");
        }

        // DELETE: api/marketplaces/1
        [HttpDelete("{marketplaceId}")]
        public async Task<IActionResult> Delete(
            int marketplaceId)
        {
            var deleted =
                await _service.DeleteAsync(
                    marketplaceId);

            if (!deleted)
                return NotFound();

            return Ok(
                "Marketplace deleted successfully.");
        }
    }
}
