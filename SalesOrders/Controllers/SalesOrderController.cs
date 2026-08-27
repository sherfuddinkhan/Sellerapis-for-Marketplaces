using Microsoft.AspNetCore.Mvc;
using Marketplacesellerportal.Models;
using Marketplacesellerportal.SalesOrders.Interfaces;

namespace Marketplacesellerportal.SalesOrders.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SalesOrderController : ControllerBase
    {
        private readonly ISalesOrderService _service;

        public SalesOrderController(ISalesOrderService service)
        {
            _service = service;
        }

        // =====================================================
        // GET ALL / SEARCH / STATUS / SORT / PAGINATION
        // =====================================================

        // GET:
        // /api/SalesOrder
        //
        // SEARCH:
        // /api/SalesOrder?search=SO-5520
        //
        // STATUS:
        // /api/SalesOrder?status=pending
        //
        // SORT:
        // /api/SalesOrder?sort=order_date
        //
        // PAGINATION:
        // /api/SalesOrder?page=1&limit=15
        //
        // COMBINED:
        // /api/SalesOrder?search=SO-5520&page=1&limit=15

        [HttpGet]
        public async Task<IActionResult> GetAll(
            [FromQuery] string? search,
            [FromQuery] string? sort,
            [FromQuery] string? status,
            [FromQuery] int? page,
            [FromQuery] int? limit)
        {
            // =====================================================
            // SEARCH
            // =====================================================

            if (!string.IsNullOrWhiteSpace(search))
            {
                var result =
                    await _service.SearchAsync(search);

                return Ok(result);
            }

            // =====================================================
            // STATUS FILTER
            // =====================================================

            if (!string.IsNullOrWhiteSpace(status))
            {
                var result =
                    await _service.GetByStatusAsync(status);

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
            // PAGINATION
            // =====================================================

            if (page.HasValue || limit.HasValue)
            {
                int currentPage = page ?? 1;
                int currentLimit = limit ?? 15;

                // Prevent invalid pagination values
                if (currentPage < 1)
                    currentPage = 1;

                if (currentLimit < 1)
                    currentLimit = 15;

                var result =
                    await _service.GetPagedAsync(
                        currentPage,
                        currentLimit);

                return Ok(new
                {
                    page = currentPage,
                    limit = currentLimit,
                    totalCount = result.TotalCount,
                    totalPages = (int)Math.Ceiling(
                        (double)result.TotalCount / currentLimit),
                    items = result.Items
                });
            }

            // =====================================================
            // GET ALL
            // =====================================================

            return Ok(
                await _service.GetAllAsync());
        }

        // =====================================================
        // GET BY ID
        // =====================================================

        // GET:
        // /api/SalesOrder/1

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result =
                await _service.GetByIdAsync(id);

            if (result == null)
                return NotFound(new
                {
                    message = "Sales order not found"
                });

            return Ok(result);
        }

        // =====================================================
        // GET BY SELLER
        // =====================================================

        // GET:
        // /api/SalesOrder/seller/6

        [HttpGet("seller/{sellerId}")]
        public async Task<IActionResult> GetBySeller(
            int sellerId)
        {
            return Ok(
                await _service.GetBySellerAsync(
                    sellerId));
        }

        // =====================================================
        // GET BY CUSTOMER
        // =====================================================

        // GET:
        // /api/SalesOrder/customer/3

        [HttpGet("customer/{customerId}")]
        public async Task<IActionResult> GetByCustomer(
            int customerId)
        {
            return Ok(
                await _service.GetByCustomerAsync(
                    customerId));
        }

        // =====================================================
        // GET BY STATUS
        // =====================================================

        // GET:
        // /api/SalesOrder/status/pending

        [HttpGet("status/{status}")]
        public async Task<IActionResult> GetByStatus(
            string status)
        {
            return Ok(
                await _service.GetByStatusAsync(
                    status));
        }

        // =====================================================
        // GET BY SALES ORDER NUMBER
        // =====================================================

        // GET:
        // /api/SalesOrder/number/SO-5520

        [HttpGet("number/{salesOrderNumber}")]
        public async Task<IActionResult> GetBySalesOrderNumber(
            string salesOrderNumber)
        {
            var result =
                await _service.GetBySalesOrderNumberAsync(
                    salesOrderNumber);

            if (result == null)
                return NotFound(new
                {
                    message = "Sales order not found"
                });

            return Ok(result);
        }

        // =====================================================
        // STATISTICS
        // =====================================================

        // GET:
        // /api/SalesOrder/stats

        [HttpGet("stats")]
        public async Task<IActionResult> GetStatistics()
        {
            var result =
                await _service.GetStatisticsAsync();

            return Ok(result);
        }

        // =====================================================
        // CREATE
        // =====================================================

        // POST:
        // /api/SalesOrder

        [HttpPost]
        public async Task<IActionResult> Create(
            SalesOrder salesOrder)
        {
            var result =
                await _service.CreateAsync(
                    salesOrder);

            return Ok(result);
        }

        // =====================================================
        // UPDATE
        // =====================================================

        // PUT:
        // /api/SalesOrder/1

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(
            int id,
            SalesOrder salesOrder)
        {
            if (!await _service.UpdateAsync(
                    id,
                    salesOrder))
            {
                return NotFound(new
                {
                    message = "Sales order not found"
                });
            }

            return Ok(new
            {
                message = "Sales order updated successfully"
            });
        }

        // =====================================================
        // DELETE
        // =====================================================

        // DELETE:
        // /api/SalesOrder/1

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (!await _service.DeleteAsync(id))
            {
                return NotFound(new
                {
                    message = "Sales order not found"
                });
            }

            return Ok(new
            {
                message = "Sales order deleted successfully"
            });
        }
    }
}