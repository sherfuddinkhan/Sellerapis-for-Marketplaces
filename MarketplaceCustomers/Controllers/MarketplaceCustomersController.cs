using Marketplacesellerportal.Database;
using Marketplacesellerportal.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Marketplacesellerportal.Controllers
{
    [ApiController]
    [Route("api/marketplace/customers")]
    public class MarketplaceCustomersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public MarketplaceCustomersController(ApplicationDbContext context) => _context = context;

        [HttpGet("all")]
        public async Task<IActionResult> GetAll() => Ok(await _context.MarketplaceCustomers.ToListAsync());

        [HttpGet("{sellerId:int}/{customerId:int}")]
        public async Task<IActionResult> Get(int sellerId, int customerId)
        {
            var item = await _context.MarketplaceCustomers
              .AsNoTracking()
              .FirstOrDefaultAsync(x => x.SellerId == sellerId && x.CustomerId == customerId);

            if (item == null) return NotFound($"Customer {customerId} not found for seller {sellerId}");
            return Ok(item);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] MarketplaceCustomer model)
        {
            model.Id = 0;
            model.MarketplaceCustomerId = model.MarketplaceCustomerId ?? "";
            _context.MarketplaceCustomers.Add(model);
            await _context.SaveChangesAsync();
            return Ok(model);
        }
    }
}