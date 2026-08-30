using Microsoft.AspNetCore.Mvc;
using Marketplacesellerportal.Models;
using Marketplacesellerportal.StockAdjustments.Interfaces;

namespace Marketplacesellerportal.StockAdjustments.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StockAdjustmentController : ControllerBase
    {
        private readonly IStockAdjustmentService _service;

        public StockAdjustmentController(IStockAdjustmentService service)
        {
            _service = service;
        }

        // =====================================================
        // GET ALL
        // GET: /api/StockAdjustment
        // =====================================================

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAllAsync());
        }

        // =====================================================
        // GET BY ID
        // GET: /api/StockAdjustment/1
        // =====================================================

        [HttpGet("{stockAdjustmentId}")]
        public async Task<IActionResult> GetById(int stockAdjustmentId)
        {
            var adjustment =
                await _service.GetByIdAsync(stockAdjustmentId);

            if (adjustment == null)
                return NotFound();

            return Ok(adjustment);
        }

        // =====================================================
        // GET BY SELLER
        // GET: /api/StockAdjustment/seller/1
        // =====================================================

        [HttpGet("seller/{sellerId}")]
        public async Task<IActionResult> GetBySeller(int sellerId)
        {
            return Ok(
                await _service.GetBySellerIdAsync(sellerId));
        }

        // =====================================================
        // GET BY PRODUCT
        // GET: /api/StockAdjustment/product/1
        // =====================================================

        [HttpGet("product/{productId}")]
        public async Task<IActionResult> GetByProduct(int productId)
        {
            return Ok(
                await _service.GetByProductIdAsync(productId));
        }

        // =====================================================
        // GET BY WAREHOUSE
        // GET: /api/StockAdjustment/warehouse/1
        // =====================================================

        [HttpGet("warehouse/{warehouseId}")]
        public async Task<IActionResult> GetByWarehouse(int warehouseId)
        {
            return Ok(
                await _service.GetByWarehouseIdAsync(warehouseId));
        }

        // =====================================================
        // GET BY ADJUSTMENT TYPE
        // GET: /api/StockAdjustment/type/Damage
        // =====================================================

        [HttpGet("type/{adjustmentType}")]
        public async Task<IActionResult> GetByAdjustmentType(
            string adjustmentType)
        {
            return Ok(
                await _service.GetByAdjustmentTypeAsync(
                    adjustmentType));
        }

        // =====================================================
        // GET BY SELLER + PRODUCT + WAREHOUSE + ID
        // =====================================================

        [HttpGet("{sellerId}/{productId}/{warehouseId}/{stockAdjustmentId}")]
        public async Task<IActionResult> GetStockAdjustment(
            int sellerId,
            int productId,
            int warehouseId,
            int stockAdjustmentId)
        {
            var adjustment =
                await _service.GetStockAdjustmentAsync(
                    sellerId,
                    productId,
                    warehouseId,
                    stockAdjustmentId);

            if (adjustment == null)
                return NotFound();

            return Ok(adjustment);
        }

        // =====================================================
        // SEARCH
        // GET:
        // /api/StockAdjustment/search?search=damage
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
        // GET:
        // /api/StockAdjustment/sort?sort=date_desc
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
        // GET:
        // /api/StockAdjustment/page?page=1&limit=15
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
        // GET:
        // /api/StockAdjustment/statistics
        // =====================================================

        [HttpGet("statistics")]
        public async Task<IActionResult> GetStatistics()
        {
            var result =
                await _service.GetStatisticsAsync();

            return Ok(result);
        }

        // =====================================================
        // CREATE
        // =====================================================

        [HttpPost]
        public async Task<IActionResult> Create(
            StockAdjustment stockAdjustment)
        {
            return Ok(
                await _service.CreateAsync(
                    stockAdjustment));
        }

        // =====================================================
        // UPDATE
        // =====================================================

        [HttpPut("{stockAdjustmentId}")]
        public async Task<IActionResult> Update(
            int stockAdjustmentId,
            StockAdjustment stockAdjustment)
        {
            if (!await _service.UpdateAsync(
                stockAdjustmentId,
                stockAdjustment))
            {
                return NotFound();
            }

            return Ok();
        }

        // =====================================================
        // DELETE
        // =====================================================

        [HttpDelete("{stockAdjustmentId}")]
        public async Task<IActionResult> Delete(
            int stockAdjustmentId)
        {
            if (!await _service.DeleteAsync(
                stockAdjustmentId))
            {
                return NotFound();
            }

            return Ok();
        }
    }
}

