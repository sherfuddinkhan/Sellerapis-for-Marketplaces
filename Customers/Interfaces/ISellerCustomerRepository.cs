using Marketplacesellerportal.Models;
using Marketplacesellerportal.SharedKernel.Interfaces;

namespace Marketplacesellerportal.Customers.Interfaces
{
    public interface ISellerCustomerRepository : IGenericRepository<SellerCustomer>
    {
        Task<IEnumerable<SellerCustomer>> GetBySellerIdAsync(int sellerId);

        Task<SellerCustomer?> GetByCustomerCodeAsync(string customerCode);
        Task<SellerCustomer?> GetCustomerAsync(int sellerId, int customerId);
    }
}
