using Microsoft.AspNetCore.Mvc;
using Marketplacesellerportal.Models;
using Marketplacesellerportal.MarketplaceOrderItems.Interfaces;

namespace Marketplacesellerportal.MarketplaceOrderItems.Controllers
{
    [ApiController]
    [Route("api/marketplace-order-items")]
    public class MarketplaceOrderItemController
        : ControllerBase
    {
        private readonly IMarketplaceOrderItemService
            _service;

        public MarketplaceOrderItemController(
            IMarketplaceOrderItemService service)
        {
            _service = service;
        }

        // =========================================================
        // GET ALL
        // GET /api/marketplace-order-items
        // =========================================================

        [HttpGet]
        public async Task<IActionResult> GetAll(
            [FromQuery] string? search,
            [FromQuery] string? status,
            [FromQuery] int? page,
            [FromQuery] int? limit,
            [FromQuery] string? sort)
        {
            // Search / Status
            if (!string.IsNullOrWhiteSpace(search) ||
                !string.IsNullOrWhiteSpace(status))
            {
                return Ok(
                    await _service.SearchAsync(
                        search,
                        status));
            }

            // Pagination
            if (page.HasValue ||
                limit.HasValue)
            {
                var result =
                    await _service.GetPagedAsync(
                        page ?? 1,
                        limit ?? 20);

                return Ok(new
                {
                    Page = page ?? 1,
                    Limit = limit ?? 20,
                    TotalCount = result.TotalCount,
                    Items = result.Items
                });
            }

            // Sorting
            if (!string.IsNullOrWhiteSpace(sort))
            {
                return Ok(
                    await _service
                        .GetSortedAsync(sort));
            }

            // Normal GET ALL
            return Ok(
                await _service.GetAllAsync());
        }

        // =========================================================
        // GET BY ID
        // GET /api/marketplace-order-items/1
        // =========================================================

        [HttpGet("{marketplaceOrderItemId}")]
        public async Task<IActionResult> GetById(
            int marketplaceOrderItemId)
        {
            var result =
                await _service.GetByIdAsync(
                    marketplaceOrderItemId);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        // =========================================================
        // GET BY MARKETPLACE ORDER
        // =========================================================

        [HttpGet("order/{marketplaceOrderId}")]
        public async Task<IActionResult> GetByMarketplaceOrder(
            int marketplaceOrderId)
        {
            return Ok(
                await _service
                    .GetByMarketplaceOrderIdAsync(
                        marketplaceOrderId));
        }

        // =========================================================
        // GET BY PRODUCT
        // =========================================================

        [HttpGet("product/{productId}")]
        public async Task<IActionResult> GetByProduct(
            int productId)
        {
            return Ok(
                await _service
                    .GetByProductIdAsync(
                        productId));
        }

        // =========================================================
        // GET BY SELLER
        // =========================================================

        [HttpGet("seller/{sellerId}")]
        public async Task<IActionResult> GetBySeller(
            int sellerId)
        {
            return Ok(
                await _service
                    .GetBySellerIdAsync(
                        sellerId));
        }

        // =========================================================
        // GET BY CUSTOMER
        // =========================================================

        [HttpGet("customer/{customerId}")]
        public async Task<IActionResult> GetByCustomer(
            int customerId)
        {
            return Ok(
                await _service
                    .GetByCustomerIdAsync(
                        customerId));
        }

        // =========================================================
        // GET BY SELLER + CUSTOMER
        // =========================================================

        [HttpGet("seller/{sellerId}/customer/{customerId}")]
        public async Task<IActionResult> GetBySellerCustomer(
            int sellerId,
            int customerId)
        {
            return Ok(
                await _service
                    .GetBySellerCustomerAsync(
                        sellerId,
                        customerId));
        }

        // =========================================================
        // GET BY STATUS
        // =========================================================

        [HttpGet("status/{status}")]
        public async Task<IActionResult> GetByStatus(
            string status)
        {
            return Ok(
                await _service
                    .GetByStatusAsync(status));
        }

        // =========================================================
        // STATISTICS
        // GET /api/marketplace-order-items/stats
        // =========================================================

        [HttpGet("stats")]
        public async Task<IActionResult> GetStatistics()
        {
            return Ok(
                await _service
                    .GetStatisticsAsync());
        }

        // =========================================================
        // CREATE
        // =========================================================

        [HttpPost]
        public async Task<IActionResult> Create(
            [FromBody] MarketplaceOrderItem item)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result =
                await _service.CreateAsync(item);

            return CreatedAtAction(
                nameof(GetById),
                new
                {
                    marketplaceOrderItemId =
                        result.MarketplaceOrderItemId
                },
                result);
        }

        // =========================================================
        // UPDATE
        // =========================================================

        [HttpPut("{marketplaceOrderItemId}")]
        public async Task<IActionResult> Update(
            int marketplaceOrderItemId,
            [FromBody] MarketplaceOrderItem item)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var updated =
                await _service.UpdateAsync(
                    marketplaceOrderItemId,
                    item);

            if (!updated)
                return NotFound();

            return Ok(
                "Marketplace Order Item updated successfully.");
        }

        // =========================================================
        // DELETE
        // =========================================================

        [HttpDelete("{marketplaceOrderItemId}")]
        public async Task<IActionResult> Delete(
            int marketplaceOrderItemId)
        {
            var deleted =
                await _service.DeleteAsync(
                    marketplaceOrderItemId);

            if (!deleted)
                return NotFound();

            return Ok(
                "Marketplace Order Item deleted successfully.");
        }
    }
}
