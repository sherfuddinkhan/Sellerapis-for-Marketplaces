using Marketplacesellerportal.Models;

namespace Marketplacesellerportal.Customers.Interfaces
{
    public interface ISellerCustomerService
    {
        Task<IEnumerable<SellerCustomer>> GetAllAsync();

        Task<SellerCustomer?> GetByIdAsync(int id);

        Task<IEnumerable<SellerCustomer>> GetBySellerIdAsync(int sellerId);

        Task<SellerCustomer?> GetByCustomerCodeAsync(string customerCode);
        Task<SellerCustomer?> GetCustomerAsync(int sellerId, int customerId);

        Task AddAsync(SellerCustomer customer);

        Task UpdateAsync(SellerCustomer customer);

        Task DeleteAsync(int id);
    }
}
