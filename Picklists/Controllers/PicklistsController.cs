using Marketplacesellerportal.Models;
using Marketplacesellerportal.Picklists.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Marketplacesellerportal.Controllers
{
    [ApiController]
    [Route("api/picklists")]
    public class PicklistsController : ControllerBase
    {
        private readonly IPicklistService _service;

        public PicklistsController(
            IPicklistService service)
        {
            _service = service;
        }

        // GET: api/picklists/all
        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAllAsync());
        }

        // GET: api/picklists/{picklistCode}
        [HttpGet("{picklistCode}")]
        public async Task<IActionResult> GetById(
            string picklistCode)
        {
            var result =
                await _service.GetByCodeAsync(picklistCode);

            if (result == null)
                return NotFound(
                    $"Picklist '{picklistCode}' not found.");

            return Ok(result);
        }

        // POST: api/picklists
        [HttpPost]
        public async Task<IActionResult> Create(
            [FromBody] Picklist dto)
        {
            var result =
                await _service.CreateAsync(dto);

            return CreatedAtAction(
                nameof(GetById),
                new
                {
                    picklistCode = result.PicklistCode
                },
                result);
        }

        // PUT: api/picklists/{picklistCode}
        [HttpPut("{picklistCode}")]
        public async Task<IActionResult> Update(
            string picklistCode,
            [FromBody] Picklist entity)
        {
            entity.PicklistCode = picklistCode;

            var updated =
                await _service.UpdateAsync(
                    picklistCode,
                    entity);

            if (!updated)
                return NotFound(
                    $"Picklist '{picklistCode}' not found.");

            return Ok(entity);
        }

        // DELETE: api/picklists/{picklistCode}
        [HttpDelete("{picklistCode}")]
        public async Task<IActionResult> Delete(
            string picklistCode)
        {
            var deleted =
                await _service.DeleteAsync(picklistCode);

            if (!deleted)
                return NotFound(
                    $"Picklist '{picklistCode}' not found.");

            return NoContent();
        }
    }
}
