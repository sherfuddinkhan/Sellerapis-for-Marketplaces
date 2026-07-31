using Microsoft.AspNetCore.Mvc;
using Marketplacesellerportal.Models;
using Marketplacesellerportal.PurchaseOrders.Interfaces;

namespace Marketplacesellerportal.PurchaseOrders.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PurchaseOrderController : ControllerBase
    {
        private readonly IPurchaseOrderService _service;

        public PurchaseOrderController(IPurchaseOrderService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpGet("{purchaseOrderId}")]
        public async Task<IActionResult> Get(int purchaseOrderId)
        {
            var po = await _service.GetByIdAsync(purchaseOrderId);

            if (po == null)
                return NotFound();

            return Ok(po);
        }

        [HttpGet("seller/{sellerId}")]
        public async Task<IActionResult> GetBySeller(int sellerId)
        {
            return Ok(await _service.GetBySellerIdAsync(sellerId));
        }

        [HttpGet("supplier/{supplierId}")]
        public async Task<IActionResult> GetBySupplier(int supplierId)
        {
            return Ok(await _service.GetBySupplierIdAsync(supplierId));
        }

        [HttpGet("{sellerId}/{customerid}/{purchaseOrderId}")]
        public async Task<IActionResult> GetBySellerSupplierAndPurchaseOrder(int sellerId,int customerid, int purchaseOrderId)
        {
            var po = await _service.GetBySellerSupplierAndPurchaseOrderIdAsync(sellerId,customerid,purchaseOrderId);

            if (po == null)
                return NotFound();

            return Ok(po);
        }

        [HttpPost]
        public async Task<IActionResult> Create(PurchaseOrder purchaseOrder)
        {
            return Ok(await _service.CreateAsync(purchaseOrder));
        }

        [HttpPut("{purchaseOrderId}")]
        public async Task<IActionResult> Update(int purchaseOrderId, PurchaseOrder purchaseOrder)
        {
            if (!await _service.UpdateAsync(purchaseOrderId, purchaseOrder))
                return NotFound();

            return Ok();
        }

        [HttpDelete("{purchaseOrderId}")]
        public async Task<IActionResult> Delete(int purchaseOrderId)
        {
            if (!await _service.DeleteAsync(purchaseOrderId))
                return NotFound();

            return Ok();
        }   
    }
}
