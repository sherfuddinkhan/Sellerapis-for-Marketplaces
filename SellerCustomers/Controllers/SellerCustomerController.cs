using Microsoft.AspNetCore.Mvc;
using Marketplacesellerportal.SellerCustomers.DTOs;
using Marketplacesellerportal.SellerCustomers.Interfaces;

namespace Marketplacesellerportal.SellerCustomers.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SellerCustomerController : ControllerBase
    {
        private readonly ISellerCustomerService _service;

        public SellerCustomerController(
            ISellerCustomerService service)
        {
            _service = service;
        }

        // GET: api/SellerCustomer
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var customers = await _service.GetAllAsync();

            return Ok(customers);
        }

        // GET: api/SellerCustomer/seller/1
        [HttpGet("seller/{sellerId:int}")]
        public async Task<IActionResult> GetBySeller(int sellerId)
        {
            var customers =
                await _service.GetBySellerIdAsync(sellerId);

            return Ok(customers);
        }

        // GET: api/SellerCustomer/1/customers/2
        [HttpGet("{sellerId:int}/customers/{customerId:int}")]
        public async Task<IActionResult> GetCustomer(
            int sellerId,
            int customerId)
        {
            var customer =
                await _service.GetCustomerAsync(
                    sellerId,
                    customerId);

            if (customer == null)
            {
                return NotFound(new
                {
                    message = "Customer not found."
                });
            }

            return Ok(customer);
        }

        // GET: api/SellerCustomer/1/code/CUST001
        [HttpGet("{sellerId:int}/code/{customerCode}")]
        public async Task<IActionResult> GetByCustomerCode(
            int sellerId,
            string customerCode)
        {
            var customer =
                await _service.GetByCustomerCodeAsync(
                    sellerId,
                    customerCode);

            if (customer == null)
            {
                return NotFound(new
                {
                    message = "Customer not found."
                });
            }

            return Ok(customer);
        }

        // POST: api/SellerCustomer
        [HttpPost]
        public async Task<IActionResult> Create(
            [FromBody] CreateSellerCustomerRequest request)
        {
            var customer =
                await _service.CreateAsync(request);

            return CreatedAtAction(
                nameof(GetCustomer),
                new
                {
                    sellerId = customer.SellerId,
                    customerId = customer.CustomerId
                },
                customer);
        }

        // PUT: api/SellerCustomer/1/customers/2
        [HttpPut("{sellerId:int}/customers/{customerId:int}")]
        public async Task<IActionResult> Update(
            int sellerId,
            int customerId,
            [FromBody] UpdateSellerCustomerRequest request)
        {
            var updated =
                await _service.UpdateAsync(
                    sellerId,
                    customerId,
                    request);

            if (!updated)
            {
                return NotFound(new
                {
                    message = "Customer not found."
                });
            }

            return NoContent();
        }

        // DELETE: api/SellerCustomer/1/customers/2
        [HttpDelete("{sellerId:int}/customers/{customerId:int}")]
        public async Task<IActionResult> Delete(
            int sellerId,
            int customerId)
        {
            var deleted =
                await _service.DeleteAsync(
                    sellerId,
                    customerId);

            if (!deleted)
            {
                return NotFound(new
                {
                    message = "Customer not found."
                });
            }

            return NoContent();
        }
    }
}