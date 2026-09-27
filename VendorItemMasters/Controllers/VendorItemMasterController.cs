using Marketplacesellerportal.DTOs;
using Marketplacesellerportal.VendorItemMasters.DTOs;
using Marketplacesellerportal.VendorItemMasters.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Marketplacesellerportal.VendorItemMasters.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VendorItemMasterController : ControllerBase
    {
        private readonly IVendorItemMasterService _svc;
        public VendorItemMasterController(IVendorItemMasterService svc) => _svc = svc;

        [HttpGet("seller/{sellerId}/customer/{customerId}")]
        public async Task<IActionResult> GetList(int sellerId, int customerId, [FromQuery] int page = 1, [FromQuery] int size = 20)
        {
            var req = new VendorItemMasterListRequest { SellerId = sellerId, CustomerId = customerId, PageNumber = page, PageSize = size };
            req.Normalize();
            return Ok(await _svc.GetListAsync(req));
        }

        [HttpPost("list")]
        public async Task<IActionResult> GetListPost([FromBody] VendorItemMasterListRequest req)
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
        public async Task<IActionResult> Create(int sellerId, int customerId, [FromBody] VendorItemMasterModel m)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            m.SellerId = sellerId;
            m.CustomerId = customerId;
            var r = await _svc.CreateAsync(m);
            if (!r.Success) return BadRequest(r);
            return CreatedAtAction(nameof(GetById), new { id = r.Data!.VendorItemMasterId, sellerId, customerId }, r);
        }

        [HttpPut("{id}/seller/{sellerId}/customer/{customerId}")]
        public async Task<IActionResult> Update(int id, int sellerId, int customerId, [FromBody] VendorItemMasterModel m)
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