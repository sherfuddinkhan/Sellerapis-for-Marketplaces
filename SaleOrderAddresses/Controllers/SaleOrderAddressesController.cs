using Marketplacesellerportal.Interfaces;
using Marketplacesellerportal.Models;
using Marketplacesellerportal.SaleOrderAddresses.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Marketplacesellerportal.Controllers
{
    [ApiController]
    [Route("api/sale-order-addresses")]
    public class SaleOrderAddressesController
        : ControllerBase
    {
        private readonly ISaleOrderAddressService _service;

        public SaleOrderAddressesController(
            ISaleOrderAddressService service)
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
        [FromBody] SaleOrderAddress dto)
        {
            var result =
                await _service.CreateAsync(dto);

            return CreatedAtAction(
                nameof(GetById),
                new { id = result.AddressId },
                result);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(
            int id,
            [FromBody] SaleOrderAddress dto)
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
