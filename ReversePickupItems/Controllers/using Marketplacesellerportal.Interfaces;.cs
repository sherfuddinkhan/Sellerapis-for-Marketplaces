using Marketplacesellerportal.Models;
using Marketplacesellerportal.ReversePickupItems.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Marketplacesellerportal.ReversePickupItems.Controllers
{
    [ApiController]
    [Route("api/reverse-pickup-items")]
    public class ReversePickupItemsController : ControllerBase
    {
        private readonly IReversePickupItemService _service;

        public ReversePickupItemsController(IReversePickupItemService service)
        {
            _service = service;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
            => Ok(await _service.GetAllAsync());

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _service.GetByIdAsync(id);
            return result == null ? NotFound() : Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ReversePickupItem dto)
        {
            var result = await _service.CreateAsync(dto);
            return CreatedAtAction(
                nameof(GetById),
                new { id = result.Id }, // FIXED: Id not ReversePickupItemId
                result);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] ReversePickupItem dto)
        {
            return await _service.UpdateAsync(id, dto)
               ? Ok(new { message = "Updated" })
                : NotFound();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            return await _service.DeleteAsync(id)
               ? Ok(new { message = "Deleted" })
                : NotFound();
        }
    }
}