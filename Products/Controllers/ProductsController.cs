
using Marketplacesellerportal.Models;
using Marketplacesellerportal.Products.DTOs;
using Marketplacesellerportal.Products.Interfaces;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Marketplacesellerportal.Products.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _service;

        public ProductsController(IProductService service)
        {
            _service = service;
        }

        // =========================================================
        // GET ALL
        //
        // GET /api/products
        // =========================================================

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.GetAllAsync();

            return Ok(result);
        }


        // =========================================================
        // GET BY ID
        //
        // GET /api/products/1
        // =========================================================

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result =
                await _service.GetByIdAsync(id);

            if (result == null)
            {
                return NotFound(new
                {
                    message = "Product not found."
                });
            }

            return Ok(result);
        }


        // =========================================================
        // GET BY SKU
        //
        // GET /api/products/sku/ABC-001
        // =========================================================

        [HttpGet("sku/{sku}")]
        public async Task<IActionResult> GetBySKU(string sku)
        {
            var result =
                await _service.GetBySKUAsync(sku);

            if (result == null)
            {
                return NotFound(new
                {
                    message = "Product with the specified SKU was not found."
                });
            }

            return Ok(result);
        }


        // =========================================================
        // GET BY SELLER
        //
        // GET /api/products/seller/1
        // =========================================================

        [HttpGet("seller/{sellerId:int}")]
        public async Task<IActionResult> GetBySellerId(
            int sellerId)
        {
            var result =
                await _service.GetBySellerIdAsync(sellerId);

            return Ok(result);
        }


        // =========================================================
        // GET BY CUSTOMER
        //
        // GET /api/products/customer/1
        // =========================================================

        [HttpGet("customer/{customerId:int}")]
        public async Task<IActionResult> GetByCustomerId(
            int customerId)
        {
            var result =
                await _service.GetByCustomerIdAsync(customerId);

            return Ok(result);
        }


        // =========================================================
        // GET BY SELLER + CUSTOMER
        //
        // GET /api/products/seller/1/customer/2
        // =========================================================

        [HttpGet(
            "seller/{sellerId:int}/customer/{customerId:int}")]
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
        // GET BY BRAND
        //
        // GET /api/products/brand/1
        // =========================================================

        [HttpGet("brand/{brandId:int}")]
        public async Task<IActionResult> GetByBrandId(
            int brandId)
        {
            var result =
                await _service.GetByBrandIdAsync(brandId);

            return Ok(result);
        }


        // =========================================================
        // GET BY CATEGORY
        //
        // GET /api/products/category/1
        // =========================================================

        [HttpGet("category/{categoryId:int}")]
        public async Task<IActionResult> GetByCategoryId(
            int categoryId)
        {
            var result =
                await _service.GetByCategoryIdAsync(categoryId);

            return Ok(result);
        }


        // =========================================================
        // GET BY PRODUCT TYPE
        //
        // GET /api/products/product-type/1
        // =========================================================

        [HttpGet("product-type/{productTypeId:int}")]
        public async Task<IActionResult> GetByProductTypeId(
            int productTypeId)
        {
            var result =
                await _service.GetByProductTypeIdAsync(
                    productTypeId);

            return Ok(result);
        }


        // =========================================================
        // GET BY STATUS
        //
        // GET /api/products/status/Active
        // =========================================================

        [HttpGet("status/{status}")]
        public async Task<IActionResult> GetByStatus(
      string status)
        {
            var result =
                await _service.SearchAsync(
                    search: null,
                    status: status,
                    isActive: null,
                    sellerId: null,
                    customerId: null,
                    brandId: null,
                    categoryId: null,
                    productTypeId: null);

            return Ok(result);
        }

        // =========================================================
        // SEARCH
        //
        // GET /api/products/search?search=phone
        // =========================================================

        [HttpGet("search")]
        public async Task<IActionResult> Search(
            [FromQuery] string? search)
        {
            var result =
              await _service.SearchAsync(
        search: search,
        status: null,
        isActive: null,
        sellerId: null,
        customerId: null,
        brandId: null,
        categoryId: null,
        productTypeId: null);

            return Ok(result);
        }


        // =========================================================
        // STATISTICS
        //
        // GET /api/products/stats
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
        //
        // GET /api/products/paged?page=1&limit=15
        // =========================================================

        [HttpGet("paged")]
        public async Task<IActionResult> GetPaged(
            [FromQuery] int page = 1,
            [FromQuery] int limit = 15)
        {
            if (page < 1)
                page = 1;

            if (limit < 1)
                limit = 15;

            if (limit > 100)
                limit = 100;

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
        // SORTING
        //
        // GET /api/products/sorted?sort=name_asc
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
        //
        // POST /api/products
        // =========================================================

        [HttpPost]
        public async Task<IActionResult> Create(
            [FromBody] CreateProductDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var result =
                    await _service.CreateAsync(dto);

                return CreatedAtAction(
                    nameof(GetById),
                    new
                    {
                        id = result.ProductId
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
        // PUT /api/products/1
        // =========================================================

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(
            int id,
            [FromBody] UpdateProductDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var result =
                    await _service.UpdateAsync(
                        id,
                        dto);

                if (result == null)
                {
                    return NotFound(new
                    {
                        message = "Product not found."
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
        // DELETE /api/products/1
        // =========================================================

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(
            int id)
        {
            var deleted =
                await _service.DeleteAsync(id);

            if (!deleted)
            {
                return NotFound(new
                {
                    message = "Product not found."
                });
            }

            return Ok(new
            {
                message =
                    "Product deleted successfully."
            });
        }
    }
}
