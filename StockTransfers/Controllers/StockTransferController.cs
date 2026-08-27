using Microsoft.AspNetCore.Mvc;
using Marketplacesellerportal.Models;
using Marketplacesellerportal.StockTransfers.Interfaces;

namespace Marketplacesellerportal.StockTransfers.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StockTransferController : ControllerBase
    {
        private readonly IStockTransferService _service;

        public StockTransferController(IStockTransferService service)
        {
            _service = service;
        }

        // =====================================================
        // GET ALL
        // GET: /api/StockTransfer
        // =====================================================

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAllAsync());
        }


        // =====================================================
        // GET BY ID
        // GET: /api/StockTransfer/{stockTransferId}
        // =====================================================

        [HttpGet("{stockTransferId}")]
        public async Task<IActionResult> GetById(int stockTransferId)
        {
            var result =
                await _service.GetByIdAsync(stockTransferId);

            if (result == null)
                return NotFound();

            return Ok(result);
        }


        // =====================================================
        // GET BY SELLER
        // GET: /api/StockTransfer/seller/{sellerId}
        // =====================================================

        [HttpGet("seller/{sellerId}")]
        public async Task<IActionResult> GetBySeller(int sellerId)
        {
            return Ok(
                await _service.GetBySellerIdAsync(sellerId));
        }


        // =====================================================
        // GET BY PRODUCT
        // GET: /api/StockTransfer/product/{productId}
        // =====================================================

        [HttpGet("product/{productId}")]
        public async Task<IActionResult> GetByProduct(int productId)
        {
            return Ok(
                await _service.GetByProductIdAsync(productId));
        }


        // =====================================================
        // GET BY FROM WAREHOUSE
        // GET: /api/StockTransfer/fromwarehouse/{fromWarehouseId}
        // =====================================================

        [HttpGet("fromwarehouse/{fromWarehouseId}")]
        public async Task<IActionResult> GetByFromWarehouse(
            int fromWarehouseId)
        {
            return Ok(
                await _service.GetByFromWarehouseIdAsync(
                    fromWarehouseId));
        }


        // =====================================================
        // GET BY TO WAREHOUSE
        // GET: /api/StockTransfer/towarehouse/{toWarehouseId}
        // =====================================================

        [HttpGet("towarehouse/{toWarehouseId}")]
        public async Task<IActionResult> GetByToWarehouse(
            int toWarehouseId)
        {
            return Ok(
                await _service.GetByToWarehouseIdAsync(
                    toWarehouseId));
        }


        // =====================================================
        // GET BY STATUS
        // GET: /api/StockTransfer/status/{status}
        // =====================================================

        [HttpGet("status/{status}")]
        public async Task<IActionResult> GetByStatus(
            string status)
        {
            return Ok(
                await _service.GetByStatusAsync(status));
        }


        // =====================================================
        // SEARCH
        // GET: /api/StockTransfer/search?search=ST-001
        // =====================================================

        [HttpGet("search")]
        public async Task<IActionResult> Search(
            [FromQuery] string search)
        {
            if (string.IsNullOrWhiteSpace(search))
            {
                return BadRequest(new
                {
                    message = "Search value is required"
                });
            }

            var result =
                await _service.SearchAsync(search);

            return Ok(result);
        }


        // =====================================================
        // SORT
        // GET: /api/StockTransfer/sort?sort=date_desc
        // =====================================================

        [HttpGet("sort")]
        public async Task<IActionResult> Sort(
            [FromQuery] string? sort)
        {
            var result =
                await _service.GetSortedAsync(sort);

            return Ok(result);
        }


        // =====================================================
        // PAGINATION
        // GET: /api/StockTransfer/page?page=1&limit=15
        // =====================================================

        [HttpGet("page")]
        public async Task<IActionResult> Page(
            [FromQuery] int page = 1,
            [FromQuery] int limit = 15)
        {
            if (page < 1)
                page = 1;

            if (limit < 1)
                limit = 15;

            var result =
                await _service.GetPagedAsync(
                    page,
                    limit);

            return Ok(result);
        }


        // =====================================================
        // STATISTICS
        // GET: /api/StockTransfer/statistics
        // =====================================================

        [HttpGet("statistics")]
        public async Task<IActionResult> Statistics()
        {
            var result =
                await _service.GetStatisticsAsync();

            return Ok(result);
        }


        // =====================================================
        // CREATE
        // POST: /api/StockTransfer
        // =====================================================

        [HttpPost]
        public async Task<IActionResult> Create(
            StockTransfer stockTransfer)
        {
            var result =
                await _service.CreateAsync(stockTransfer);

            return Ok(result);
        }


        // =====================================================
        // UPDATE
        // PUT: /api/StockTransfer/{stockTransferId}
        // =====================================================

        [HttpPut("{stockTransferId}")]
        public async Task<IActionResult> Update(
            int stockTransferId,
            StockTransfer stockTransfer)
        {
            if (!await _service.UpdateAsync(
                    stockTransferId,
                    stockTransfer))
            {
                return NotFound();
            }

            return Ok();
        }


        // =====================================================
        // DELETE
        // DELETE: /api/StockTransfer/{stockTransferId}
        // =====================================================

        [HttpDelete("{stockTransferId}")]
        public async Task<IActionResult> Delete(
            int stockTransferId)
        {
            if (!await _service.DeleteAsync(stockTransferId))
                return NotFound();

            return Ok();
        }
    }
}