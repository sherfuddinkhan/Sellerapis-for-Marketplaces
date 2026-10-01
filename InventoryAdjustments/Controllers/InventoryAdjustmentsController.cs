using Marketplacesellerportal.Interfaces;
using Marketplacesellerportal.InventoryAdjustments.Interfaces;
using Marketplacesellerportal.Models;
using Microsoft.AspNetCore.Mvc;

namespace Marketplacesellerportal.Controllers
{
    [ApiController]
    [Route("api/inventory-adjustments")]
    public class InventoryAdjustmentsController
        : ControllerBase
    {
        private readonly IInventoryAdjustmentService _service;

        public InventoryAdjustmentsController(
            IInventoryAdjustmentService service)
        {
            _service = service;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
            => Ok(await _service.GetAllAsync());

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result =
                await _service.GetByIdAsync(id);

            return result == null
                ? NotFound()
                : Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(
            [FromBody] InventoryAdjustment dto)
        {
            var result =
                await _service.CreateAsync(dto);

            return CreatedAtAction(
                nameof(GetById),
                new
                {
                    id = result.InventoryAdjustmentId
                },
                result);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(
            int id,
            [FromBody] InventoryAdjustment dto)
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
