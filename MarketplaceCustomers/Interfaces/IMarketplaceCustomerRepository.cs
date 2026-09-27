using Marketplacesellerportal.Models;

namespace Marketplacesellerportal.MarketplaceCustomers.Interfaces
{
    public interface IMarketplaceCustomerRepository
    {
        Task<IEnumerable<MarketplaceCustomer>> GetAllAsync();
        Task<MarketplaceCustomer?> GetByIdAsync(int id);
        Task<MarketplaceCustomer?> GetBySellerAndCustomerAsync(int sellerId, string customerId);
        Task<IEnumerable<MarketplaceCustomer>> GetBySellerIdAsync(int sellerId);
        Task AddAsync(MarketplaceCustomer marketplaceCustomer);
        Task UpdateAsync(MarketplaceCustomer marketplaceCustomer);
        Task DeleteAsync(int id);
        Task SaveChangesAsync();
        Task<MarketplaceCustomer?> GetBySellerAndCustomerAsync(int sellerId, int customerId);
    }
}
