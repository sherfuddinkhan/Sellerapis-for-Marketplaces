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
        // GET ALL
        // GET /api/product-attributes
        // =========================================================

        [HttpGet]
        public async Task<IActionResult> GetAll(
            [FromQuery] string? search,
            [FromQuery] string? sort,
            [FromQuery] int? page,
            [FromQuery] int? limit)
        {
            // SEARCH
            if (!string.IsNullOrWhiteSpace(search))
            {
                var searchResult =
                    await _service.SearchAsync(search);

                return Ok(searchResult);
            }

            // PAGINATION
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

            // SORTING
            if (!string.IsNullOrWhiteSpace(sort))
            {
                var sortedResult =
                    await _service.GetSortedAsync(sort);

                return Ok(sortedResult);
            }

            // ALL RECORDS
            var result =
                await _service.GetAllAsync();

            return Ok(result);
        }


        // =========================================================
        // GET ALL - EXPLICIT
        // GET /api/product-attributes/all
        // =========================================================

        [HttpGet("all")]
        public async Task<IActionResult> GetAllAttributes()
        {
            var result =
                await _service.GetAllAsync();

            return Ok(result);
        }


        // =========================================================
        // GET BY ID
        // GET /api/product-attributes/1
        // =========================================================

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            if (id <= 0)
            {
                return BadRequest(new
                {
                    message =
                        "Product attribute ID must be greater than 0."
                });
            }

            var result =
                await _service.GetByIdAsync(id);

            if (result == null)
            {
                return NotFound(new
                {
                    message =
                        "Product attribute not found."
                });
            }

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
            if (productId <= 0)
            {
                return BadRequest(new
                {
                    message =
                        "Product ID must be greater than 0."
                });
            }

            var result =
                await _service.GetByProductIdAsync(productId);

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
            {
                return BadRequest(new
                {
                    message =
                        "Attribute name is required."
                });
            }

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

            if (productAttribute == null)
            {
                return BadRequest(new
                {
                    message =
                        "Product attribute data is required."
                });
            }

            var result =
                await _service.CreateAsync(productAttribute);

            if (result == null)
            {
                return BadRequest(new
                {
                    message =
                        "Unable to create product attribute."
                });
            }

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
            if (id <= 0)
            {
                return BadRequest(new
                {
                    message =
                        "Product attribute ID must be greater than 0."
                });
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (productAttribute == null)
            {
                return BadRequest(new
                {
                    message =
                        "Product attribute data is required."
                });
            }

            var updated =
                await _service.UpdateAsync(
                    id,
                    productAttribute);

            if (!updated)
            {
                return NotFound(new
                {
                    message =
                        "Product attribute not found."
                });
            }

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
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0)
            {
                return BadRequest(new
                {
                    message =
                        "Product attribute ID must be greater than 0."
                });
            }

            var deleted =
                await _service.DeleteAsync(id);

            if (!deleted)
            {
                return NotFound(new
                {
                    message =
                        "Product attribute not found."
                });
            }

            return Ok(new
            {
                message =
                    "Product attribute deleted successfully."
            });
        }
    }
}