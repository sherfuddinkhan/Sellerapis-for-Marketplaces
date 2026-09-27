using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Marketplacesellerportal.Gatepasses.DTOs;
using Marketplacesellerportal.Gatepasses.Interfaces;

namespace Marketplacesellerportal.Gatepasses.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GatepassController : ControllerBase
    {
        private readonly IGatepassService _svc;
        public GatepassController(IGatepassService svc) => _svc = svc;

        [HttpGet("seller/{sellerId}/customer/{customerId}")]
        public async Task<IActionResult> GetAll(int sellerId, int customerId)
            => Ok(await _svc.GetAllBySellerCustomerAsync(sellerId, customerId));

        [HttpGet("{id}/seller/{sellerId}/customer/{customerId}")]
        public async Task<IActionResult> GetById(int id, int sellerId, int customerId)
        {
            var r = await _svc.GetByIdAsync(id, sellerId, customerId);
            if (!r.Success) return NotFound(r);
            return Ok(r);
        }

        [HttpGet("code/{code}/seller/{sellerId}/customer/{customerId}")]
        public async Task<IActionResult> GetByCode(string code, int sellerId, int customerId)
        {
            var r = await _svc.GetByCodeAsync(code, sellerId, customerId);
            if (!r.Success) return NotFound(r);
            return Ok(r);
        }

        [HttpPost("list")]
        public async Task<IActionResult> GetList([FromBody] GatepassListRequest req)
        {
            return Ok(await _svc.GetListAsync(req));
        }

        [HttpPost("seller/{sellerId}/customer/{customerId}")]
        public async Task<IActionResult> Create(int sellerId, int customerId, [FromBody] GatepassModel m)
        {
            m.SellerId = sellerId;
            m.CustomerId = customerId;
            var r = await _svc.CreateAsync(m);
            if (!r.Success) return BadRequest(r);
            return CreatedAtAction(nameof(GetById), new { id = r.Data!.GatepassId, sellerId, customerId }, r);
        }

        [HttpPut("{id}/seller/{sellerId}/customer/{customerId}")]
        public async Task<IActionResult> Update(int id, int sellerId, int customerId, [FromBody] GatepassModel m)
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