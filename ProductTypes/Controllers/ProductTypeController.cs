
using Marketplacesellerportal.ProductTypes.DTOs;
using Marketplacesellerportal.ProductTypes.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Marketplacesellerportal.ProductTypes.Controllers
{
    [ApiController]
    [Route("api/product-types")]
    public class ProductTypeController : ControllerBase
    {
        private readonly IProductTypeService _service;

        public ProductTypeController(
            IProductTypeService service)
        {
            _service = service;
        }

        // =========================================================
        // GET ALL
        //
        // GET /api/product-types
        //
        // GET /api/product-types?search=electronic
        //
        // GET /api/product-types?status=active
        //
        // GET /api/product-types?search=electronic&status=active
        //
        // GET /api/product-types?sort=name_desc
        //
        // GET /api/product-types?page=1&limit=10
        // =========================================================

        [HttpGet]
        public async Task<IActionResult> GetAll(
            [FromQuery] string? search,
            [FromQuery] string? status,
            [FromQuery] string? sort,
            [FromQuery] int? page,
            [FromQuery] int? limit)
        {
            // =====================================================
            // PAGINATION
            // =====================================================

            if (page.HasValue || limit.HasValue)
            {
                var currentPage = page ?? 1;
                var currentLimit = limit ?? 10;

                if (currentPage < 1)
                    currentPage = 1;

                if (currentLimit < 1)
                    currentLimit = 10;

                if (currentLimit > 100)
                    currentLimit = 100;

                var result =
                    await _service.GetPagedAsync(
                        currentPage,
                        currentLimit);

                var totalPages =
                    result.TotalCount == 0
                        ? 0
                        : (int)Math.Ceiling(
                            result.TotalCount /
                            (double)currentLimit);

                return Ok(new
                {
                    page = currentPage,
                    limit = currentLimit,
                    totalCount = result.TotalCount,
                    totalPages = totalPages,
                    items = result.Items
                });
            }

            // =====================================================
            // SEARCH + STATUS
            // =====================================================

            if (!string.IsNullOrWhiteSpace(search) ||
                !string.IsNullOrWhiteSpace(status))
            {
                var result =
                    await _service.SearchAsync(
                        search,
                        status);

                return Ok(result);
            }

            // =====================================================
            // SORTING
            // =====================================================

            if (!string.IsNullOrWhiteSpace(sort))
            {
                var result =
                    await _service.GetSortedAsync(sort);

                return Ok(result);
            }

            // =====================================================
            // GET ALL
            // =====================================================

            var all =
                await _service.GetAllAsync();

            return Ok(all);
        }


        // =========================================================
        // STATISTICS
        //
        // GET /api/product-types/stats
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
        //
        // GET /api/product-types/1
        // =========================================================

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(
            int id)
        {
            var result =
                await _service.GetByIdAsync(id);

            if (result == null)
            {
                return NotFound(new
                {
                    message =
                        "Product type not found."
                });
            }

            return Ok(result);
        }


        // =========================================================
        // CREATE
        //
        // POST /api/product-types
        // =========================================================

        [HttpPost]
        public async Task<IActionResult> Create(
            [FromBody] ProductTypeModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var result =
                    await _service.CreateAsync(model);

                return CreatedAtAction(
                    nameof(GetById),
                    new
                    {
                        id = result.ProductTypeId
                    },
                    result);
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(new
                {
                    message = ex.Message
                });
            }
        }


        // =========================================================
        // UPDATE
        //
        // PUT /api/product-types/1
        // =========================================================

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(
            int id,
            [FromBody] ProductTypeModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var result =
                    await _service.UpdateAsync(
                        id,
                        model);

                if (result == null)
                {
                    return NotFound(new
                    {
                        message =
                            "Product type not found."
                    });
                }

                return Ok(result);
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(new
                {
                    message = ex.Message
                });
            }
        }


        // =========================================================
        // DELETE
        //
        // DELETE /api/product-types/1
        // =========================================================

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(
            int id)
        {
            var result =
                await _service.DeleteAsync(id);

            if (!result)
            {
                return NotFound(new
                {
                    message =
                        "Product type not found."
                });
            }

            return Ok(new
            {
                message =
                    "Product type deleted successfully."
            });
        }
    }
}

