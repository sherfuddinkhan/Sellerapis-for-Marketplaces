using Microsoft.AspNetCore.Mvc;
using Marketplacesellerportal.ProductImages.DTOs;
using Marketplacesellerportal.ProductImages.Interfaces;

namespace Marketplacesellerportal.ProductImages.Controllers
{
    [ApiController]
    [Route("api/product-images")]
    public class ProductImageController : ControllerBase
    {
        private readonly IProductImageService _service;

        public ProductImageController(
            IProductImageService service)
        {
            _service = service;
        }


        // =========================================================
        // GET
        // =========================================================

        [HttpGet]
        public async Task<IActionResult> GetAll(
            [FromQuery] string? search,
            [FromQuery] string? sort,
            [FromQuery] int? page,
            [FromQuery] int? limit)
        {
            // Pagination
            if (page.HasValue || limit.HasValue)
            {
                int currentPage = page ?? 1;

                int pageSize = limit ?? 24;

                var result =
                    await _service.GetPagedAsync(
                        currentPage,
                        pageSize);

                return Ok(new
                {
                    page = currentPage,
                    limit = pageSize,
                    totalCount = result.TotalCount,

                    totalPages =
                        (int)Math.Ceiling(
                            result.TotalCount /
                            (double)pageSize),

                    items = result.Items
                });
            }


            // Search
            if (!string.IsNullOrWhiteSpace(search))
            {
                return Ok(
                    await _service.SearchAsync(search));
            }


            // Sorting
            if (!string.IsNullOrWhiteSpace(sort))
            {
                return Ok(
                    await _service.GetSortedAsync(sort));
            }


            // Get all
            return Ok(
                await _service.GetAllAsync());
        }


        // =========================================================
        // GET BY ID
        // =========================================================

        [HttpGet("{productImageId}")]
        public async Task<IActionResult> GetById(
            int productImageId)
        {
            var result =
                await _service.GetByIdAsync(
                    productImageId);

            if (result == null)
                return NotFound();

            return Ok(result);
        }


        // =========================================================
        // GET BY PRODUCT
        // =========================================================

        [HttpGet("product/{productId}")]
        public async Task<IActionResult> GetByProduct(
            int productId)
        {
            return Ok(
                await _service.GetByProductIdAsync(
                    productId));
        }


        // =========================================================
        // PRIMARY IMAGES
        // =========================================================

        [HttpGet("primary")]
        public async Task<IActionResult> GetPrimaryImages()
        {
            return Ok(
                await _service.GetPrimaryImagesAsync());
        }


        // =========================================================
        // PRIMARY IMAGE
        // =========================================================

        [HttpGet("primary/{productId}")]
        public async Task<IActionResult> GetPrimaryImage(
            int productId)
        {
            var result =
                await _service.GetPrimaryImageAsync(
                    productId);

            if (result == null)
                return NotFound();

            return Ok(result);
        }


        // =========================================================
        // STATISTICS
        // =========================================================

        [HttpGet("stats")]
        public async Task<IActionResult> GetStatistics()
        {
            return Ok(
                await _service.GetStatisticsAsync());
        }


        // =========================================================
        // CREATE
        // =========================================================

        [HttpPost]
        public async Task<IActionResult> Create(
            ProductImageModel productImage)
        {
            var result =
                await _service.CreateAsync(
                    productImage);

            return Ok(result);
        }


        // =========================================================
        // UPDATE
        // =========================================================

        [HttpPut("{productImageId}")]
        public async Task<IActionResult> Update(
            int productImageId,
            ProductImageModel productImage)
        {
            var result =
                await _service.UpdateAsync(
                    productImageId,
                    productImage);

            if (!result)
                return NotFound();

            return Ok();
        }


        // =========================================================
        // DELETE
        // =========================================================

        [HttpDelete("{productImageId}")]
        public async Task<IActionResult> Delete(
            int productImageId)
        {
            var result =
                await _service.DeleteAsync(
                    productImageId);

            if (!result)
                return NotFound();

            return Ok();
        }
    }
}