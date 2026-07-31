using Microsoft.AspNetCore.Mvc;
using Marketplacesellerportal.Models;
using Marketplacesellerportal.ProductPrices.Interfaces;

namespace Marketplacesellerportal.ProductPrices.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductPriceController : ControllerBase
    {
        private readonly IProductPriceService _service;

        public ProductPriceController(IProductPriceService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpGet("{productPriceId}")]
        public async Task<IActionResult> GetById(int productPriceId)
        {
            var result = await _service.GetByIdAsync(productPriceId);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpGet("product/{productId}")]
        public async Task<IActionResult> GetByProduct(int productId)
        {
            return Ok(await _service.GetByProductIdAsync(productId));
        }

        [HttpGet("seller/{sellerId}")]
        public async Task<IActionResult> GetBySeller(int sellerId)
        {
            return Ok(await _service.GetBySellerIdAsync(sellerId));
        }

        [HttpGet("type/{priceType}")]
        public async Task<IActionResult> GetByPriceType(string priceType)
        {
            return Ok(await _service.GetByPriceTypeAsync(priceType));
        }

        [HttpGet("active")]
        public async Task<IActionResult> GetActive()
        {
            return Ok(await _service.GetActivePricesAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductPrice productPrice)
        {
            return Ok(await _service.CreateAsync(productPrice));
        }

        [HttpPut("{productPriceId}")]
        public async Task<IActionResult> Update(int productPriceId, ProductPrice productPrice)
        {
            if (!await _service.UpdateAsync(productPriceId, productPrice))
                return NotFound();

            return Ok();
        }

        [HttpDelete("{productPriceId}")]
        public async Task<IActionResult> Delete(int productPriceId)
        {
            if (!await _service.DeleteAsync(productPriceId))
                return NotFound();

            return Ok();
        }
    }
}
