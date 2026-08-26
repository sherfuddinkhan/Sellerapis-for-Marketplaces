using Marketplacesellerportal.Models;
using Marketplacesellerportal.ProductPrices.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Marketplacesellerportal.ProductPrices.Controllers
{
    [ApiController]
    [Route("api/product-prices")]
    public class ProductPriceController : ControllerBase
    {
        private readonly IProductPriceService _service;

        public ProductPriceController(
            IProductPriceService service)
        {
            _service = service;
        }

        // =========================================================
        // GET ALL / SEARCH / FILTER / SORT
        //
        // GET /api/product-prices
        // GET /api/product-prices?search=wholesale&min=10
        // GET /api/product-prices?sort=amount_desc
        // =========================================================

        [HttpGet]
        public async Task<IActionResult> GetAll(
            [FromQuery] string? search,
            [FromQuery] decimal? min,
            [FromQuery] decimal? max,
            [FromQuery] string? sort)
        {
            // SEARCH / FILTER
            if (!string.IsNullOrWhiteSpace(search) ||
                min.HasValue ||
                max.HasValue)
            {
                return Ok(
                    await _service.SearchAsync(
                        search,
                        min,
                        max));
            }

            // SORT
            if (!string.IsNullOrWhiteSpace(sort))
            {
                return Ok(
                    await _service.GetSortedAsync(
                        sort));
            }

            // ALL
            return Ok(
                await _service.GetAllAsync());
        }

        // =========================================================
        // PAGINATION
        //
        // GET /api/product-prices?page=1&limit=15
        // =========================================================

        [HttpGet("paged")]
        public async Task<IActionResult> GetPaged(
            [FromQuery] int page = 1,
            [FromQuery] int limit = 15)
        {
            var result =
                await _service.GetPagedAsync(
                    page,
                    limit);

            var totalPages =
                result.TotalCount == 0
                    ? 0
                    : (int)Math.Ceiling(
                        result.TotalCount /
                        (double)limit);

            return Ok(new
            {
                page,
                limit,
                totalCount = result.TotalCount,
                totalPages,
                items = result.Items
            });
        }

        // =========================================================
        // STATISTICS
        //
        // GET /api/product-prices/stats
        // =========================================================

        [HttpGet("stats")]
        public async Task<IActionResult>
            GetStatistics()
        {
            return Ok(
                await _service
                    .GetStatisticsAsync());
        }

        // =========================================================
        // GET BY ID
        // =========================================================

        [HttpGet("{productPriceId:int}")]
        public async Task<IActionResult>
            GetById(int productPriceId)
        {
            var result =
                await _service.GetByIdAsync(
                    productPriceId);

            if (result == null)
                return NotFound(new
                {
                    message =
                        "Product price not found."
                });

            return Ok(result);
        }

        // =========================================================
        // GET BY PRODUCT
        // =========================================================

        [HttpGet("product/{productId:int}")]
        public async Task<IActionResult>
            GetByProductId(int productId)
        {
            return Ok(
                await _service
                    .GetByProductIdAsync(
                        productId));
        }

        // =========================================================
        // CREATE
        // =========================================================

        [HttpPost]
        public async Task<IActionResult>
            Create(ProductPrice model)
        {
            if (model == null)
                return BadRequest();

            var result =
                await _service.CreateAsync(
                    model);

            return Ok(result);
        }

        // =========================================================
        // UPDATE
        // =========================================================

        [HttpPut("{productPriceId:int}")]
        public async Task<IActionResult>
            Update(
                int productPriceId,
                ProductPrice model)
        {
            if (model == null)
                return BadRequest();

            var result =
                await _service.UpdateAsync(
                    productPriceId,
                    model);

            if (!result)
                return NotFound(new
                {
                    message =
                        "Product price not found."
                });

            return Ok(new
            {
                message =
                    "Product price updated successfully."
            });
        }

        // =========================================================
        // DELETE
        // =========================================================

        [HttpDelete("{productPriceId:int}")]
        public async Task<IActionResult>
            Delete(int productPriceId)
        {
            var result =
                await _service.DeleteAsync(
                    productPriceId);

            if (!result)
                return NotFound(new
                {
                    message =
                        "Product price not found."
                });

            return Ok(new
            {
                message =
                    "Product price deleted successfully."
            });
        }
    }
}