using Microsoft.AspNetCore.Mvc;
using Marketplacesellerportal.Models;
using Marketplacesellerportal.PurchaseOrderItems.Interfaces;

namespace Marketplacesellerportal.PurchaseOrderItems.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PurchaseOrderItemController : ControllerBase
    {
        private readonly IPurchaseOrderItemService _service;

        public PurchaseOrderItemController(IPurchaseOrderItemService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpGet("{purchaseOrderItemId}")]
        public async Task<IActionResult> GetById(int purchaseOrderItemId)
        {
            var item = await _service.GetByIdAsync(purchaseOrderItemId);

            if (item == null)
                return NotFound();

            return Ok(item);
        }

        [HttpGet("purchaseorder/{purchaseOrderId}")]
        public async Task<IActionResult> GetByPurchaseOrder(int purchaseOrderId)
        {
            return Ok(await _service.GetByPurchaseOrderIdAsync(purchaseOrderId));
        }

        [HttpGet("purchaseorder/{purchaseOrderId}/item/{purchaseOrderItemId}")]
        public async Task<IActionResult> GetPurchaseOrderItem(
            int purchaseOrderId,
            int purchaseOrderItemId)
        {
            var item = await _service.GetByPurchaseOrderAndItemIdAsync(
                purchaseOrderId,
                purchaseOrderItemId);

            if (item == null)
                return NotFound();

            return Ok(item);
        }

        [HttpPost]
        public async Task<IActionResult> Create(PurchaseOrderItem item)
        {
            var result = await _service.CreateAsync(item);

            return Ok(result);
        }

        [HttpPut("{purchaseOrderItemId}")]
        public async Task<IActionResult> Update(
            int purchaseOrderItemId,
            PurchaseOrderItem item)
        {
            var updated = await _service.UpdateAsync(
                purchaseOrderItemId,
                item);

            if (!updated)
                return NotFound();

            return Ok();
        }

        [HttpDelete("{purchaseOrderItemId}")]
        public async Task<IActionResult> Delete(int purchaseOrderItemId)
        {
            var deleted = await _service.DeleteAsync(purchaseOrderItemId);

            if (!deleted)
                return NotFound();

            return Ok();
        }
    }
}
