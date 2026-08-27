using Microsoft.AspNetCore.Mvc;
using Marketplacesellerportal.Models;
using Marketplacesellerportal.DeliveryChallans.Interfaces;

namespace Marketplacesellerportal.DeliveryChallans.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DeliveryChallanController : ControllerBase
    {
        private readonly IDeliveryChallanService _service;

        public DeliveryChallanController(
            IDeliveryChallanService service)
        {
            _service = service;
        }

        // =====================================================
        // GET ALL / SEARCH / SORT / PAGINATION
        // =====================================================

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
            // GET:
            // /api/DeliveryChallan?search=DC-001
            // =====================================================

            if (!string.IsNullOrWhiteSpace(search))
            {
                var result =
                    await _service.SearchAsync(search);

                return Ok(result);
            }

            // =====================================================
            // STATUS FILTER
            // GET:
            // /api/DeliveryChallan?status=Delivered
            // =====================================================

            if (!string.IsNullOrWhiteSpace(status))
            {
                var result =
                    await _service.GetByStatusAsync(status);

                return Ok(result);
            }

            // =====================================================
            // SORT
            // GET:
            // /api/DeliveryChallan?sort=challan_number
            // =====================================================

            if (!string.IsNullOrWhiteSpace(sort))
            {
                var result =
                    await _service.GetSortedAsync(sort);

                return Ok(result);
            }

            // =====================================================
            // PAGINATION
            // GET:
            // /api/DeliveryChallan?page=1&limit=15
            // =====================================================

            if (page.HasValue || limit.HasValue)
            {
                int currentPage = page ?? 1;
                int currentLimit = limit ?? 15;

                var result =
                    await _service.GetPagedAsync(
                        currentPage,
                        currentLimit);

                return Ok(result);
            }

            // =====================================================
            // GET ALL
            // =====================================================

            return Ok(
                await _service.GetAllAsync());
        }

        // =====================================================
        // GET BY ID
        // GET:
        // /api/DeliveryChallan/1
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
        // /api/DeliveryChallan/salesorder/1
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
        // GET BY STATUS
        // GET:
        // /api/DeliveryChallan/status/Delivered
        // =====================================================

        [HttpGet("status/{status}")]
        public async Task<IActionResult> GetByStatus(
            string status)
        {
            return Ok(
                await _service.GetByStatusAsync(status));
        }

        // =====================================================
        // GET BY CHALLAN NUMBER
        // GET:
        // /api/DeliveryChallan/number/DC-001
        // =====================================================

        [HttpGet("number/{challanNumber}")]
        public async Task<IActionResult> GetByChallanNumber(
            string challanNumber)
        {
            var result =
                await _service.GetByChallanNumberAsync(
                    challanNumber);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        // =====================================================
        // STATISTICS
        // GET:
        // /api/DeliveryChallan/stats
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
        // /api/DeliveryChallan
        // =====================================================

        [HttpPost]
        public async Task<IActionResult> Create(
            DeliveryChallan deliveryChallan)
        {
            return Ok(
                await _service.CreateAsync(
                    deliveryChallan));
        }

        // =====================================================
        // UPDATE
        // PUT:
        // /api/DeliveryChallan/1
        // =====================================================

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(
            int id,
            DeliveryChallan deliveryChallan)
        {
            if (!await _service.UpdateAsync(
                    id,
                    deliveryChallan))
            {
                return NotFound();
            }

            return Ok();
        }

        // =====================================================
        // DELETE
        // DELETE:
        // /api/DeliveryChallan/1
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