using Microsoft.AspNetCore.Mvc;
using Marketplacesellerportal.Models;
using Marketplacesellerportal.PurchaseReturns.Interfaces;

namespace Marketplacesellerportal.PurchaseReturns.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PurchaseReturnController : ControllerBase
    {
        private readonly IPurchaseReturnService _service;

        public PurchaseReturnController(IPurchaseReturnService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpGet("{purchaseReturnId}")]
        public async Task<IActionResult> GetById(int purchaseReturnId)
        {
            var result = await _service.GetByIdAsync(purchaseReturnId);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpGet("purchaseorder/{purchaseOrderId}")]
        public async Task<IActionResult> GetByPurchaseOrder(int purchaseOrderId)
        {
            return Ok(await _service.GetByPurchaseOrderIdAsync(purchaseOrderId));
        }

        [HttpGet("supplier/{supplierId}")]
        public async Task<IActionResult> GetBySupplier(int supplierId)
        {
            return Ok(await _service.GetBySupplierIdAsync(supplierId));
        }

        [HttpGet("grn/{goodsReceiptNoteId}")]
        public async Task<IActionResult> GetByGRN(int goodsReceiptNoteId)
        {
            return Ok(await _service.GetByGoodsReceiptNoteIdAsync(goodsReceiptNoteId));
        }

        [HttpGet("status/{status}")]
        public async Task<IActionResult> GetByStatus(string status)
        {
            return Ok(await _service.GetByStatusAsync(status));
        }

        [HttpPost]
        public async Task<IActionResult> Create(PurchaseReturn purchaseReturn)
        {
            return Ok(await _service.CreateAsync(purchaseReturn));
        }

        [HttpPut("{purchaseReturnId}")]
        public async Task<IActionResult> Update(int purchaseReturnId, PurchaseReturn purchaseReturn)
        {
            if (!await _service.UpdateAsync(purchaseReturnId, purchaseReturn))
                return NotFound();

            return Ok();
        }

        [HttpDelete("{purchaseReturnId}")]
        public async Task<IActionResult> Delete(int purchaseReturnId)
        {
            if (!await _service.DeleteAsync(purchaseReturnId))
                return NotFound();

            return Ok();
        }
    }
}
