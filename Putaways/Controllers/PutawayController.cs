using Marketplacesellerportal.DTOs;
using Marketplacesellerportal.Putaways.DTOs;
using Marketplacesellerportal.Putaways.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Marketplacesellerportal.Putaways.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PutawayController : ControllerBase
    {
        private readonly IPutawayService _putawayService;

        public PutawayController(IPutawayService putawayService)
        {
            _putawayService = putawayService;
        }

        // GET: api/Putaway/seller/{sellerId}/customer/{customerId}
        [HttpGet("seller/{sellerId}/customer/{customerId}")]
        public async Task<IActionResult> GetList([FromRoute] int sellerId, [FromRoute] int customerId, [FromQuery] PutawayListRequest request)
        {
            if (request == null) request = new PutawayListRequest();
            request.SellerId = sellerId;
            request.CustomerId = customerId;
            request.Normalize();

            var result = await _putawayService.GetListAsync(request);
            if (!result.Success) return BadRequest(result);
            return Ok(result);
        }

        // GET: api/Putaway/{id}/seller/{sellerId}/customer/{customerId}
        [HttpGet("{id}/seller/{sellerId}/customer/{customerId}")]
        public async Task<IActionResult> GetById([FromRoute] int id, [FromRoute] int sellerId, [FromRoute] int customerId)
        {
            var result = await _putawayService.GetByIdAsync(id, sellerId, customerId);
            if (!result.Success) return NotFound(result);
            return Ok(result);
        }

        // POST: api/Putaway/seller/{sellerId}/customer/{customerId}
        [HttpPost("seller/{sellerId}/customer/{customerId}")]
        public async Task<IActionResult> Create([FromRoute] int sellerId, [FromRoute] int customerId, [FromBody] PutawayModel model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            model.SellerId = sellerId;
            model.CustomerId = customerId;

            var result = await _putawayService.CreateAsync(model);
            if (!result.Success) return BadRequest(result);

            return CreatedAtAction(
                nameof(GetById),
                new { id = result.Data!.PutawayId, sellerId = sellerId, customerId = customerId },
                result
            );
        }

        // PUT: api/Putaway/{id}/seller/{sellerId}/customer/{customerId}
        [HttpPut("{id}/seller/{sellerId}/customer/{customerId}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromRoute] int sellerId, [FromRoute] int customerId, [FromBody] PutawayModel model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            model.SellerId = sellerId;
            model.CustomerId = customerId;

            var result = await _putawayService.UpdateAsync(id, model);
            if (!result.Success) return NotFound(result);
            return Ok(result);
        }

        // DELETE: api/Putaway/{id}/seller/{sellerId}/customer/{customerId}
        [HttpDelete("{id}/seller/{sellerId}/customer/{customerId}")]
        public async Task<IActionResult> Delete([FromRoute] int id, [FromRoute] int sellerId, [FromRoute] int customerId)
        {
            var result = await _putawayService.DeleteAsync(id, sellerId, customerId);
            if (!result.Success) return NotFound(result);
            return Ok(result);
        }

        // GET: api/Putaway/statistics/seller/{sellerId}/customer/{customerId}
        [HttpGet("statistics/seller/{sellerId}/customer/{customerId}")]
        public async Task<IActionResult> GetStatistics([FromRoute] int sellerId, [FromRoute] int customerId)
        {
            var result = await _putawayService.GetStatisticsAsync(sellerId, customerId);
            return Ok(result);
        }

        // Alternative route without customerId for backward compat
        [HttpGet("seller/{sellerId}")]
        public async Task<IActionResult> GetBySeller([FromRoute] int sellerId, [FromQuery] PutawayListRequest request)
        {
            if (request == null) request = new PutawayListRequest();
            request.SellerId = sellerId;
            request.Normalize();

            var result = await _putawayService.GetListAsync(request);
            return Ok(result);
        }
    }
}