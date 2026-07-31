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

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpGet("{stockTransferId}")]
        public async Task<IActionResult> GetById(int stockTransferId)
        {
            var result = await _service.GetByIdAsync(stockTransferId);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpGet("seller/{sellerId}")]
        public async Task<IActionResult> GetBySeller(int sellerId)
        {
            return Ok(await _service.GetBySellerIdAsync(sellerId));
        }

        [HttpGet("product/{productId}")]
        public async Task<IActionResult> GetByProduct(int productId)
        {
            return Ok(await _service.GetByProductIdAsync(productId));
        }

        [HttpGet("fromwarehouse/{fromWarehouseId}")]
        public async Task<IActionResult> GetByFromWarehouse(int fromWarehouseId)
        {
            return Ok(await _service.GetByFromWarehouseIdAsync(fromWarehouseId));
        }

        [HttpGet("towarehouse/{toWarehouseId}")]
        public async Task<IActionResult> GetByToWarehouse(int toWarehouseId)
        {
            return Ok(await _service.GetByToWarehouseIdAsync(toWarehouseId));
        }

        [HttpGet("status/{status}")]
        public async Task<IActionResult> GetByStatus(string status)
        {
            return Ok(await _service.GetByStatusAsync(status));
        }

        [HttpPost]
        public async Task<IActionResult> Create(StockTransfer stockTransfer)
        {
            return Ok(await _service.CreateAsync(stockTransfer));
        }

        [HttpPut("{stockTransferId}")]
        public async Task<IActionResult> Update(int stockTransferId, StockTransfer stockTransfer)
        {
            if (!await _service.UpdateAsync(stockTransferId, stockTransfer))
                return NotFound();

            return Ok();
        }

        [HttpDelete("{stockTransferId}")]
        public async Task<IActionResult> Delete(int stockTransferId)
        {
            if (!await _service.DeleteAsync(stockTransferId))
                return NotFound();

            return Ok();
        }
    }
}
