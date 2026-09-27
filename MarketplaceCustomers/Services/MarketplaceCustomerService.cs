using Marketplacesellerportal.Database;
using Marketplacesellerportal.Models;
using Marketplacesellerportal.MarketplaceCustomers.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Marketplacesellerportal.MarketplaceCustomers.Services
{
    public class MarketplaceCustomerService : IMarketplaceCustomerService
    {
        private readonly ApplicationDbContext _context;
        public MarketplaceCustomerService(ApplicationDbContext context) => _context = context;

        public async Task<List<MarketplaceCustomer>> GetAllAsync()
            => await _context.MarketplaceCustomers.ToListAsync();

        public async Task<MarketplaceCustomer?> GetBySellerCustomerAsync(int sellerId, int customerId)
            => await _context.MarketplaceCustomers.FirstOrDefaultAsync(x => x.SellerId == sellerId && x.CustomerId == customerId);

        public async Task<MarketplaceCustomer> CreateAsync(MarketplaceCustomer model)
        {
            model.Id = 0;
            model.MarketplaceCustomerId = model.MarketplaceCustomerId ?? "";
            model.CreatedAt = DateTime.Now;
            _context.MarketplaceCustomers.Add(model);
            await _context.SaveChangesAsync();
            return model;
        }
    }
}