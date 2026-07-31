using Microsoft.AspNetCore.Mvc;
using Marketplacesellerportal.Models;
using Marketplacesellerportal.StockAdjustments.Interfaces;

namespace Marketplacesellerportal.StockAdjustments.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StockAdjustmentController : ControllerBase
    {
        private readonly IStockAdjustmentService _service;

        public StockAdjustmentController(IStockAdjustmentService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpGet("{stockAdjustmentId}")]
        public async Task<IActionResult> GetById(int stockAdjustmentId)
        {
            var adjustment = await _service.GetByIdAsync(stockAdjustmentId);

            if (adjustment == null)
                return NotFound();

            return Ok(adjustment);
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

        [HttpGet("warehouse/{warehouseId}")]
        public async Task<IActionResult> GetByWarehouse(int warehouseId)
        {
            return Ok(await _service.GetByWarehouseIdAsync(warehouseId));
        }

        [HttpGet("type/{adjustmentType}")]
        public async Task<IActionResult> GetByAdjustmentType(string adjustmentType)
        {
            return Ok(await _service.GetByAdjustmentTypeAsync(adjustmentType));
        }

        [HttpGet("{sellerId}/{productId}/{warehouseId}/{stockAdjustmentId}")]
        public async Task<IActionResult> GetStockAdjustment(
            int sellerId,
            int productId,
            int warehouseId,
            int stockAdjustmentId)
        {
            var adjustment = await _service.GetStockAdjustmentAsync(
                sellerId,
                productId,
                warehouseId,
                stockAdjustmentId);

            if (adjustment == null)
                return NotFound();

            return Ok(adjustment);
        }

        [HttpPost]
        public async Task<IActionResult> Create(StockAdjustment stockAdjustment)
        {
            return Ok(await _service.CreateAsync(stockAdjustment));
        }

        [HttpPut("{stockAdjustmentId}")]
        public async Task<IActionResult> Update(
            int stockAdjustmentId,
            StockAdjustment stockAdjustment)
        {
            if (!await _service.UpdateAsync(stockAdjustmentId, stockAdjustment))
                return NotFound();

            return Ok();
        }

        [HttpDelete("{stockAdjustmentId}")]
        public async Task<IActionResult> Delete(int stockAdjustmentId)
        {
            if (!await _service.DeleteAsync(stockAdjustmentId))
                return NotFound();

            return Ok();
        }
    }
}
