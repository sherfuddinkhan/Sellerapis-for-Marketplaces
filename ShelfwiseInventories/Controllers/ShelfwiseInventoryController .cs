using Marketplacesellerportal.DTOs;
using Marketplacesellerportal.Interfaces;
using Marketplacesellerportal.ShelfwiseInventory.DTOs;
using Marketplacesellerportal.ShelfwiseInventory.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Marketplacesellerportal.ShelfwiseInventory.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShelfwiseInventoryController : ControllerBase
    {
        private readonly IShelfwiseInventoryService _svc;
        public ShelfwiseInventoryController(IShelfwiseInventoryService svc) => _svc = svc;

        [HttpGet("seller/{sellerId}/customer/{customerId}")]
        public async Task<IActionResult> GetList(int sellerId, int customerId, [FromQuery] int page = 1, [FromQuery] int size = 20)
        {
            var req = new ShelfwiseInventoryListRequest { SellerId = sellerId, CustomerId = customerId, PageNumber = page, PageSize = size };
            req.Normalize();
            return Ok(await _svc.GetListAsync(req));
        }

        [HttpPost("list")]
        public async Task<IActionResult> GetListPost([FromBody] ShelfwiseInventoryListRequest req)
        {
            req.Normalize();
            return Ok(await _svc.GetListAsync(req));
        }

        [HttpGet("{id}/seller/{sellerId}/customer/{customerId}")]
        public async Task<IActionResult> GetById(int id, int sellerId, int customerId)
        {
            var r = await _svc.GetByIdAsync(id, sellerId, customerId);
            if (!r.Success) return NotFound(r);
            return Ok(r);
        }

        [HttpPost("seller/{sellerId}/customer/{customerId}")]
        public async Task<IActionResult> Create(int sellerId, int customerId, [FromBody] ShelfwiseInventoryModel m)
        {
            m.SellerId = sellerId;
            m.CustomerId = customerId;
            var r = await _svc.CreateAsync(m);
            return r.Success ? CreatedAtAction(nameof(GetById), new { id = r.Data!.ShelfwiseInventoryId, sellerId, customerId }, r) : BadRequest(r);
        }

        [HttpPut("{id}/seller/{sellerId}/customer/{customerId}")]
        public async Task<IActionResult> Update(int id, int sellerId, int customerId, [FromBody] ShelfwiseInventoryModel m)
        {
            m.SellerId = sellerId;
            m.CustomerId = customerId;
            var r = await _svc.UpdateAsync(id, m);
            if (!r.Success) return NotFound(r);
            return Ok(r);
        }

        [HttpDelete("{id}/seller/{sellerId}/customer/{customerId}")]
        public async Task<IActionResult> Delete(int id, int sellerId, int customerId)
        {
            var r = await _svc.DeleteAsync(id, sellerId, customerId);
            if (!r.Success) return NotFound(r);
            return Ok(r);
        }
    }
}