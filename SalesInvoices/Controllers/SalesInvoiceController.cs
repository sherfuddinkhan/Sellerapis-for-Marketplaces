using Microsoft.AspNetCore.Mvc;
using Marketplacesellerportal.Models;
using Marketplacesellerportal.SalesInvoices.DTOs;
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

        // =========================================================
        // GET ALL SALES INVOICES
        // =========================================================

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.GetAllAsync();

            return Ok(result);
        }

        // =========================================================
        // GET SALES INVOICE BY ID
        // =========================================================

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _service.GetByIdAsync(id);

            if (result == null)
                return NotFound(new
                {
                    message = "Sales invoice not found."
                });

            return Ok(result);
        }

        // =========================================================
        // GET BY SALES ORDER ID
        // =========================================================

        [HttpGet("salesorder/{salesOrderId}")]
        public async Task<IActionResult> GetBySalesOrder(int salesOrderId)
        {
            var result = await _service.GetBySalesOrderAsync(salesOrderId);

            return Ok(result);
        }

        // =========================================================
        // GET BY STATUS
        // =========================================================

        [HttpGet("status/{status}")]
        public async Task<IActionResult> GetByStatus(string status)
        {
            var result = await _service.GetByStatusAsync(status);

            return Ok(result);
        }

        // =========================================================
        // GET BY PAYMENT STATUS
        // =========================================================

        [HttpGet("paymentstatus/{paymentStatus}")]
        public async Task<IActionResult> GetByPaymentStatus(string paymentStatus)
        {
            var result = await _service.GetByPaymentStatusAsync(paymentStatus);

            return Ok(result);
        }

        // =========================================================
        // GET BY INVOICE NUMBER
        // =========================================================

        [HttpGet("number/{invoiceNumber}")]
        public async Task<IActionResult> GetByInvoiceNumber(string invoiceNumber)
        {
            var result = await _service.GetByInvoiceNumberAsync(invoiceNumber);

            if (result == null)
                return NotFound(new
                {
                    message = "Sales invoice not found."
                });

            return Ok(result);
        }

        // =========================================================
        // CREATE SALES INVOICE
        // =========================================================

        [HttpPost]
        public async Task<IActionResult> Create(
            [FromBody] CreateSalesInvoiceRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // Map DTO -> Entity
            var salesInvoice = new SalesInvoice
            {
                SalesOrderId = request.SalesOrderId,
                SellerId = request.SellerId,
                CustomerId = request.CustomerId,

                InvoiceNumber = request.InvoiceNumber,
                InvoiceDate = request.InvoiceDate,
                InvoiceScenario = request.InvoiceScenario,
                Category = request.Category,
                TransactionType = request.TransactionType,

                UserGSTIN = request.UserGSTIN,
                DocumentType = request.DocumentType,
                SupplyType = request.SupplyType,
                PlaceOfSupply = request.PlaceOfSupply,
                FinancialYear = request.FinancialYear,
                ReverseCharge = request.ReverseCharge,

                Id = request.Id,
                RefId = request.RefId,

                SubTotal = request.SubTotal,
                DiscountAmount = request.DiscountAmount,
                TaxAmount = request.TaxAmount,
                TotalAmount = request.TotalAmount,
                PaidAmount = request.PaidAmount,
                BalanceAmount = request.BalanceAmount,

                PaymentStatus = request.PaymentStatus,
                Status = request.Status,
                Remarks = request.Remarks
            };

            var result = await _service.CreateAsync(salesInvoice);

            return Ok(result);
        }

        // =========================================================
        // UPDATE SALES INVOICE
        // =========================================================

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(
     int id,
     [FromBody] UpdateSalesInvoiceRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var updated = await _service.UpdateAsync(id, request);

            if (!updated)
            {
                return NotFound(new
                {
                    message = "Sales invoice not found.",
                    salesInvoiceId = id
                });
            }

            return Ok(new
            {
                message = "Sales invoice updated successfully.",
                salesInvoiceId = id
            });
        }
        // =========================================================
        // DELETE SALES INVOICE
        // =========================================================

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _service.DeleteAsync(id);

            if (!deleted)
            {
                return NotFound(new
                {
                    message = "Sales invoice not found.",
                    salesInvoiceId = id
                });
            }

            return Ok(new
            {
                message = "Sales invoice deleted successfully.",
                salesInvoiceId = id
            });
        }
    }
}