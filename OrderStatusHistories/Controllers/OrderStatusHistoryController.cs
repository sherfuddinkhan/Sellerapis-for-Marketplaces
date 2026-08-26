using Microsoft.AspNetCore.Mvc;
using Marketplacesellerportal.Models;
using Marketplacesellerportal.OrderStatusHistories.Interfaces;

namespace Marketplacesellerportal.OrderStatusHistories.Controllers
{
    [ApiController]
    [Route("api/order-status-histories")]
    public class OrderStatusHistoryController : ControllerBase
    {
        private readonly IOrderStatusHistoryService _service;

        public OrderStatusHistoryController(
            IOrderStatusHistoryService service)
        {
            _service = service;
        }

        // =========================================================
        // GET ALL
        // GET /api/order-status-histories
        // =========================================================

        [HttpGet]
        public async Task<IActionResult> GetAll(
            [FromQuery] string? search,
            [FromQuery] string? sort)
        {
            // Search
            if (!string.IsNullOrWhiteSpace(search))
            {
                var searchResult =
                    await _service.SearchAsync(search);

                return Ok(searchResult);
            }

            // Sorting
            if (!string.IsNullOrWhiteSpace(sort))
            {
                var sortedResult =
                    await _service.GetSortedAsync(sort);

                return Ok(sortedResult);
            }

            // Normal GET ALL
            var result =
                await _service.GetAllAsync();

            return Ok(result);
        }

        // =========================================================
        // GET BY ID
        // GET /api/order-status-histories/5
        // =========================================================

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result =
                await _service.GetByIdAsync(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        // =========================================================
        // GET BY ORDER
        // GET /api/order-status-histories/order/10
        // =========================================================

        [HttpGet("order/{orderId:int}")]
        public async Task<IActionResult> GetByOrder(
            int orderId)
        {
            var result =
                await _service.GetByOrderIdAsync(orderId);

            return Ok(result);
        }

        // =========================================================
        // GET BY STATUS
        // GET /api/order-status-histories/status/Shipped
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
        // SEARCH
        // GET /api/order-status-histories/search?search=Shipped
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
        // GET /api/order-status-histories/stats
        // =========================================================

        [HttpGet("stats")]
        public async Task<IActionResult> GetStatistics()
        {
            var result =
                await _service.GetStatisticsAsync();

            return Ok(result);
        }

        // =========================================================
        // PAGINATION BY ORDER
        // GET /api/orders/10/status-history?page=1&limit=10
        // =========================================================

        [HttpGet("/api/orders/{orderId:int}/status-history")]
        public async Task<IActionResult> GetPagedByOrderId(
            int orderId,
            [FromQuery] int page = 1,
            [FromQuery] int limit = 10)
        {
            if (page < 1)
                page = 1;

            if (limit < 1)
                limit = 10;

            if (limit > 100)
                limit = 100;

            var result =
                await _service.GetPagedByOrderIdAsync(
                    orderId,
                    page,
                    limit);

            return Ok(new
            {
                page,
                limit,
                totalCount = result.TotalCount,
                items = result.Items
            });
        }

        // =========================================================
        // CREATE
        // POST /api/order-status-histories
        // =========================================================

        [HttpPost]
        public async Task<IActionResult> Create(
            [FromBody] OrderStatusHistory history)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result =
                await _service.CreateAsync(history);

            return CreatedAtAction(
                nameof(GetById),
                new
                {
                    id = result.OrderStatusHistoryId
                },
                result);
        }

        // =========================================================
        // UPDATE
        // PUT /api/order-status-histories/5
        // =========================================================

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(
            int id,
            [FromBody] OrderStatusHistory history)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var updated =
                await _service.UpdateAsync(
                    id,
                    history);

            if (!updated)
                return NotFound();

            return Ok(new
            {
                message =
                    "Order status history updated successfully."
            });
        }

        // =========================================================
        // DELETE
        // DELETE /api/order-status-histories/5
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
                    "Order status history deleted successfully."
            });
        }
    }
}