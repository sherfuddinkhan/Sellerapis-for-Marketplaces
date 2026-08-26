using Microsoft.AspNetCore.Mvc;
using Marketplacesellerportal.Models;
using Marketplacesellerportal.ProductAttributes.Interfaces;

namespace Marketplacesellerportal.ProductAttributes.Controllers
{
    [ApiController]
    [Route("api/product-attributes")]
    public class ProductAttributeController : ControllerBase
    {
        private readonly IProductAttributeService _service;

        public ProductAttributeController(
            IProductAttributeService service)
        {
            _service = service;
        }

        // =========================================================
        // GET ALL / SEARCH / SORT / PAGINATION
        // =========================================================
        //
        // GET /api/product-attributes
        //
        // SEARCH:
        // GET /api/product-attributes?search=color
        //
        // SORT:
        // GET /api/product-attributes?sort=name_asc
        //
        // PAGINATION:
        // GET /api/product-attributes?page=1&limit=15
        //
        // =========================================================

        [HttpGet]
        public async Task<IActionResult> GetAll(
            [FromQuery] string? search,
            [FromQuery] string? sort,
            [FromQuery] int? page,
            [FromQuery] int? limit)
        {
            // -----------------------------------------------------
            // SEARCH
            // -----------------------------------------------------

            if (!string.IsNullOrWhiteSpace(search))
            {
                var searchResult =
                    await _service.SearchAsync(search);

                return Ok(searchResult);
            }

            // -----------------------------------------------------
            // PAGINATION
            // -----------------------------------------------------

            if (page.HasValue || limit.HasValue)
            {
                int currentPage = page ?? 1;
                int currentLimit = limit ?? 15;

                if (currentPage < 1)
                    currentPage = 1;

                if (currentLimit < 1)
                    currentLimit = 15;

                if (currentLimit > 100)
                    currentLimit = 100;

                var pagedResult =
                    await _service.GetPagedAsync(
                        currentPage,
                        currentLimit);

                return Ok(new
                {
                    page = currentPage,
                    limit = currentLimit,
                    totalCount = pagedResult.TotalCount,
                    items = pagedResult.Items
                });
            }

            // -----------------------------------------------------
            // SORTING
            // -----------------------------------------------------

            if (!string.IsNullOrWhiteSpace(sort))
            {
                var sortedResult =
                    await _service.GetSortedAsync(sort);

                return Ok(sortedResult);
            }

            // -----------------------------------------------------
            // GET ALL
            // -----------------------------------------------------

            return Ok(
                await _service.GetAllAsync());
        }


        // =========================================================
        // GET BY ID
        // GET /api/product-attributes/1
        // =========================================================

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(
            int id)
        {
            var result =
                await _service.GetByIdAsync(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }


        // =========================================================
        // GET BY PRODUCT
        // GET /api/product-attributes/product/1
        // =========================================================

        [HttpGet("product/{productId:int}")]
        public async Task<IActionResult> GetByProduct(
            int productId)
        {
            var result =
                await _service.GetByProductIdAsync(
                    productId);

            return Ok(result);
        }


        // =========================================================
        // GET BY ATTRIBUTE NAME
        // GET /api/product-attributes/attribute/color
        // =========================================================

        [HttpGet("attribute/{attributeName}")]
        public async Task<IActionResult> GetByAttribute(
            string attributeName)
        {
            if (string.IsNullOrWhiteSpace(attributeName))
                return BadRequest(
                    "Attribute name is required.");

            var result =
                await _service.GetByAttributeNameAsync(
                    attributeName);

            return Ok(result);
        }


        // =========================================================
        // STATISTICS
        // GET /api/product-attributes/stats
        // =========================================================

        [HttpGet("stats")]
        public async Task<IActionResult> GetStatistics()
        {
            var result =
                await _service.GetStatisticsAsync();

            return Ok(result);
        }


        // =========================================================
        // CREATE
        // POST /api/product-attributes
        // =========================================================

        [HttpPost]
        public async Task<IActionResult> Create(
            [FromBody] ProductAttribute productAttribute)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result =
                await _service.CreateAsync(
                    productAttribute);

            return CreatedAtAction(
                nameof(GetById),
                new
                {
                    id = result.ProductAttributeId
                },
                result);
        }


        // =========================================================
        // UPDATE
        // PUT /api/product-attributes/1
        // =========================================================

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(
            int id,
            [FromBody] ProductAttribute productAttribute)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var updated =
                await _service.UpdateAsync(
                    id,
                    productAttribute);

            if (!updated)
                return NotFound();

            return Ok(new
            {
                message =
                    "Product attribute updated successfully."
            });
        }


        // =========================================================
        // DELETE
        // DELETE /api/product-attributes/1
        // =========================================================

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(
            int id)
        {
            var deleted =
                await _service.DeleteAsync(id);

            if (!deleted)
                return NotFound();

            return Ok(new
            {
                message =
                    "Product attribute deleted successfully."
            });
        }
    }
}

