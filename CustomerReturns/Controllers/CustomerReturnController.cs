using Microsoft.AspNetCore.Mvc;
using Marketplacesellerportal.Models;
using Marketplacesellerportal.CustomerReturns.Interfaces;

namespace Marketplacesellerportal.CustomerReturns.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerReturnController : ControllerBase
    {
        private readonly ICustomerReturnService _service;

        public CustomerReturnController(ICustomerReturnService service)
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

        [HttpGet("invoice/{salesInvoiceId}")]
        public async Task<IActionResult> GetBySalesInvoice(int salesInvoiceId)
        {
            return Ok(await _service.GetBySalesInvoiceAsync(salesInvoiceId));
        }

        [HttpGet("product/{productId}")]
        public async Task<IActionResult> GetByProduct(int productId)
        {
            return Ok(await _service.GetByProductAsync(productId));
        }

        [HttpGet("status/{status}")]
        public async Task<IActionResult> GetByStatus(string status)
        {
            return Ok(await _service.GetByStatusAsync(status));
        }

        [HttpGet("number/{returnNumber}")]
        public async Task<IActionResult> GetByReturnNumber(string returnNumber)
        {
            var result = await _service.GetByReturnNumberAsync(returnNumber);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CustomerReturn customerReturn)
        {
            return Ok(await _service.CreateAsync(customerReturn));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, CustomerReturn customerReturn)
        {
            if (!await _service.UpdateAsync(id, customerReturn))
                return NotFound();

            return Ok();
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
