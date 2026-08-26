using Marketplacesellerportal.MarketplaceReturns.Interfaces;
using Marketplacesellerportal.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;
using System.Globalization;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using static System.Runtime.InteropServices.JavaScript.JSType;
using MarketplaceReturnModel = Marketplacesellerportal.Models.MarketplaceReturn;

namespace Marketplacesellerportal.MarketplaceReturn.Controllers
{
    [ApiController]
    [Route("api/marketplace-returns")]
    public class MarketplaceReturnController : ControllerBase
    {
        private readonly IMarketplaceReturnService _service;

        public MarketplaceReturnController(
            IMarketplaceReturnService service)
        {
            _service = service;
        }

        // =========================================================
        // GET ALL
        // GET: /api/marketplace-returns
        // =========================================================
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.GetAllAsync();

            return Ok(result);
        }

        // =========================================================
        // GET BY ID
        // GET: /api/marketplace-returns/1
        // =========================================================
        [HttpGet("{marketplaceReturnId}")]
        public async Task<IActionResult> GetById(
            int marketplaceReturnId)
        {
            var result =
                await _service.GetByIdAsync(marketplaceReturnId);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        // =========================================================
        // GET BY MARKETPLACE ORDER ITEM
        // GET: /api/marketplace-returns/order-item/1
        // =========================================================
        [HttpGet("order-item/{marketplaceOrderItemId}")]
        public async Task<IActionResult> GetByMarketplaceOrderItem(
            int marketplaceOrderItemId)
        {
            var result =
                await _service.GetByMarketplaceOrderItemIdAsync(
                    marketplaceOrderItemId);

            return Ok(result);
        }

        // =========================================================
        // GET BY SELLER
        // GET: /api/marketplace-returns/seller/6
        // =========================================================
        [HttpGet("seller/{sellerId}")]
        public async Task<IActionResult> GetBySeller(
            int sellerId)
        {
            var result =
                await _service.GetBySellerIdAsync(sellerId);

            return Ok(result);
        }

        // =========================================================
        // GET BY CUSTOMER
        // GET: /api/marketplace-returns/customer/3
        // =========================================================
        [HttpGet("customer/{customerId}")]
        public async Task<IActionResult> GetByCustomer(
            int customerId)
        {
            var result =
                await _service.GetByCustomerIdAsync(customerId);

            return Ok(result);
        }

        // =========================================================
        // GET BY PRODUCT
        // GET: /api/marketplace-returns/product/10
        // =========================================================
        [HttpGet("product/{productId}")]
        public async Task<IActionResult> GetByProduct(
            int productId)
        {
            var result =
                await _service.GetByProductIdAsync(productId);

            return Ok(result);
        }

        // =========================================================
        // GET BY SELLER + CUSTOMER
        // GET: /api/marketplace-returns/seller/6/customer/3
        // =========================================================
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

        // =========================================================
        // GET BY STATUS
        // GET: /api/marketplace-returns/status/pending
        // =========================================================
        [HttpGet("status/{status}")]
        public async Task<IActionResult> GetByStatus(
            string status)
        {
            var result =
                await _service.GetByStatusAsync(status);

            return Ok(result);
        }

        // =========================================================
        // GET BY SKU
        // GET: /api/marketplace-returns/sku/SKU-001
        // =========================================================
        [HttpGet("sku/{sku}")]
        public async Task<IActionResult> GetBySKU(
            string sku)
        {
            var result =
                await _service.GetBySKUAsync(sku);

            return Ok(result);
        }

        // =========================================================
        // GET BY RETURN NUMBER
        // GET: /api/marketplace-returns/return-number/RET-001
        // =========================================================
        [HttpGet("return-number/{returnNumber}")]
        public async Task<IActionResult> GetByReturnNumber(
            string returnNumber)
        {
            var result =
                await _service.GetByReturnNumberAsync(
                    returnNumber);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        // =========================================================
        // GET RETURN BY ORDER ITEM + RETURN ID
        // GET: /api/marketplace-returns/order-item/1/return/5
        // =========================================================
        [HttpGet(
            "order-item/{marketplaceOrderItemId}/return/{marketplaceReturnId}")]
        public async Task<IActionResult> GetMarketplaceReturn(
            int marketplaceOrderItemId,
            int marketplaceReturnId)
        {
            var result =
                await _service.GetMarketplaceReturnAsync(
                    marketplaceOrderItemId,
                    marketplaceReturnId);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        // =========================================================
        // SEARCH
        // GET: /api/marketplace-returns/search?search=RET-001
        // =========================================================
        [HttpGet("search")]
        public async Task<IActionResult> Search(
            [FromQuery] string? search)
        {
            var result =
                await _service.SearchAsync(search);

            return Ok(result);
        }

        // =========================================================
        // STATISTICS
        // GET: /api/marketplace-returns/stats
        // =========================================================
        [HttpGet("stats")]
        public async Task<IActionResult> GetStatistics()
        {
            var result =
                await _service.GetStatisticsAsync();

            return Ok(result);
        }

        // =========================================================
        // PAGINATION
        // GET: /api/marketplace-returns?page=1&limit=20
        // =========================================================
        [HttpGet("paged")]
        public async Task<IActionResult> GetPaged(
            [FromQuery] int page = 1,
            [FromQuery] int limit = 20)
        {
            var result =
                await _service.GetPagedAsync(
                    page,
                    limit);

            return Ok(new
            {
                page,
                limit,
                totalCount = result.TotalCount,
                totalPages = (int)Math.Ceiling(
                    result.TotalCount /
                    (double)limit),
                items = result.Items
            });
        }

        // =========================================================
        // SORTING
        // GET: /api/marketplace-returns/sorted?sort=date_desc
        // =========================================================
        [HttpGet("sorted")]
        public async Task<IActionResult> GetSorted(
            [FromQuery] string? sort)
        {
            var result =
                await _service.GetSortedAsync(sort);

            return Ok(result);
        }

        // =========================================================
        // CREATE
        // POST: /api/marketplace-returns
        // =========================================================
        [HttpPost]
        public async Task<IActionResult> Create(
            [FromBody] MarketplaceReturnModel marketplaceReturn)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result =
                await _service.CreateAsync(
                    marketplaceReturn);

            return CreatedAtAction(
                nameof(GetById),
                new
                {
                    marketplaceReturnId =
                        result.MarketplaceReturnId
                },
                result);
        }

        // =========================================================
        // UPDATE
        // PUT: /api/marketplace-returns/1
        // =========================================================
        [HttpPut("{marketplaceReturnId}")]
        public async Task<IActionResult> Update(
            int marketplaceReturnId,
            [FromBody] MarketplaceReturnModel marketplaceReturn)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var updated =
                await _service.UpdateAsync(
                    marketplaceReturnId,
                    marketplaceReturn);

            if (!updated)
                return NotFound();

            return Ok(new
            {
                message =
                    "Marketplace return updated successfully."
            });
        }

        // =========================================================
        // DELETE
        // DELETE: /api/marketplace-returns/1
        // =========================================================
        [HttpDelete("{marketplaceReturnId}")]
        public async Task<IActionResult> Delete(
            int marketplaceReturnId)
        {
            var deleted =
                await _service.DeleteAsync(
                    marketplaceReturnId);

            if (!deleted)
                return NotFound();

            return Ok(new
            {
                message =
                    "Marketplace return deleted successfully."
            });
        }
    }
}
