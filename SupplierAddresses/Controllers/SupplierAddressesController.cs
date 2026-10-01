using Marketplacesellerportal.Models;
using Marketplacesellerportal.SupplierAddresses.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Marketplacesellerportal.SupplierAddresses.Controller
{
    [ApiController]
    [Route("api/supplier-addresses")]
    public class SupplierAddressesController : ControllerBase
    {
        private readonly ISupplierAddressService _service;

        public SupplierAddressesController(
            ISupplierAddressService service)
            => _service = service;

        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
            => Ok(await _service.GetAllAsync());

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _service.GetByIdAsync(id);

            return result == null
                ? NotFound()
                : Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(
            [FromBody] SupplierAddress dto)
        {
            var result =
                await _service.CreateAsync(dto);

            return CreatedAtAction(
                nameof(GetById),
                new { id = result.SupplierAddressId },
                result);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(
            int id,
            [FromBody] SupplierAddress dto)
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
