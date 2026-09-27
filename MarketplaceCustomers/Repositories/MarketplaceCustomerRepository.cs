using Marketplacesellerportal.Database;
using Marketplacesellerportal.Models;
using Microsoft.EntityFrameworkCore;

namespace Marketplacesellerportal.MarketplaceCustomers.Repositories
{
    public class MarketplaceCustomerRepository
    {
        private readonly ApplicationDbContext _context;
        public MarketplaceCustomerRepository(ApplicationDbContext context) => _context = context;

        public async Task<MarketplaceCustomer?> GetByIdAsync(int id)
            => await _context.MarketplaceCustomers.FirstOrDefaultAsync(x => x.Id == id);

        public async Task<MarketplaceCustomer?> GetBySellerCustomerAsync(int sellerId, int customerId)
            => await _context.MarketplaceCustomers.FirstOrDefaultAsync(x => x.SellerId == sellerId && x.CustomerId == customerId);

        public async Task<List<MarketplaceCustomer>> GetAllAsync()
            => await _context.MarketplaceCustomers.ToListAsync();
    }
}