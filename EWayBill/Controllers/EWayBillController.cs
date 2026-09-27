using Microsoft.AspNetCore.Mvc;
using Marketplacesellerportal.EWayBill.DTOs;
using Marketplacesellerportal.EWayBill.Interfaces;

namespace Marketplacesellerportal.EWayBill.Controllers
{
    [ApiController]
    [Route("api/e-way-bill")]
    public class EWayBillController : ControllerBase
    {
        private readonly IEWayBillService _eWayBillService;

        public EWayBillController(IEWayBillService eWayBillService)
        {
            _eWayBillService = eWayBillService;
        }

        /// <summary>
        /// POST: api/e-way-bill/generate/1
        /// Requires IRN first - call EInvoice generate before this
        /// Body: { transporterID, vehicleNo, distance, transportMode }
        /// Saves EWayBillNumber to SalesOrders + SalesInvoices
        /// </summary>
        [HttpPost("generate/{invoiceId}")]
        public async Task<IActionResult> Generate(int invoiceId, [FromBody] GenerateEWayBillRequest request)
        {
            if (request == null)
                return BadRequest(new { message = "Invalid request body" });

            try
            {
                var result = await _eWayBillService.GenerateAsync(invoiceId, request);
                return Ok(result);
            }
            catch (Exception ex)
            {
                // IRN not generated -> 400, other errors -> 500
                if (ex.Message.Contains("IRN"))
                    return BadRequest(new { message = ex.Message });

                return StatusCode(500, new { message = ex.Message });
            }
        }

        /// <summary>
        /// GET: api/e-way-bill/1 - Check EWB status
        /// </summary>
        [HttpGet("{invoiceId}")]
        public async Task<IActionResult> GetStatus(int invoiceId)
        {
            try
            {
                // Re-use e-invoice print-view which already has EWB data
                return Ok(new { invoiceId, message = "Use /api/e-invoice/print-view/{id} to get full IRN + EWB view for PDF" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }
    }
}
