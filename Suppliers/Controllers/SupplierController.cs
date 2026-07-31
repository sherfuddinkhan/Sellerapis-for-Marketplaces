using Marketplacesellerportal.Models;
using Marketplacesellerportal.Suppliers.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Marketplacesellerportal.Suppliers.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SupplierController : ControllerBase
    {
        private readonly ISupplierService _service;

        public SupplierController(ISupplierService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpGet("{supplierId}")]
        public async Task<IActionResult> Get(int supplierId)
        {
            var supplier = await _service.GetByIdAsync(supplierId);

            if (supplier == null)
                return NotFound();

            return Ok(supplier);
        }

        [HttpGet("seller/{sellerId}")]
        public async Task<IActionResult> GetBySeller(int sellerId)
        {
            return Ok(await _service.GetBySellerIdAsync(sellerId));
        }

        [HttpGet("{sellerId}/{supplierId}")]
        public async Task<IActionResult> GetSupplier(int sellerId, int supplierId)
        {
            var supplier = await _service.GetSupplierAsync(sellerId, supplierId);

            if (supplier == null)
                return NotFound();

            return Ok(supplier);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Supplier supplier)
        {
            var result = await _service.CreateAsync(supplier);

            return Ok(result);
        }

        [HttpPut("{supplierId}")]
        public async Task<IActionResult> Update(int supplierId, Supplier supplier)
        {
            var success = await _service.UpdateAsync(supplierId, supplier);

            if (!success)
                return NotFound();

            return Ok();
        }

        [HttpDelete("{supplierId}")]
        public async Task<IActionResult> Delete(int supplierId)
        {
            var success = await _service.DeleteAsync(supplierId);

            if (!success)
                return NotFound();

            return Ok();
        }
    }
}
