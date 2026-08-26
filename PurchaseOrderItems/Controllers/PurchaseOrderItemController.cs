using Microsoft.AspNetCore.Mvc;
using Marketplacesellerportal.Models;
using Marketplacesellerportal.PurchaseOrderItems.Interfaces;

namespace Marketplacesellerportal.PurchaseOrderItems.Controllers
{
    [ApiController]
    [Route("api/purchase-order-items")]
    public class PurchaseOrderItemController : ControllerBase
    {
        private readonly IPurchaseOrderItemService _service;

        public PurchaseOrderItemController(
            IPurchaseOrderItemService service)
        {
            _service = service;
        }

        // =====================================================
        // GET ALL / SEARCH / SORT / PAGINATION
        // =====================================================
        //
        // GET /api/purchase-order-items
        //
        // Search:
        // GET /api/purchase-order-items?search=sku-882
        //
        // Sort:
        // GET /api/purchase-order-items?sort=line_no
        //
        // Pagination:
        // GET /api/purchase-order-items?page=1&limit=25
        //
        // =====================================================

        [HttpGet]
        public async Task<IActionResult> GetAll(
            [FromQuery] string? search,
            [FromQuery] string? sort,
            [FromQuery] int? page,
            [FromQuery] int? limit)
        {
            // -------------------------------------------------
            // SEARCH
            // -------------------------------------------------

            if (!string.IsNullOrWhiteSpace(search))
            {
                var searchResult =
                    await _service.SearchAsync(search);

                return Ok(searchResult);
            }

            // -------------------------------------------------
            // PAGINATION
            // -------------------------------------------------

            if (page.HasValue || limit.HasValue)
            {
                int currentPage = page ?? 1;
                int currentLimit = limit ?? 10;

                var result =
                    await _service.GetPagedAsync(
                        currentPage,
                        currentLimit);

                return Ok(new
                {
                    page = currentPage,
                    limit = currentLimit,
                    totalCount = result.TotalCount,
                    items = result.Items
                });
            }

            // -------------------------------------------------
            // SORTING
            // -------------------------------------------------

            if (!string.IsNullOrWhiteSpace(sort))
            {
                var sortedResult =
                    await _service.GetSortedAsync(sort);

                return Ok(sortedResult);
            }

            // -------------------------------------------------
            // DEFAULT GET ALL
            // -------------------------------------------------

            var items =
                await _service.GetAllAsync();

            return Ok(items);
        }

        // =====================================================
        // GET BY ID
        // GET /api/purchase-order-items/{id}
        // =====================================================

        [HttpGet("{purchaseOrderItemId:int}")]
        public async Task<IActionResult> GetById(
            int purchaseOrderItemId)
        {
            var item =
                await _service.GetByIdAsync(
                    purchaseOrderItemId);

            if (item == null)
                return NotFound(new
                {
                    message = "Purchase order item not found."
                });

            return Ok(item);
        }

        // =====================================================
        // GET BY PURCHASE ORDER
        // GET /api/purchase-order-items/purchaseorder/{id}
        // =====================================================

        [HttpGet("purchaseorder/{purchaseOrderId:int}")]
        public async Task<IActionResult> GetByPurchaseOrder(
            int purchaseOrderId)
        {
            var items =
                await _service.GetByPurchaseOrderIdAsync(
                    purchaseOrderId);

            return Ok(items);
        }

        // =====================================================
        // GET PURCHASE ORDER + ITEM
        // =====================================================

        [HttpGet(
            "purchaseorder/{purchaseOrderId:int}/item/{purchaseOrderItemId:int}")]
        public async Task<IActionResult> GetPurchaseOrderItem(
            int purchaseOrderId,
            int purchaseOrderItemId)
        {
            var item =
                await _service.GetByPurchaseOrderAndItemIdAsync(
                    purchaseOrderId,
                    purchaseOrderItemId);

            if (item == null)
                return NotFound(new
                {
                    message =
                        "Purchase order item not found."
                });

            return Ok(item);
        }

        // =====================================================
        // STATISTICS
        // GET /api/purchase-order-items/stats
        // =====================================================

        [HttpGet("stats")]
        public async Task<IActionResult> GetStatistics()
        {
            var statistics =
                await _service.GetStatisticsAsync();

            return Ok(statistics);
        }

        // =====================================================
        // CREATE
        // POST /api/purchase-order-items
        // =====================================================

        [HttpPost]
        public async Task<IActionResult> Create(
            [FromBody] PurchaseOrderItem item)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result =
                await _service.CreateAsync(item);

            return Ok(result);
        }

        // =====================================================
        // UPDATE
        // PUT /api/purchase-order-items/{id}
        // =====================================================

        [HttpPut("{purchaseOrderItemId:int}")]
        public async Task<IActionResult> Update(
            int purchaseOrderItemId,
            [FromBody] PurchaseOrderItem item)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var updated =
                await _service.UpdateAsync(
                    purchaseOrderItemId,
                    item);

            if (!updated)
                return NotFound(new
                {
                    message =
                        "Purchase order item not found."
                });

            return Ok(new
            {
                message =
                    "Purchase order item updated successfully."
            });
        }

        // =====================================================
        // DELETE
        // DELETE /api/purchase-order-items/{id}
        // =====================================================

        [HttpDelete("{purchaseOrderItemId:int}")]
        public async Task<IActionResult> Delete(
            int purchaseOrderItemId)
        {
            var deleted =
                await _service.DeleteAsync(
                    purchaseOrderItemId);

            if (!deleted)
                return NotFound(new
                {
                    message =
                        "Purchase order item not found."
                });

            return Ok(new
            {
                message =
                    "Purchase order item deleted successfully."
            });
        }
    }
}