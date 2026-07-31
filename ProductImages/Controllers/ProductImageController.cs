using Microsoft.AspNetCore.Mvc;
using Marketplacesellerportal.Models;
using Marketplacesellerportal.ProductImages.Interfaces;

namespace Marketplacesellerportal.ProductImages.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductImageController : ControllerBase
    {
        private readonly IProductImageService _service;

        public ProductImageController(IProductImageService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpGet("{productImageId}")]
        public async Task<IActionResult> GetById(int productImageId)
        {
            var result = await _service.GetByIdAsync(productImageId);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpGet("product/{productId}")]
        public async Task<IActionResult> GetByProduct(int productId)
        {
            return Ok(await _service.GetByProductIdAsync(productId));
        }

        [HttpGet("primary")]
        public async Task<IActionResult> GetPrimaryImages()
        {
            return Ok(await _service.GetPrimaryImagesAsync());
        }

        [HttpGet("primary/{productId}")]
        public async Task<IActionResult> GetPrimaryImage(int productId)
        {
            var result = await _service.GetPrimaryImageAsync(productId);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductImage productImage)
        {
            return Ok(await _service.CreateAsync(productImage));
        }

        [HttpPut("{productImageId}")]
        public async Task<IActionResult> Update(int productImageId, ProductImage productImage)
        {
            if (!await _service.UpdateAsync(productImageId, productImage))
                return NotFound();

            return Ok();
        }

        [HttpDelete("{productImageId}")]
        public async Task<IActionResult> Delete(int productImageId)
        {
            if (!await _service.DeleteAsync(productImageId))
                return NotFound();

            return Ok();
        }
    }
}
