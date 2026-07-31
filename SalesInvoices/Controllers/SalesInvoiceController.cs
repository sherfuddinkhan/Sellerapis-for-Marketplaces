using Microsoft.AspNetCore.Mvc;
using Marketplacesellerportal.Models;
using Marketplacesellerportal.SalesInvoices.Interfaces;

namespace Marketplacesellerportal.SalesInvoices.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SalesInvoiceController : ControllerBase
    {
        private readonly ISalesInvoiceService _service;

        public SalesInvoiceController(ISalesInvoiceService service)
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

        [HttpGet("salesorder/{salesOrderId}")]
        public async Task<IActionResult> GetBySalesOrder(int salesOrderId)
        {
            return Ok(await _service.GetBySalesOrderAsync(salesOrderId));
        }

        [HttpGet("status/{status}")]
        public async Task<IActionResult> GetByStatus(string status)
        {
            return Ok(await _service.GetByStatusAsync(status));
        }

        [HttpGet("paymentstatus/{paymentStatus}")]
        public async Task<IActionResult> GetByPaymentStatus(string paymentStatus)
        {
            return Ok(await _service.GetByPaymentStatusAsync(paymentStatus));
        }

        [HttpGet("number/{invoiceNumber}")]
        public async Task<IActionResult> GetByInvoiceNumber(string invoiceNumber)
        {
            var result = await _service.GetByInvoiceNumberAsync(invoiceNumber);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(SalesInvoice salesInvoice)
        {
            return Ok(await _service.CreateAsync(salesInvoice));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, SalesInvoice salesInvoice)
        {
            if (!await _service.UpdateAsync(id, salesInvoice))
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
