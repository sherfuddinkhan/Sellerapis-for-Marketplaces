using Microsoft.AspNetCore.Mvc;
using Marketplacesellerportal.Models;
using Marketplacesellerportal.OrderStatusHistories.Interfaces;


namespace Marketplacesellerportal.OrderStatusHistories.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderStatusHistoryController : ControllerBase
    {
        private readonly IOrderStatusHistoryService _service;

        public OrderStatusHistoryController(IOrderStatusHistoryService service)
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

        [HttpGet("order/{orderId}")]
        public async Task<IActionResult> GetByOrder(int orderId)
        {
            return Ok(await _service.GetByOrderIdAsync(orderId));
        }

        [HttpGet("status/{status}")]
        public async Task<IActionResult> GetByStatus(string status)
        {
            return Ok(await _service.GetByStatusAsync(status));
        }

        [HttpPost]
        public async Task<IActionResult> Create(OrderStatusHistory history)
        {
            return Ok(await _service.CreateAsync(history));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, OrderStatusHistory history)
        {
            if (!await _service.UpdateAsync(id, history))
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