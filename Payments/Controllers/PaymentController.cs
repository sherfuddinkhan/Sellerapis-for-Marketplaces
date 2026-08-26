using Microsoft.AspNetCore.Mvc;
using Marketplacesellerportal.Payments.DTOs;
using Marketplacesellerportal.Payments.Interfaces;

namespace Marketplacesellerportal.Payments.Controllers
{
    [ApiController]
    [Route("api/settings/payment")]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _service;

        public PaymentController(IPaymentService service)
        {
            _service = service;
        }

        // =========================================================
        // GET ALL PAYMENT SETTINGS
        // GET: /api/settings/payment
        // =========================================================

        [HttpGet]
        public async Task<IActionResult> GetPaymentSettings()
        {
            var result =
                await _service.GetPaymentSettingsAsync();

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        // =========================================================
        // BANK DETAILS
        // GET: /api/settings/payment/bank
        // =========================================================

        [HttpGet("bank")]
        public async Task<IActionResult> GetBankDetails()
        {
            var result =
                await _service.GetBankDetailsAsync();

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        // =========================================================
        // BANK DETAILS
        // PUT: /api/settings/payment/bank
        // =========================================================

        [HttpPut("bank")]
        public async Task<IActionResult> UpdateBankDetails(
            [FromBody] BankDetailsDto bankDetails)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result =
                await _service.UpdateBankDetailsAsync(
                    bankDetails);

            if (!result)
                return NotFound();

            return Ok(new
            {
                message = "Bank details updated successfully."
            });
        }

        // =========================================================
        // PAYMENT GATEWAY
        // GET: /api/settings/payment/gateway
        // =========================================================

        [HttpGet("gateway")]
        public async Task<IActionResult> GetPaymentGateway()
        {
            var result =
                await _service.GetPaymentGatewayAsync();

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        // =========================================================
        // PAYMENT GATEWAY
        // PUT: /api/settings/payment/gateway
        // =========================================================

        [HttpPut("gateway")]
        public async Task<IActionResult> UpdatePaymentGateway(
            [FromBody] PaymentGatewayDto gateway)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result =
                await _service.UpdatePaymentGatewayAsync(
                    gateway);

            if (!result)
                return NotFound();

            return Ok(new
            {
                message = "Payment gateway updated successfully."
            });
        }

        // =========================================================
        // UPI SETTINGS
        // GET: /api/settings/payment/upi
        // =========================================================

        [HttpGet("upi")]
        public async Task<IActionResult> GetUpiSettings()
        {
            var result =
                await _service.GetUpiSettingsAsync();

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        // =========================================================
        // UPI SETTINGS
        // PUT: /api/settings/payment/upi
        // =========================================================

        [HttpPut("upi")]
        public async Task<IActionResult> UpdateUpiSettings(
            [FromBody] UpiSettingsDto upiSettings)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result =
                await _service.UpdateUpiSettingsAsync(
                    upiSettings);

            if (!result)
                return NotFound();

            return Ok(new
            {
                message = "UPI settings updated successfully."
            });
        }
    }
}