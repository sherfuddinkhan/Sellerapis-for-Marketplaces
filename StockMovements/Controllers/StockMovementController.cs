using Microsoft.AspNetCore.Mvc;
using Marketplacesellerportal.Models;
using Marketplacesellerportal.StockMovements.Interfaces;

namespace Marketplacesellerportal.StockMovements.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StockMovementController : ControllerBase
    {
        private readonly IStockMovementService _service;

        public StockMovementController(IStockMovementService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpGet("{stockMovementId}")]
        public async Task<IActionResult> GetById(int stockMovementId)
        {
            var result = await _service.GetByIdAsync(stockMovementId);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpGet("seller/{sellerId}")]
        public async Task<IActionResult> GetBySeller(int sellerId)
        {
            return Ok(await _service.GetBySellerIdAsync(sellerId));
        }

        [HttpGet("product/{productId}")]
        public async Task<IActionResult> GetByProduct(int productId)
        {
            return Ok(await _service.GetByProductIdAsync(productId));
        }

        [HttpGet("warehouse/{warehouseId}")]
        public async Task<IActionResult> GetByWarehouse(int warehouseId)
        {
            return Ok(await _service.GetByWarehouseIdAsync(warehouseId));
        }

        [HttpGet("movement/{movementType}")]
        public async Task<IActionResult> GetByMovementType(string movementType)
        {
            return Ok(await _service.GetByMovementTypeAsync(movementType));
        }

        [HttpGet("{sellerId}/{productId}/{warehouseId}/{stockMovementId}")]
        public async Task<IActionResult> GetStockMovement(
            int sellerId,
            int productId,
            int warehouseId,
            int stockMovementId)
        {
            var result = await _service.GetStockMovementAsync(
                sellerId,
                productId,
                warehouseId,
                stockMovementId);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(StockMovement stockMovement)
        {
            return Ok(await _service.CreateAsync(stockMovement));
        }

        [HttpPut("{stockMovementId}")]
        public async Task<IActionResult> Update(
            int stockMovementId,
            StockMovement stockMovement)
        {
            if (!await _service.UpdateAsync(stockMovementId, stockMovement))
                return NotFound();

            return Ok();
        }
        // =====================================================
        // GET BY SELLER + CUSTOMER
        // GET:
        // /api/StockMovement/seller/6/customer/3
        // =====================================================

        [HttpGet("seller/{sellerId}/customer/{customerId}")]
        public async Task<IActionResult> GetBySellerCustomer(
            int sellerId,
            int customerId)
        {
            var result =
                await _service.GetBySellerCustomerAsync(
                    sellerId,
                    customerId);

            return Ok(result);
        }


        // =====================================================
        // SEARCH
        // GET:
        // /api/StockMovement/search?search=Purchase
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
        // /api/StockMovement/sort?sort=date_desc
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
        // /api/StockMovement/page?page=1&limit=15
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
        // /api/StockMovement/statistics
        // =====================================================

        [HttpGet("statistics")]
        public async Task<IActionResult> GetStatistics()
        {
            var result =
                await _service.GetStatisticsAsync();

            return Ok(result);
        }
        [HttpDelete("{stockMovementId}")]
        public async Task<IActionResult> Delete(int stockMovementId)
        {
            if (!await _service.DeleteAsync(stockMovementId))
                return NotFound();

            return Ok();
        }
    }
}
