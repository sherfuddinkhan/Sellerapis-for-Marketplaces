using Microsoft.AspNetCore.Mvc;
using Marketplacesellerportal.Models;
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

        [HttpPost]
        public async Task<IActionResult> Create(WishlistItem wishlistItem)
        {
            return Ok(await _service.CreateAsync(wishlistItem));
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
