using Microsoft.AspNetCore.Mvc;
using Marketplacesellerportal.Models;
using Marketplacesellerportal.SalesOrderItems.Interfaces;

namespace Marketplacesellerportal.SalesOrderItems.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SalesOrderItemController : ControllerBase
    {
        private readonly ISalesOrderItemService _service;

        public SalesOrderItemController(
            ISalesOrderItemService service)
        {
            _service = service;
        }


        // =====================================================
        // GET ALL / SEARCH / PAGINATION / SORT
        // =====================================================
        //
        // GET /api/sales-order-items
        //
        // Search:
        // GET /api/sales-order-items?search=sku-551
        //
        // Pagination:
        // GET /api/sales-order-items?page=1&limit=25
        //
        // Sort:
        // GET /api/sales-order-items?sort=line_number
        //
        // =====================================================

        [HttpGet]
        public async Task<IActionResult> GetAll(
            [FromQuery] string? search,
            [FromQuery] int? page,
            [FromQuery] int? limit,
            [FromQuery] string? sort)
        {
            // -------------------------------------------------
            // SEARCH
            // -------------------------------------------------

            if (!string.IsNullOrWhiteSpace(search))
            {
                var result =
                    await _service.SearchAsync(search);

                return Ok(result);
            }


            // -------------------------------------------------
            // SORT
            // -------------------------------------------------

            if (!string.IsNullOrWhiteSpace(sort))
            {
                var result =
                    await _service.GetSortedAsync(sort);

                return Ok(result);
            }


            // -------------------------------------------------
            // PAGINATION
            // -------------------------------------------------

            if (page.HasValue || limit.HasValue)
            {
                int currentPage =
                    page ?? 1;

                int currentLimit =
                    limit ?? 25;

                var result =
                    await _service.GetPagedAsync(
                        currentPage,
                        currentLimit);

                return Ok(new
                {
                    page = currentPage,
                    limit = currentLimit,
                    totalCount = result.TotalCount,
                    items = result.Items
                });
            }


            // -------------------------------------------------
            // GET ALL
            // -------------------------------------------------

            return Ok(
                await _service.GetAllAsync());
        }


        // =====================================================
        // GET BY ID
        // GET:
        // /api/sales-order-items/{id}
        // =====================================================

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result =
                await _service.GetByIdAsync(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }


        // =====================================================
        // GET BY SALES ORDER
        // GET:
        // /api/sales-order-items/salesorder/{salesOrderId}
        // =====================================================

        [HttpGet("salesorder/{salesOrderId}")]
        public async Task<IActionResult> GetBySalesOrder(
            int salesOrderId)
        {
            return Ok(
                await _service.GetBySalesOrderAsync(
                    salesOrderId));
        }


        // =====================================================
        // GET BY PRODUCT
        // GET:
        // /api/sales-order-items/product/{productId}
        // =====================================================

        [HttpGet("product/{productId}")]
        public async Task<IActionResult> GetByProduct(
            int productId)
        {
            return Ok(
                await _service.GetByProductAsync(
                    productId));
        }


        // =====================================================
        // STATISTICS
        // GET:
        // /api/sales-order-items/stats
        // =====================================================

        [HttpGet("stats")]
        public async Task<IActionResult> GetStatistics()
        {
            var result =
                await _service.GetStatisticsAsync();

            return Ok(result);
        }


        // =====================================================
        // CREATE
        // POST:
        // /api/sales-order-items
        // =====================================================

        [HttpPost]
        public async Task<IActionResult> Create(
            SalesOrderItem salesOrderItem)
        {
            var result =
                await _service.CreateAsync(
                    salesOrderItem);

            return Ok(result);
        }


        // =====================================================
        // UPDATE
        // PUT:
        // /api/sales-order-items/{id}
        // =====================================================

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(
            int id,
            SalesOrderItem salesOrderItem)
        {
            if (!await _service.UpdateAsync(
                id,
                salesOrderItem))
            {
                return NotFound();
            }

            return Ok();
        }


        // =====================================================
        // DELETE
        // DELETE:
        // /api/sales-order-items/{id}
        // =====================================================

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (!await _service.DeleteAsync(id))
                return NotFound();

            return Ok();
        }
    }
}

