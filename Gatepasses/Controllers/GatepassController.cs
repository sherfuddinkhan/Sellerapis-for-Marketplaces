
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

        public GatepassController(IGatepassService svc)
        {
            _svc = svc;
        }

        // =====================================================
        // GET ALL GATEPASSES
        // GET: api/Gatepass/all
        // =====================================================
        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _svc.GetAllAsync());
        }

        // =====================================================
        // GET ALL BY SELLER AND CUSTOMER
        // GET: api/Gatepass/seller/6/customer/3
        // =====================================================
        [HttpGet("seller/{sellerId}/customer/{customerId}")]
        public async Task<IActionResult> GetAllBySellerCustomer(
            int sellerId,
            int customerId)
        {
            return Ok(
                await _svc.GetAllBySellerCustomerAsync(
                    sellerId,
                    customerId));
        }

        // =====================================================
        // GET BY ID
        // GET: api/Gatepass/1/seller/6/customer/3
        // =====================================================
        [HttpGet("{id:int}/seller/{sellerId:int}/customer/{customerId:int}")]
        public async Task<IActionResult> GetById(
            int id,
            int sellerId,
            int customerId)
        {
            var result = await _svc.GetByIdAsync(
                id,
                sellerId,
                customerId);

            if (!result.Success)
                return NotFound(result);

            return Ok(result);
        }

        // =====================================================
        // GET BY CODE
        // GET: api/Gatepass/code/GP001/seller/6/customer/3
        // =====================================================
        [HttpGet("code/{code}/seller/{sellerId:int}/customer/{customerId:int}")]
        public async Task<IActionResult> GetByCode(
            string code,
            int sellerId,
            int customerId)
        {
            var result = await _svc.GetByCodeAsync(
                code,
                sellerId,
                customerId);

            if (!result.Success)
                return NotFound(result);

            return Ok(result);
        }

        // =====================================================
        // GET PAGINATED / FILTERED LIST
        // POST: api/Gatepass/list
        // =====================================================
        [HttpPost("list")]
        public async Task<IActionResult> GetList(
            [FromBody] GatepassListRequest req)
        {
            if (req == null)
                return BadRequest("Request body is required.");

            return Ok(await _svc.GetListAsync(req));
        }

        // =====================================================
        // CREATE
        // POST: api/Gatepass/seller/6/customer/3
        // =====================================================
        [HttpPost("seller/{sellerId:int}/customer/{customerId:int}")]
        public async Task<IActionResult> Create(
            int sellerId,
            int customerId,
            [FromBody] GatepassModel model)
        {
            if (model == null)
                return BadRequest("Gatepass request body is required.");

            model.SellerId = sellerId;
            model.CustomerId = customerId;

            var result = await _svc.CreateAsync(model);

            if (!result.Success)
                return BadRequest(result);

            return CreatedAtAction(
                nameof(GetById),
                new
                {
                    id = result.Data!.GatepassId,
                    sellerId,
                    customerId
                },
                result);
        }

        // =====================================================
        // UPDATE
        // PUT: api/Gatepass/1/seller/6/customer/3
        // =====================================================
        [HttpPut("{id:int}/seller/{sellerId:int}/customer/{customerId:int}")]
        public async Task<IActionResult> Update(
            int id,
            int sellerId,
            int customerId,
            [FromBody] GatepassModel model)
        {
            if (model == null)
                return BadRequest("Gatepass request body is required.");

            model.SellerId = sellerId;
            model.CustomerId = customerId;

            var result = await _svc.UpdateAsync(id, model);

            if (!result.Success)
                return NotFound(result);

            return Ok(result);
        }

        // =====================================================
        // DELETE
        // DELETE: api/Gatepass/1/seller/6/customer/3
        // =====================================================
        [HttpDelete("{id:int}/seller/{sellerId:int}/customer/{customerId:int}")]
        public async Task<IActionResult> Delete(
            int id,
            int sellerId,
            int customerId)
        {
            var result = await _svc.DeleteAsync(
                id,
                sellerId,
                customerId);

            if (!result.Success)
                return NotFound(result);

            return Ok(result);
        }
    }
}