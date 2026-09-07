using Microsoft.AspNetCore.Mvc;
using Marketplacesellerportal.Models;
using Marketplacesellerportal.WishlistItems.DTOs;
using Marketplacesellerportal.WishlistItems.Interfaces;


namespace Marketplacesellerportal.WishlistItems.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WishlistItemController : ControllerBase
    {
        private readonly IWishlistItemService _service;

        public WishlistItemController(IWishlistItemService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAllAsync());
        }
        [HttpPost]
        public async Task<IActionResult> Create(
    [FromBody] WishlistItemCreateDto dto)
        {
            if (dto == null)
                return BadRequest("Request body is required.");

            if (dto.WishlistId <= 0)
                return BadRequest("WishlistId must be greater than 0.");

            if (dto.SellerId <= 0)
                return BadRequest("SellerId must be greater than 0.");

            if (dto.CustomerId <= 0)
                return BadRequest("CustomerId must be greater than 0.");

            if (dto.ProductId <= 0)
                return BadRequest("ProductId must be greater than 0.");

            var wishlistItem = new WishlistItem
            {
                WishlistId = dto.WishlistId,
                SellerId = dto.SellerId,
                CustomerId = dto.CustomerId,
                ProductId = dto.ProductId,
                CreatedDate = DateTime.UtcNow
            };

            var result = await _service.CreateAsync(wishlistItem);

            return CreatedAtAction(
                nameof(GetById),
                new { id = result.WishlistItemId },
                result
            );
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _service.GetByIdAsync(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpGet("wishlist/{wishlistId}")]
        public async Task<IActionResult> GetByWishlist(int wishlistId)
        {
            return Ok(await _service.GetByWishlistAsync(wishlistId));
        }

        [HttpGet("product/{productId}")]
        public async Task<IActionResult> GetByProduct(int productId)
        {
            return Ok(await _service.GetByProductAsync(productId));
        }

            
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, WishlistItem wishlistItem)
        {
            if (!await _service.UpdateAsync(id, wishlistItem))
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
