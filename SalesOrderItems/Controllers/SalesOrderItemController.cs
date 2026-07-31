using Microsoft.AspNetCore.Mvc;
using Marketplacesellerportal.Models;
using Marketplacesellerportal.SalesOrderItems.Interfaces;

namespace Marketplacesellerportal.SalesOrderItems.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SalesOrderItemController : ControllerBase
    {
        private readonly ISalesOrderItemService _service;

        public SalesOrderItemController(ISalesOrderItemService service)
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

        [HttpGet("product/{productId}")]
        public async Task<IActionResult> GetByProduct(int productId)
        {
            return Ok(await _service.GetByProductAsync(productId));
        }

        [HttpPost]
        public async Task<IActionResult> Create(SalesOrderItem salesOrderItem)
        {
            return Ok(await _service.CreateAsync(salesOrderItem));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, SalesOrderItem salesOrderItem)
        {
            if (!await _service.UpdateAsync(id, salesOrderItem))
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
