using Microsoft.AspNetCore.Mvc;
using Marketplacesellerportal.Models;
using Marketplacesellerportal.GoodsReceiptItems.Interfaces;

namespace Marketplacesellerportal.GoodsReceiptItems.Controllers
{
    [ApiController]
    [Route("api/goods-receipt-note-items")]
    public class GoodsReceiptItemController : ControllerBase
    {
        private readonly IGoodsReceiptItemService _service;

        public GoodsReceiptItemController(
            IGoodsReceiptItemService service)
        {
            _service = service;
        }

        // =========================================================
        // GET ALL
        // GET: /api/goods-receipt-note-items
        // =========================================================

        [HttpGet]
        public async Task<IActionResult> GetAll(
            [FromQuery] string? search,
            [FromQuery] int? page,
            [FromQuery] int? limit,
            [FromQuery] string? sort)
        {
            // Search
            if (!string.IsNullOrWhiteSpace(search))
            {
                var searchResult =
                    await _service.SearchAsync(search);

                return Ok(searchResult);
            }

            // Pagination
            if (page.HasValue || limit.HasValue)
            {
                var result =
                    await _service.GetPagedAsync(
                        page ?? 1,
                        limit ?? 25);

                return Ok(new
                {
                    page = page ?? 1,
                    limit = limit ?? 25,
                    totalCount = result.TotalCount,
                    items = result.Items
                });
            }

            // Sorting
            if (!string.IsNullOrWhiteSpace(sort))
            {
                var sorted =
                    await _service.GetSortedAsync(sort);

                return Ok(sorted);
            }

            return Ok(
                await _service.GetAllAsync());
        }

        // =========================================================
        // STATISTICS
        // GET: /api/goods-receipt-note-items/stats
        // =========================================================

        [HttpGet("stats")]
        public async Task<IActionResult> GetStatistics()
        {
            var result =
                await _service.GetStatisticsAsync();

            return Ok(result);
        }

        // =========================================================
        // GET BY ID
        // GET: /api/goods-receipt-note-items/5
        // =========================================================

        [HttpGet("{goodsReceiptItemId:int}")]
        public async Task<IActionResult> GetById(
            int goodsReceiptItemId)
        {
            var result =
                await _service.GetByIdAsync(
                    goodsReceiptItemId);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        // =========================================================
        // GET BY GOODS RECEIPT NOTE
        // GET: /api/goods-receipt-note-items/grn/10
        // =========================================================

        [HttpGet("grn/{goodsReceiptNoteId:int}")]
        public async Task<IActionResult> GetByGoodsReceiptNote(
            int goodsReceiptNoteId)
        {
            var result =
                await _service
                    .GetByGoodsReceiptNoteIdAsync(
                        goodsReceiptNoteId);

            return Ok(result);
        }

        // =========================================================
        // GET BY GRN + ITEM
        // GET:
        // /api/goods-receipt-note-items/grn/10/item/5
        // =========================================================

        [HttpGet(
            "grn/{goodsReceiptNoteId:int}/item/{goodsReceiptItemId:int}")]
        public async Task<IActionResult>
            GetByGoodsReceiptNoteAndItem(
                int goodsReceiptNoteId,
                int goodsReceiptItemId)
        {
            var result =
                await _service
                    .GetByGoodsReceiptNoteAndItemAsync(
                        goodsReceiptNoteId,
                        goodsReceiptItemId);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        // =========================================================
        // GET BY PRODUCT
        // GET: /api/goods-receipt-note-items/product/5
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
        // GET: /api/goods-receipt-note-items/seller/6
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
        // GET: /api/goods-receipt-note-items/customer/3
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
        // GET:
        // /api/goods-receipt-note-items/seller/6/customer/3
        // =========================================================

        [HttpGet("seller/{sellerId:int}/customer/{customerId:int}")]
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
        // CREATE
        // POST: /api/goods-receipt-note-items
        // =========================================================

        [HttpPost]
        public async Task<IActionResult> Create(
            [FromBody] GoodsReceiptItem goodsReceiptItem)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result =
                await _service.CreateAsync(
                    goodsReceiptItem);

            return CreatedAtAction(
                nameof(GetById),
                new
                {
                    goodsReceiptItemId =
                        result.GoodsReceiptItemId
                },
                result);
        }

        // =========================================================
        // UPDATE
        // PUT: /api/goods-receipt-note-items/5
        // =========================================================

        [HttpPut("{goodsReceiptItemId:int}")]
        public async Task<IActionResult> Update(
            int goodsReceiptItemId,
            [FromBody] GoodsReceiptItem goodsReceiptItem)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var updated =
                await _service.UpdateAsync(
                    goodsReceiptItemId,
                    goodsReceiptItem);

            if (!updated)
                return NotFound();

            return Ok(new
            {
                message =
                    "Goods Receipt Item updated successfully."
            });
        }

        // =========================================================
        // DELETE
        // DELETE: /api/goods-receipt-note-items/5
        // =========================================================

        [HttpDelete("{goodsReceiptItemId:int}")]
        public async Task<IActionResult> Delete(
            int goodsReceiptItemId)
        {
            var deleted =
                await _service.DeleteAsync(
                    goodsReceiptItemId);

            if (!deleted)
                return NotFound();

            return Ok(new
            {
                message =
                    "Goods Receipt Item deleted successfully."
            });
        }
    }
}

