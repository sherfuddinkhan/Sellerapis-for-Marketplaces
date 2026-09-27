using Microsoft.AspNetCore.Mvc;
using Marketplacesellerportal.EInvoice.DTOs;
using Marketplacesellerportal.EInvoice.Interfaces;

namespace Marketplacesellerportal.EInvoice.Controllers
{
    [ApiController]
    [Route("api/e-invoice")]
    public class EInvoiceController : ControllerBase
    {
        private readonly IEInvoiceService _service;

        public EInvoiceController(IEInvoiceService service)
        {
            _service = service;
        }

        // POST api/e-invoice/generate/1
        // Body: { transactionType: "REG" / "Bill To - Ship To" / "Bill From - Dispatch From" / "COMBINED" }
        // This saves IrnNumber, AckNo, SignedQRCode to SalesOrders + SalesInvoices
        [HttpPost("generate/{invoiceId}")]
        public async Task<IActionResult> Generate(int invoiceId, [FromBody] GenerateEinvoiceRequest request)
        {
            if (request == null) return BadRequest("Request is null");

            try
            {
                var result = await _service.GenerateAsync(invoiceId, request);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message, stack = ex.StackTrace });
            }
        }

        // GET api/e-invoice/print-view/1
        // Your SalesInvoicePrint.jsx will call this to get IRN + TransactionType + ShipTo/DispatchFrom
        [HttpGet("print-view/{invoiceId}")]
        public async Task<IActionResult> PrintView(int invoiceId)
        {
            try
            {
                var data = await _service.GetPrintViewAsync(invoiceId);
                if (data == null) return NotFound($"Invoice {invoiceId} not found");
                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }
    }
}