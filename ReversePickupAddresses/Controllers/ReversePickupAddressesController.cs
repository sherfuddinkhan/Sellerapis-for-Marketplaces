using Microsoft.AspNetCore.Mvc;
using Marketplacesellerportal.Interfaces;
using Marketplacesellerportal.Models;

namespace Marketplacesellerportal.Controllers
{
    [ApiController]
    [Route("api/reverse-pickup-addresses")]
    public class ReversePickupAddressesController
        : ControllerBase
    {
        private readonly IReversePickupAddressService _service;

        public ReversePickupAddressesController(
            IReversePickupAddressService service)
        {
            _service = service;
        }

        // =========================================================
        // GET ALL
        // =========================================================

        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.GetAllAsync();

            return Ok(result);
        }

        // =========================================================
        // GET BY ID
        // =========================================================

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _service.GetByIdAsync(id);

            return result == null
                ? NotFound()
                : Ok(result);
        }

        // =========================================================
        // CREATE
        // =========================================================

        [HttpPost]
        public async Task<IActionResult> Create(
            [FromBody] ReversePickupAddress dto)
        {
            var result = await _service.CreateAsync(dto);

            return CreatedAtAction(
                nameof(GetById),
                new { id = result.Id },
                result);
        }

        // =========================================================
        // UPDATE
        // =========================================================

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(
            int id,
            [FromBody] ReversePickupAddress dto)
        {
            return await _service.UpdateAsync(id, dto)
                ? Ok(new { message = "Updated" })
                : NotFound();
        }

        // =========================================================
        // DELETE
        // =========================================================

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            return await _service.DeleteAsync(id)
                ? Ok(new { message = "Deleted" })
                : NotFound();
        }
    }
}