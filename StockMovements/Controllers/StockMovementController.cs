using Microsoft.AspNetCore.Mvc;
using Marketplacesellerportal.Models;
using Marketplacesellerportal.StockMovements.Interfaces;

namespace Marketplacesellerportal.StockMovements.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StockMovementController : ControllerBase
    {
        private readonly IStockMovementService _service;

        public StockMovementController(IStockMovementService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpGet("{stockMovementId}")]
        public async Task<IActionResult> GetById(int stockMovementId)
        {
            var result = await _service.GetByIdAsync(stockMovementId);

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

        [HttpGet("warehouse/{warehouseId}")]
        public async Task<IActionResult> GetByWarehouse(int warehouseId)
        {
            return Ok(await _service.GetByWarehouseIdAsync(warehouseId));
        }

        [HttpGet("movement/{movementType}")]
        public async Task<IActionResult> GetByMovementType(string movementType)
        {
            return Ok(await _service.GetByMovementTypeAsync(movementType));
        }

        [HttpGet("{sellerId}/{productId}/{warehouseId}/{stockMovementId}")]
        public async Task<IActionResult> GetStockMovement(
            int sellerId,
            int productId,
            int warehouseId,
            int stockMovementId)
        {
            var result = await _service.GetStockMovementAsync(
                sellerId,
                productId,
                warehouseId,
                stockMovementId);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(StockMovement stockMovement)
        {
            return Ok(await _service.CreateAsync(stockMovement));
        }

        [HttpPut("{stockMovementId}")]
        public async Task<IActionResult> Update(
            int stockMovementId,
            StockMovement stockMovement)
        {
            if (!await _service.UpdateAsync(stockMovementId, stockMovement))
                return NotFound();

            return Ok();
        }

        [HttpDelete("{stockMovementId}")]
        public async Task<IActionResult> Delete(int stockMovementId)
        {
            if (!await _service.DeleteAsync(stockMovementId))
                return NotFound();

            return Ok();
        }
    }
}
