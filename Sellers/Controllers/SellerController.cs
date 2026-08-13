using Marketplacesellerportal.Models;
using Marketplacesellerportal.Sellers.DTOs;
using Marketplacesellerportal.Sellers.Interfaces;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<IActionResult> Create(RegisterSellerRequest request)
        {
            var seller = new Seller
            {
                SellerName = request.SellerName,
                ContactPerson = request.ContactPerson,
                Email = request.Email,
                Phone = request.Phone,
                GSTIN = request.GSTIN,
                Address = request.Address,
                City = request.City,
                State = request.State,
                PostalCode = request.PostalCode,
                Country = request.Country
            };

            var result = await _service.CreateAsync(seller);

            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, RegisterSellerRequest request)
        {
            var seller = await _service.GetByIdAsync(id);

            if (seller == null)
                return NotFound(new { message = "Seller not found" });

            seller.SellerName = request.SellerName;
            seller.ContactPerson = request.ContactPerson;
            seller.Email = request.Email;
            seller.Phone = request.Phone;
            seller.GSTIN = request.GSTIN;
            seller.Address = request.Address;
            seller.City = request.City;
            seller.State = request.State;
            seller.PostalCode = request.PostalCode;
            seller.Country = request.Country;

            seller.UpdatedAt = DateTime.UtcNow;

            await _service.UpdateAsync(seller);

            return Ok(seller);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var seller = await _service.GetByIdAsync(id);

            if (seller == null)
                return NotFound(new { message = "Seller not found" });

            await _service.DeleteAsync(id);

            return NoContent();
        }
    }
}