using Marketplacesellerportal.Payments.DTOs;
using Marketplacesellerportal.Payments.Interfaces;
using Microsoft.AspNetCore.Mvc;
using static System.Net.Mime.MediaTypeNames;

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
            var result = await _service.GetPaymentSettingsAsync();

            if (result == null)
                return NotFound(new
                {
                    message = "Payment settings not found."
                });

            return Ok(result);
        }

        // =========================================================
        // BANK DETAILS
        // GET: /api/settings/payment/bank
        // =========================================================

        [HttpGet("bank")]
        public async Task<IActionResult> GetBankDetails()
        {
            var result = await _service.GetBankDetailsAsync();

            if (result == null)
                return NotFound(new
                {
                    message = "Bank details not found."
                });

            return Ok(result);
        }

        // =========================================================
        // BANK DETAILS
        // POST: /api/settings/payment/bank
        // =========================================================

        [HttpPost("bank")]
        public async Task<IActionResult> CreateBankDetails(
            [FromBody] BankDetailsDto bankDetails)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result =
                await _service.CreateBankDetailsAsync(bankDetails);

            if (result == null)
            {
                return BadRequest(new
                {
                    message = "Unable to create bank details."
                });
            }

            return StatusCode(
                StatusCodes.Status201Created,
                result);
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
                await _service.UpdateBankDetailsAsync(bankDetails);

            if (!result)
            {
                return NotFound(new
                {
                    message = "Bank details not found."
                });
            }

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
                return NotFound(new
                {
                    message = "Payment gateway settings not found."
                });

            return Ok(result);
        }

        // =========================================================
        // PAYMENT GATEWAY
        // POST: /api/settings/payment/gateway
        // =========================================================

        [HttpPost("gateway")]
        public async Task<IActionResult> CreatePaymentGateway(
            [FromBody] PaymentGatewayDto gateway)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result =
                await _service.CreatePaymentGatewayAsync(gateway);

            if (result == null)
            {
                return BadRequest(new
                {
                    message = "Unable to create payment gateway."
                });
            }

            return StatusCode(
                StatusCodes.Status201Created,
                result);
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
                await _service.UpdatePaymentGatewayAsync(gateway);

            if (!result)
            {
                return NotFound(new
                {
                    message = "Payment gateway settings not found."
                });
            }

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
                return NotFound(new
                {
                    message = "UPI settings not found."
                });

            return Ok(result);
        }

        // =========================================================
        // UPI SETTINGS
        // POST: /api/settings/payment/upi
        // =========================================================

        [HttpPost("upi")]
        public async Task<IActionResult> CreateUpiSettings(
            [FromBody] UpiSettingsDto upiSettings)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result =
                await _service.CreateUpiSettingsAsync(upiSettings);

            if (result == null)
            {
                return BadRequest(new
                {
                    message = "Unable to create UPI settings."
                });
            }

            return StatusCode(
                StatusCodes.Status201Created,
                result);
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
                await _service.UpdateUpiSettingsAsync(upiSettings);

            if (!result)
            {
                return NotFound(new
                {
                    message = "UPI settings not found."
                });
            }

            return Ok(new
            {
                message = "UPI settings updated successfully."
            });
        }
    }
}
