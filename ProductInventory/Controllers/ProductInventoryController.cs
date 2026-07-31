using Microsoft.AspNetCore.Mvc;
using Marketplacesellerportal.Models;
using Marketplacesellerportal.ProductInventories.Interfaces;

namespace Marketplacesellerportal.ProductInventories.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductInventoryController : ControllerBase
    {
        private readonly IProductInventoryService _service;

        public ProductInventoryController(IProductInventoryService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpGet("{productInventoryId}")]
        public async Task<IActionResult> GetById(int productInventoryId)
        {
            var inventory = await _service.GetByIdAsync(productInventoryId);

            if (inventory == null)
                return NotFound();

            return Ok(inventory);
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

        [HttpGet("{sellerId}/{productId}/{warehouseId}/{locationId}")]
        public async Task<IActionResult> GetInventory(
            int sellerId,
            int productId,
            int warehouseId,
            int locationId)
        {
            var inventory = await _service.GetInventoryAsync(
                sellerId,
                productId,
                warehouseId,
                locationId);

            if (inventory == null)
                return NotFound();

            return Ok(inventory);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductInventory productInventory)
        {
            return Ok(await _service.CreateAsync(productInventory));
        }

        [HttpPut("{productInventoryId}")]
        public async Task<IActionResult> Update(
            int productInventoryId,
            ProductInventory productInventory)
        {
            if (!await _service.UpdateAsync(productInventoryId, productInventory))
                return NotFound();

            return Ok();
        }

        [HttpDelete("{productInventoryId}")]
        public async Task<IActionResult> Delete(int productInventoryId)
        {
            if (!await _service.DeleteAsync(productInventoryId))
                return NotFound();

            return Ok();
        }
    }
}
