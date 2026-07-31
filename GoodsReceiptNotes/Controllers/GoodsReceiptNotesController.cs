using Microsoft.AspNetCore.Mvc;
using Marketplacesellerportal.Models;
using Marketplacesellerportal.GoodsReceiptNotes.Interfaces;

namespace Marketplacesellerportal.GoodsReceiptNotes.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GoodsReceiptNotesController : ControllerBase
    {
        private readonly IGoodsReceiptNoteService _service;

        public GoodsReceiptNotesController(IGoodsReceiptNoteService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpGet("{goodsReceiptNoteId}")]
        public async Task<IActionResult> Get(int goodsReceiptNoteId)
        {
            var data = await _service.GetByIdAsync(goodsReceiptNoteId);

            if (data == null)
                return NotFound();

            return Ok(data);
        }

        [HttpGet("purchaseorder/{purchaseOrderId}")]
        public async Task<IActionResult> GetByPurchaseOrder(int purchaseOrderId)
        {
            return Ok(await _service.GetByPurchaseOrderIdAsync(purchaseOrderId));
        }

        [HttpPost]
        public async Task<IActionResult> Create(GoodsReceiptNote goodsReceiptNote)
        {
            var result = await _service.CreateAsync(goodsReceiptNote);

            return Ok(result);
        }

        [HttpPut("{goodsReceiptNoteId}")]
        public async Task<IActionResult> Update(int goodsReceiptNoteId, GoodsReceiptNote goodsReceiptNote)
        {
            if (!await _service.UpdateAsync(goodsReceiptNoteId, goodsReceiptNote))
                return NotFound();

            return Ok();
        }

        [HttpDelete("{goodsReceiptNoteId}")]
        public async Task<IActionResult> Delete(int goodsReceiptNoteId)
        {
            if (!await _service.DeleteAsync(goodsReceiptNoteId))
                return NotFound();

            return Ok();
        }
    }
}
