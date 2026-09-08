using Microsoft.AspNetCore.Mvc;
using Marketplacesellerportal.Models;
using Marketplacesellerportal.MarketplaceOrderItems.Interfaces;
using MarketplaceOrderItemEntity =
    MarketplaceSellerPortal.Models.MarketplaceOrderItem;
namespace Marketplacesellerportal.MarketplaceOrderItems.Controllers
{
    [ApiController]
    [Route("api/marketplace-order-items")]
    public class MarketplaceOrderItemController
        : ControllerBase
    {
        private readonly IMarketplaceOrderItemService _service;

        public MarketplaceOrderItemController(
            IMarketplaceOrderItemService service)
        {
            _service = service;
        }
     
[HttpGet("all")]
public async Task<IActionResult> GetAllMarketplaceOrderItems()
        {
            var result =
                await _service.GetAllAsync();

            return Ok(result);
        }


        // =========================================================
        // GET ALL
        //
        // GET /api/marketplace-order-items
        //
        // Supports:
        //   ?search=
        //   ?status=
        //   ?page=
        //   ?limit=
        //   ?sort=
        // =========================================================

        [HttpGet]
        public async Task<IActionResult> GetAll(
            [FromQuery] string? search,
            [FromQuery] string? status,
            [FromQuery] int? page,
            [FromQuery] int? limit,
            [FromQuery] string? sort)
        {
            // -----------------------------------------------------
            // SEARCH / STATUS
            // -----------------------------------------------------

            if (!string.IsNullOrWhiteSpace(search) ||
                !string.IsNullOrWhiteSpace(status))
            {
                var result =
                    await _service.SearchAsync(
                        search,
                        status);

                return Ok(result);
            }

            // -----------------------------------------------------
            // PAGINATION
            // -----------------------------------------------------

            if (page.HasValue ||
                limit.HasValue)
            {
                var result =
                    await _service.GetPagedAsync(
                        page ?? 1,
                        limit ?? 20);

                return Ok(new
                {
                    page = page ?? 1,
                    limit = limit ?? 20,
                    totalCount = result.TotalCount,
                    totalPages =
                        (int)Math.Ceiling(
                            result.TotalCount /
                            (double)(limit ?? 20)),
                    items = result.Items
                });
            }

            // -----------------------------------------------------
            // SORTING
            // -----------------------------------------------------

            if (!string.IsNullOrWhiteSpace(sort))
            {
                var result =
                    await _service.GetSortedAsync(sort);

                return Ok(result);
            }

            // -----------------------------------------------------
            // NORMAL GET ALL
            // -----------------------------------------------------

            var all =
                await _service.GetAllAsync();

            return Ok(all);
        }

        // =========================================================
        // GET BY ID
        //
        // GET /api/marketplace-order-items/1
        // =========================================================

        [HttpGet("{marketplaceOrderItemId:int}")]
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
        //
        // GET /api/marketplace-order-items/order/1
        // =========================================================

        [HttpGet("order/{marketplaceOrderId:int}")]
        public async Task<IActionResult> GetByMarketplaceOrder(
            int marketplaceOrderId)
        {
            var result =
                await _service
                    .GetByMarketplaceOrderIdAsync(
                        marketplaceOrderId);

            return Ok(result);
        }

        // =========================================================
        // GET BY PRODUCT
        //
        // GET /api/marketplace-order-items/product/6
        // =========================================================

        [HttpGet("product/{productId:int}")]
        public async Task<IActionResult> GetByProduct(
            int productId)
        {
            var result =
                await _service
                    .GetByProductIdAsync(
                        productId);

            return Ok(result);
        }

        // =========================================================
        // GET BY SELLER
        //
        // GET /api/marketplace-order-items/seller/6
        // =========================================================

        [HttpGet("seller/{sellerId:int}")]
        public async Task<IActionResult> GetBySeller(
            int sellerId)
        {
            var result =
                await _service
                    .GetBySellerIdAsync(
                        sellerId);

            return Ok(result);
        }

        // =========================================================
        // GET BY CUSTOMER
        //
        // GET /api/marketplace-order-items/customer/3
        // =========================================================

        [HttpGet("customer/{customerId:int}")]
        public async Task<IActionResult> GetByCustomer(
            int customerId)
        {
            var result =
                await _service
                    .GetByCustomerIdAsync(
                        customerId);

            return Ok(result);
        }

        // =========================================================
        // GET BY SELLER + CUSTOMER
        //
        // GET /api/marketplace-order-items/seller/6/customer/3
        // =========================================================

        [HttpGet(
            "seller/{sellerId:int}/customer/{customerId:int}")]
        public async Task<IActionResult> GetBySellerCustomer(
            int sellerId,
            int customerId)
        {
            var result =
                await _service
                    .GetBySellerCustomerAsync(
                        sellerId,
                        customerId);

            return Ok(result);
        }

        // =========================================================
        // GET BY STATUS
        //
        // GET /api/marketplace-order-items/status/Delivered
        // =========================================================

        [HttpGet("status/{status}")]
        public async Task<IActionResult> GetByStatus(
            string status)
        {
            var result =
                await _service
                    .GetByStatusAsync(status);

            return Ok(result);
        }

        // =========================================================
        // STATISTICS
        //
        // GET /api/marketplace-order-items/stats
        // =========================================================

        [HttpGet("stats")]
        public async Task<IActionResult> GetStatistics()
        {
            var result =
                await _service
                    .GetStatisticsAsync();

            return Ok(result);
        }

        // =========================================================
        // CREATE
        // =========================================================

        [HttpPost]
        public async Task<IActionResult> Create(
            [FromBody] MarketplaceOrderItemEntity  item)
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

        [HttpPut("{marketplaceOrderItemId:int}")]
        public async Task<IActionResult> Update(
            int marketplaceOrderItemId,
            [FromBody] MarketplaceOrderItemEntity  item)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var updated =
                await _service.UpdateAsync(
                    marketplaceOrderItemId,
                    item);

            if (!updated)
                return NotFound();

            return Ok(new
            {
                message =
                    "Marketplace Order Item updated successfully."
            });
        }

        // =========================================================
        // DELETE
        // =========================================================

        [HttpDelete("{marketplaceOrderItemId:int}")]
        public async Task<IActionResult> Delete(
            int marketplaceOrderItemId)
        {
            var deleted =
                await _service.DeleteAsync(
                    marketplaceOrderItemId);

            if (!deleted)
                return NotFound();

            return Ok(new
            {
                message =
                    "Marketplace Order Item deleted successfully."
            });
        }
    }
}