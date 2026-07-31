using Microsoft.AspNetCore.Mvc;
using Marketplacesellerportal.Models;
using Marketplacesellerportal.Sellers.Interfaces;

namespace Marketplacesellerportal.Sellers.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SellerController : ControllerBase
    {
        private readonly ISellerService _service;

        public SellerController(ISellerService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var seller = await _service.GetByIdAsync(id);

            if (seller == null)
                return NotFound();

            return Ok(seller);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Seller seller)
        {
            var result = await _service.CreateAsync(seller);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(Seller seller)
        {
            await _service.UpdateAsync(seller);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}
