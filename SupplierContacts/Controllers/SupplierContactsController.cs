using Marketplacesellerportal.SupplierContact.Interfaces;
using Microsoft.AspNetCore.Mvc;

using SupplierContactModel = Marketplacesellerportal.Models.SupplierContacts;

namespace Marketplacesellerportal.SupplierContact.Controllers
{
    [ApiController]
    [Route("api/supplier-contacts")]
    public class SupplierContactsController : ControllerBase
    {
        private readonly ISupplierContactService _service;

        public SupplierContactsController(
            ISupplierContactService service)
        {
            _service = service;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(
                await _service.GetAllAsync());
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(
            int id)
        {
            var result =
                await _service.GetByIdAsync(id);

            return result == null
                ? NotFound()
                : Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(
            [FromBody] SupplierContactModel dto)
        {
            var result =
                await _service.CreateAsync(dto);

            return CreatedAtAction(
                nameof(GetById),
                new { id = result.SupplierContactId },
                result);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(
            int id,
            [FromBody] SupplierContactModel dto)
        {
            return await _service.UpdateAsync(id, dto)
                ? Ok(new { message = "Updated" })
                : NotFound();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(
            int id)
        {
            return await _service.DeleteAsync(id)
                ? Ok(new { message = "Deleted" })
                : NotFound();
        }
    }
}