using Microsoft.AspNetCore.Mvc;
using Marketplacesellerportal.Models;
using Marketplacesellerportal.Wishlists.Interfaces;

namespace Marketplacesellerportal.Wishlists.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WishlistController : ControllerBase
    {
        private readonly IWishlistService _service;

        public WishlistController(IWishlistService service)
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

        [HttpGet("customer/{customerId}")]
        public async Task<IActionResult> GetByCustomer(int customerId)
        {
            return Ok(await _service.GetByCustomerAsync(customerId));
        }

        [HttpPost]
        public async Task<IActionResult> Create(Wishlist wishlist)
        {
            return Ok(await _service.CreateAsync(wishlist));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Wishlist wishlist)
        {
            if (!await _service.UpdateAsync(id, wishlist))
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
