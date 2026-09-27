using Marketplacesellerportal.Models;
using Marketplacesellerportal.CustomerAddresses.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Marketplacesellerportal.CustomerAddresses.Controllers
{
    [ApiController]
    [Route("api/customer-addresses")]
    public class CustomerAddressesController : ControllerBase
    {
        private readonly ICustomerAddressService _service;

        public CustomerAddressesController(
            ICustomerAddressService service)
        {
            _service = service;
        }

        // ============================================================
        // GET ALL
        // GET /api/customer-addresses
        // ============================================================

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.GetAllAsync();

            return Ok(result);
        }

        // ============================================================
        // GET BY SELLER + CUSTOMER
        //
        // GET /api/customer-addresses/seller/6/customer/3
        // ============================================================

        [HttpGet("seller/{sellerId:int}/customer/{customerId:int}")]
        public async Task<IActionResult> GetBySellerAndCustomer(
            int sellerId,
            int customerId)
        {
            var result =
                await _service.GetBySellerAndCustomerAsync(
                    sellerId,
                    customerId);

            if (result == null)
            {
                return NotFound(new
                {
                    message = "Customer address not found.",
                    sellerId,
                    customerId
                });
            }

            return Ok(result);
        }

        // ============================================================
        // GET ALL ADDRESSES BY CUSTOMER
        //
        // GET /api/customer-addresses/customer/3
        // ============================================================

        [HttpGet("customer/{customerId:int}")]
        public async Task<IActionResult> GetByCustomerId(
            int customerId)
        {
            var result =
                await _service.GetByCustomerIdAsync(customerId);

            return Ok(result);
        }

        // ============================================================
        // GET BY ID
        //
        // GET /api/customer-addresses/1
        // ============================================================

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result =
                await _service.GetByIdAsync(id);

            if (result == null)
            {
                return NotFound(new
                {
                    message = "Customer address not found."
                });
            }

            return Ok(result);
        }

        // ============================================================
        // CREATE
        // POST /api/customer-addresses
        // ============================================================

        [HttpPost]
        public async Task<IActionResult> Create(
            [FromBody] CustomerAddress address)
        {
            if (address == null)
            {
                return BadRequest(new
                {
                    message = "Customer address is required."
                });
            }

            var result =
                await _service.CreateAsync(address);

            return CreatedAtAction(
                nameof(GetById),
                new
                {
                    id = result.CustomerAddressId
                },
                result);
        }

        // ============================================================
        // UPDATE
        // PUT /api/customer-addresses/1
        // ============================================================

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(
            int id,
            [FromBody] CustomerAddress address)
        {
            if (address == null)
            {
                return BadRequest(new
                {
                    message = "Customer address is required."
                });
            }

            if (id != address.CustomerAddressId)
            {
                return BadRequest(new
                {
                    message = "CustomerAddressId mismatch."
                });
            }

            var updated =
                await _service.UpdateAsync(address);

            if (!updated)
            {
                return NotFound(new
                {
                    message = "Customer address not found."
                });
            }

            return Ok(address);
        }

        // ============================================================
        // DELETE
        // DELETE /api/customer-addresses/1
        // ============================================================

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted =
                await _service.DeleteAsync(id);

            if (!deleted)
            {
                return NotFound(new
                {
                    message = "Customer address not found."
                });
            }

            return Ok(new
            {
                message = "Customer address deleted successfully."
            });
        }
    }
}