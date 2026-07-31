using Microsoft.AspNetCore.Mvc;
using Marketplacesellerportal.Models;
using Marketplacesellerportal.DeliveryChallans.Interfaces;

namespace Marketplacesellerportal.DeliveryChallans.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DeliveryChallanController : ControllerBase
    {
        private readonly IDeliveryChallanService _service;

        public DeliveryChallanController(IDeliveryChallanService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _service.GetByIdAsync(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpGet("salesorder/{salesOrderId}")]
        public async Task<IActionResult> GetBySalesOrder(int salesOrderId)
        {
            return Ok(await _service.GetBySalesOrderAsync(salesOrderId));
        }

        [HttpGet("status/{status}")]
        public async Task<IActionResult> GetByStatus(string status)
        {
            return Ok(await _service.GetByStatusAsync(status));
        }

        [HttpGet("number/{challanNumber}")]
        public async Task<IActionResult> GetByChallanNumber(string challanNumber)
        {
            var result = await _service.GetByChallanNumberAsync(challanNumber);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(DeliveryChallan deliveryChallan)
        {
            return Ok(await _service.CreateAsync(deliveryChallan));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, DeliveryChallan deliveryChallan)
        {
            if (!await _service.UpdateAsync(id, deliveryChallan))
                return NotFound();

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (!await _service.DeleteAsync(id))
                return NotFound();

            return Ok();
        }
    }
}
