using Microsoft.AspNetCore.Mvc;
using Marketplacesellerportal.Models;
using Marketplacesellerportal.VendorItemCustomFields.Interfaces;

namespace Marketplacesellerportal.VendorItemCustomFields.Controllers
{
    [ApiController]
    [Route("api/vendor-item-custom-fields")]
    public class VendorItemCustomFieldsController : ControllerBase
    {
        private readonly IVendorItemCustomFieldService _service;

        public VendorItemCustomFieldsController(
            IVendorItemCustomFieldService service)
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

            return result == null
                ? NotFound()
                : Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(
            [FromBody] VendorItemCustomField dto)
        {
            var result = await _service.CreateAsync(dto);

            return CreatedAtAction(
                nameof(GetById),
                new
                {
                    id = result.VendorItemMasterId
                },
                result);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(
            int id,
            [FromBody] VendorItemCustomField dto)
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