
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
        // GET ALL PURCHASE ORDER ITEMS
        // =====================================================
        //
        // GET:
        // /api/purchase-order-items
        //
        // This API fetches ALL purchase-order-items
        // in one request.
        //
        // =====================================================

        [HttpGet]
        public async Task<IActionResult> GetAllPurchaseOrderItems()
        {
            try
            {
                var items =
                    await _service.GetAllAsync();

                return Ok(items);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    message =
                        "Failed to fetch purchase order items.",

                    error =
                        ex.Message
                });
            }
        }


        // =====================================================
        // SEARCH / SORT / PAGINATION
        // =====================================================
        //
        // GET:
        // /api/purchase-order-items/search
        //
        // Search:
        // /api/purchase-order-items/search?search=sku-882
        //
        // Sort:
        // /api/purchase-order-items/search?sort=line_no
        //
        // Pagination:
        // /api/purchase-order-items/search?page=1&limit=25
        //
        // =====================================================

        [HttpGet("search")]
        public async Task<IActionResult> SearchSortAndPaginate(
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
                    await _service.SearchAsync(
                        search);

                return Ok(searchResult);
            }


            // -------------------------------------------------
            // PAGINATION
            // -------------------------------------------------

            if (page.HasValue || limit.HasValue)
            {
                int currentPage =
                    page ?? 1;

                int currentLimit =
                    limit ?? 10;

                var result =
                    await _service.GetPagedAsync(
                        currentPage,
                        currentLimit);

                return Ok(new
                {
                    page = currentPage,

                    limit = currentLimit,

                    totalCount =
                        result.TotalCount,

                    items =
                        result.Items
                });
            }


            // -------------------------------------------------
            // SORTING
            // -------------------------------------------------

            if (!string.IsNullOrWhiteSpace(sort))
            {
                var sortedResult =
                    await _service.GetSortedAsync(
                        sort);

                return Ok(sortedResult);
            }


            // -------------------------------------------------
            // DEFAULT
            // -------------------------------------------------

            var items =
                await _service.GetAllAsync();

            return Ok(items);
        }


        // =====================================================
        // GET BY ID
        // =====================================================
        //
        // GET:
        // /api/purchase-order-items/{id}
        //
        // =====================================================

        [HttpGet("{purchaseOrderItemId:int}")]
        public async Task<IActionResult> GetPurchaseOrderItemById(
            int purchaseOrderItemId)
        {
            var item =
                await _service.GetByIdAsync(
                    purchaseOrderItemId);

            if (item == null)
            {
                return NotFound(new
                {
                    message =
                        "Purchase order item not found."
                });
            }

            return Ok(item);
        }


        // =====================================================
        // GET BY PURCHASE ORDER
        // =====================================================
        //
        // GET:
        // /api/purchase-order-items/purchaseorder/{id}
        //
        // =====================================================

        [HttpGet("purchaseorder/{purchaseOrderId:int}")]
        public async Task<IActionResult> GetItemsByPurchaseOrder(
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
        //
        // GET:
        // /api/purchase-order-items/purchaseorder/{purchaseOrderId}/item/{purchaseOrderItemId}
        //
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
            {
                return NotFound(new
                {
                    message =
                        "Purchase order item not found."
                });
            }

            return Ok(item);
        }


        // =====================================================
        // STATISTICS
        // =====================================================
        //
        // GET:
        // /api/purchase-order-items/stats
        //
        // =====================================================

        [HttpGet("stats")]
        public async Task<IActionResult> GetPurchaseOrderItemStatistics()
        {
            var statistics =
                await _service.GetStatisticsAsync();

            return Ok(statistics);
        }


        // =====================================================
        // CREATE
        // =====================================================
        //
        // POST:
        // /api/purchase-order-items
        //
        // =====================================================

        [HttpPost]
        public async Task<IActionResult> CreatePurchaseOrderItem(
            [FromBody] PurchaseOrderItem item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result =
                await _service.CreateAsync(
                    item);

            return Ok(result);
        }


        // =====================================================
        // UPDATE
        // =====================================================
        //
        // PUT:
        // /api/purchase-order-items/{id}
        //
        // =====================================================

        [HttpPut("{purchaseOrderItemId:int}")]
        public async Task<IActionResult> UpdatePurchaseOrderItem(
            int purchaseOrderItemId,
            [FromBody] PurchaseOrderItem item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var updated =
                await _service.UpdateAsync(
                    purchaseOrderItemId,
                    item);

            if (!updated)
            {
                return NotFound(new
                {
                    message =
                        "Purchase order item not found."
                });
            }

            return Ok(new
            {
                message =
                    "Purchase order item updated successfully."
            });
        }


        // =====================================================
        // DELETE
        // =====================================================
        //
        // DELETE:
        // /api/purchase-order-items/{id}
        //
        // =====================================================

        [HttpDelete("{purchaseOrderItemId:int}")]
        public async Task<IActionResult> DeletePurchaseOrderItem(
            int purchaseOrderItemId)
        {
            var deleted =
                await _service.DeleteAsync(
                    purchaseOrderItemId);

            if (!deleted)
            {
                return NotFound(new
                {
                    message =
                        "Purchase order item not found."
                });
            }

            return Ok(new
            {
                message =
                    "Purchase order item deleted successfully."
            });
        }
    }
}

