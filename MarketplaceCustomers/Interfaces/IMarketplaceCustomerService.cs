using Marketplacesellerportal.Models;

namespace Marketplacesellerportal.MarketplaceCustomers.Interfaces
{
    public interface IMarketplaceCustomerService
    {
        Task<List<MarketplaceCustomer>> GetAllAsync();
        Task<MarketplaceCustomer?> GetBySellerCustomerAsync(int sellerId, int customerId);
        Task<MarketplaceCustomer> CreateAsync(MarketplaceCustomer model);
    }
}
