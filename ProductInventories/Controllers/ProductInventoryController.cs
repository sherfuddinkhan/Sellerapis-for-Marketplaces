using Marketplacesellerportal.ProductInventories.DTOs;
using Marketplacesellerportal.ProductInventories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Marketplacesellerportal.ProductInventories.Controllers
{
    [ApiController]
    [Route("api/product-inventories")]
    public class ProductInventoryController : ControllerBase
    {
        private readonly IProductInventoryService _service;

        public ProductInventoryController(
            IProductInventoryService service)
        {
            _service = service;
        }

        // =========================================================
        // GET ALL / SEARCH / FILTER / SORT / PAGINATION
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
                var currentLimit = limit ?? 15;

                var result = await _service.GetPagedAsync(
                    currentPage,
                    currentLimit);

                var totalPages = result.TotalCount == 0
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
                var result = await _service.SearchAsync(
                    search,
                    status);

                return Ok(result);
            }

            // =====================================================
            // SORT
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
        // GET /api/product-inventories/stats
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
        // GET /api/product-inventories/1
        // =========================================================

        [HttpGet("{productInventoryId:int}")]
        public async Task<IActionResult> GetById(
            int productInventoryId)
        {
            var result =
                await _service.GetByIdAsync(
                    productInventoryId);

            if (result == null)
            {
                return NotFound(new
                {
                    message = "Product inventory not found."
                });
            }

            return Ok(result);
        }

        // =========================================================
        // GET BY PRODUCT
        // GET /api/product-inventories/product/1
        // =========================================================

        [HttpGet("product/{productId:int}")]
        public async Task<IActionResult> GetByProductId(
            int productId)
        {
            var result =
                await _service.GetByProductIdAsync(
                    productId);

            return Ok(result);
        }

        // =========================================================
        // GET BY PRODUCT IDS
        // POST /api/product-inventories/products
        // =========================================================

        [HttpPost("products")]
        public async Task<IActionResult> GetByProductIds(
            [FromBody] IEnumerable<int> productIds)
        {
            var result =
                await _service.GetByProductIdsAsync(
                    productIds);

            return Ok(result);
        }

        // =========================================================
        // GET BY SELLER
        // GET /api/product-inventories/seller/1
        // =========================================================

        [HttpGet("seller/{sellerId:int}")]
        public async Task<IActionResult> GetBySellerId(
            int sellerId)
        {
            var result =
                await _service.GetBySellerIdAsync(
                    sellerId);

            return Ok(result);
        }

        // =========================================================
        // GET BY WAREHOUSE
        // =========================================================

        [HttpGet("warehouse/{warehouseId:int}")]
        public async Task<IActionResult> GetByWarehouseId(
            int warehouseId)
        {
            var result =
                await _service.GetByWarehouseIdAsync(
                    warehouseId);

            return Ok(result);
        }

        // =========================================================
        // GET BY SELLER + CUSTOMER
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
        // GET SPECIFIC INVENTORY
        // =========================================================

        [HttpGet("inventory")]
        public async Task<IActionResult> GetInventory(
            [FromQuery] int productId,
            [FromQuery] int warehouseId,
            [FromQuery] int locationId)
        {
            var result =
                await _service.GetInventoryAsync(
                    productId,
                    warehouseId,
                    locationId);

            if (result == null)
            {
                return NotFound(new
                {
                    message = "Product inventory not found."
                });
            }

            return Ok(result);
        }

        // =========================================================
        // CREATE
        // POST /api/product-inventories
        // =========================================================

        [HttpPost]
        public async Task<IActionResult> Create(
            [FromBody] ProductInventoryModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result =
                await _service.CreateAsync(model);

            return CreatedAtAction(
                nameof(GetById),
                new
                {
                    productInventoryId =
                        result.ProductInventoryId
                },
                result);
        }

        // =========================================================
        // UPDATE
        // PUT /api/product-inventories/1
        // =========================================================

        [HttpPut("{productInventoryId:int}")]
        public async Task<IActionResult> Update(
            int productInventoryId,
            [FromBody] ProductInventoryModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result =
                await _service.UpdateAsync(
                    productInventoryId,
                    model);

            if (!result)
            {
                return NotFound(new
                {
                    message = "Product inventory not found."
                });
            }

            return Ok(new
            {
                message =
                    "Product inventory updated successfully."
            });
        }

        // =========================================================
        // DELETE
        // =========================================================

        [HttpDelete("{productInventoryId:int}")]
        public async Task<IActionResult> Delete(
            int productInventoryId)
        {
            var result =
                await _service.DeleteAsync(
                    productInventoryId);

            if (!result)
            {
                return NotFound(new
                {
                    message = "Product inventory not found."
                });
            }

            return Ok(new
            {
                message =
                    "Product inventory deleted successfully."
            });
        }
    }
}