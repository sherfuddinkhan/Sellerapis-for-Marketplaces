using Microsoft.AspNetCore.Mvc;
using Marketplacesellerportal.Models;
using Marketplacesellerportal.GoodsReceiptItems.Interfaces;

namespace Marketplacesellerportal.GoodsReceiptItems.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GoodsReceiptItemController : ControllerBase
    {
        private readonly IGoodsReceiptItemService _service;

        public GoodsReceiptItemController(IGoodsReceiptItemService service)
        {
            _service = service;
        }

        // GET: api/GoodsReceiptItem
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.GetAllAsync();
            return Ok(result);
        }

        // GET: api/GoodsReceiptItem/5
        [HttpGet("{goodsReceiptItemId}")]
        public async Task<IActionResult> GetById(int goodsReceiptItemId)
        {
            var result = await _service.GetByIdAsync(goodsReceiptItemId);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        // GET: api/GoodsReceiptItem/grn/10
        [HttpGet("grn/{goodsReceiptNoteId}")]
        public async Task<IActionResult> GetByGoodsReceiptNote(int goodsReceiptNoteId)
        {
            var result = await _service.GetByGoodsReceiptNoteIdAsync(goodsReceiptNoteId);

            return Ok(result);
        }

        // GET: api/GoodsReceiptItem/grn/10/item/5
        [HttpGet("grn/{goodsReceiptNoteId}/item/{goodsReceiptItemId}")]
        public async Task<IActionResult> GetByGoodsReceiptNoteAndItem(
            int goodsReceiptNoteId,
            int goodsReceiptItemId)
        {
            var result = await _service.GetByGoodsReceiptNoteAndItemAsync(
                goodsReceiptNoteId,
                goodsReceiptItemId);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        // POST: api/GoodsReceiptItem
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] GoodsReceiptItem goodsReceiptItem)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _service.CreateAsync(goodsReceiptItem);

            return CreatedAtAction(
                nameof(GetById),
                new { goodsReceiptItemId = result.GoodsReceiptItemId },
                result);
        }

        // PUT: api/GoodsReceiptItem/5
        [HttpPut("{goodsReceiptItemId}")]
        public async Task<IActionResult> Update(
            int goodsReceiptItemId,
            [FromBody] GoodsReceiptItem goodsReceiptItem)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var updated = await _service.UpdateAsync(
                goodsReceiptItemId,
                goodsReceiptItem);

            if (!updated)
                return NotFound();

            return Ok("Goods Receipt Item updated successfully.");
        }

        // DELETE: api/GoodsReceiptItem/5
        [HttpDelete("{goodsReceiptItemId}")]
        public async Task<IActionResult> Delete(int goodsReceiptItemId)
        {
            var deleted = await _service.DeleteAsync(goodsReceiptItemId);

            if (!deleted)
                return NotFound();

            return Ok("Goods Receipt Item deleted successfully.");
        }
    }
}
