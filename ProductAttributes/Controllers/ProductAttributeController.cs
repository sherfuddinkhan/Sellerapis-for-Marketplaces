using Microsoft.AspNetCore.Mvc;
using Marketplacesellerportal.Models;
using Marketplacesellerportal.ProductAttributes.Interfaces;

namespace Marketplacesellerportal.ProductAttributes.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductAttributeController : ControllerBase
    {
        private readonly IProductAttributeService _service;

        public ProductAttributeController(IProductAttributeService service)
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

        [HttpGet("product/{productId}")]
        public async Task<IActionResult> GetByProduct(int productId)
        {
            return Ok(await _service.GetByProductIdAsync(productId));
        }

        [HttpGet("attribute/{attributeName}")]
        public async Task<IActionResult> GetByAttribute(string attributeName)
        {
            return Ok(await _service.GetByAttributeNameAsync(attributeName));
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductAttribute productAttribute)
        {
            return Ok(await _service.CreateAsync(productAttribute));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ProductAttribute productAttribute)
        {
            if (!await _service.UpdateAsync(id, productAttribute))
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
