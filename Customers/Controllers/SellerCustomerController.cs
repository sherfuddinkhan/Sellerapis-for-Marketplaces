using Microsoft.AspNetCore.Mvc;
using Marketplacesellerportal.Models;
using Marketplacesellerportal.Customers.Interfaces;

namespace Marketplacesellerportal.Customers.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SellerCustomerController : ControllerBase
    {
        private readonly ISellerCustomerService _service;

        public SellerCustomerController(ISellerCustomerService service)
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

        // GET: api/SellerCustomer/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var customer = await _service.GetByIdAsync(id);

            if (customer == null)
                return NotFound();

            return Ok(customer);
        }

        // GET: api/SellerCustomer/seller/1
        [HttpGet("seller/{sellerId}")]
        public async Task<IActionResult> GetBySeller(int sellerId)
        {
            var customers = await _service.GetBySellerIdAsync(sellerId);
            return Ok(customers);
        }

        // GET: api/SellerCustomer/code/CUST001
        [HttpGet("code/{customerCode}")]
        public async Task<IActionResult> GetByCustomerCode(string customerCode)
        {
            var customer = await _service.GetByCustomerCodeAsync(customerCode);

            if (customer == null)
                return NotFound();

            return Ok(customer);
        }

        // POST: api/SellerCustomer
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] SellerCustomer customer)
        {
            await _service.AddAsync(customer);

            return CreatedAtAction(
                nameof(GetById),
                new { id = customer.CustomerId },
                customer);
        }

        // PUT: api/SellerCustomer/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] SellerCustomer customer)
        {
            if (id != customer.CustomerId)
                return BadRequest();

            await _service.UpdateAsync(customer);

            return NoContent();
        }
        [HttpGet("{sellerId}/customers/{customerId}")]
        public async Task<IActionResult> GetCustomer(int sellerId,int customerId)
        {
            var customer = await _service.GetCustomerAsync(sellerId, customerId);

            if (customer == null)
                return NotFound();

            return Ok(customer);
        }

        // DELETE: api/SellerCustomer/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);

            return NoContent();
        }
    }
}
