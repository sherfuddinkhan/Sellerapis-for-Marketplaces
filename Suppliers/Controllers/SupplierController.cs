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

        // =====================================================
        // GET ALL SUPPLIERS
        // GET: /api/Supplier
        // =====================================================

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAllAsync());
        }

        // =====================================================
        // GET SUPPLIER BY ID
        // GET: /api/Supplier/{supplierId}
        // =====================================================

        [HttpGet("{supplierId}")]
        public async Task<IActionResult> Get(int supplierId)
        {
            var supplier = await _service.GetByIdAsync(supplierId);

            if (supplier == null)
                return NotFound(new
                {
                    message = "Supplier not found"
                });

            return Ok(supplier);
        }

        // =====================================================
        // GET SUPPLIERS BY SELLER
        // GET: /api/Supplier/seller/{sellerId}
        // =====================================================

        [HttpGet("seller/{sellerId}")]
        public async Task<IActionResult> GetBySeller(int sellerId)
        {
            return Ok(
                await _service.GetBySellerIdAsync(sellerId));
        }

        // =====================================================
        // GET SUPPLIER BY SELLER + SUPPLIER
        // GET: /api/Supplier/{sellerId}/{supplierId}
        // =====================================================

        [HttpGet("{sellerId}/{supplierId}")]
        public async Task<IActionResult> GetSupplier(
            int sellerId,
            int supplierId)
        {
            var supplier =
                await _service.GetSupplierAsync(
                    sellerId,
                    supplierId);

            if (supplier == null)
                return NotFound(new
                {
                    message = "Supplier not found"
                });

            return Ok(supplier);
        }

        // =====================================================
        // SEARCH
        // GET: /api/Supplier/search?search=tech
        // =====================================================

        [HttpGet("search")]
        public async Task<IActionResult> Search(
            [FromQuery] string search)
        {
            if (string.IsNullOrWhiteSpace(search))
            {
                return BadRequest(new
                {
                    message = "Search value is required"
                });
            }

            var result =
                await _service.SearchAsync(search);

            return Ok(result);
        }

        // =====================================================
        // SORT
        // GET: /api/Supplier/sort?sort=name_asc
        // =====================================================

        [HttpGet("sort")]
        public async Task<IActionResult> Sort(
            [FromQuery] string? sort)
        {
            var result =
                await _service.GetSortedAsync(sort);

            return Ok(result);
        }

        // =====================================================
        // PAGINATION
        // GET: /api/Supplier/page?page=1&limit=15
        // =====================================================

        [HttpGet("page")]
        public async Task<IActionResult> GetPaged(
            [FromQuery] int page = 1,
            [FromQuery] int limit = 15)
        {
            if (page < 1)
                page = 1;

            if (limit < 1)
                limit = 15;

            var result =
                await _service.GetPagedAsync(
                    page,
                    limit);

            return Ok(result);
        }

        // =====================================================
        // STATISTICS
        // GET: /api/Supplier/statistics
        // =====================================================

        [HttpGet("statistics")]
        public async Task<IActionResult> GetStatistics()
        {
            var result =
                await _service.GetStatisticsAsync();

            return Ok(result);
        }

        // =====================================================
        // CREATE SUPPLIER
        // POST: /api/Supplier
        // =====================================================

        [HttpPost]
        public async Task<IActionResult> Create(
            Supplier supplier)
        {
            var result =
                await _service.CreateAsync(supplier);

            return Ok(result);
        }

        // =====================================================
        // UPDATE SUPPLIER
        // PUT: /api/Supplier/{supplierId}
        // =====================================================

        [HttpPut("{supplierId}")]
        public async Task<IActionResult> Update(
            int supplierId,
            Supplier supplier)
        {
            var success =
                await _service.UpdateAsync(
                    supplierId,
                    supplier);

            if (!success)
                return NotFound(new
                {
                    message = "Supplier not found"
                });

            return Ok(new
            {
                message = "Supplier updated successfully"
            });
        }

        // =====================================================
        // DELETE SUPPLIER
        // DELETE: /api/Supplier/{supplierId}
        // =====================================================

        [HttpDelete("{supplierId}")]
        public async Task<IActionResult> Delete(
            int supplierId)
        {
            var success =
                await _service.DeleteAsync(supplierId);

            if (!success)
                return NotFound(new
                {
                    message = "Supplier not found"
                });

            return Ok(new
            {
                message = "Supplier deleted successfully"
            });
        }
    }
}