using Marketplacesellerportal.Models;
using Marketplacesellerportal.SharedKernel.Interfaces;

namespace Marketplacesellerportal.SellerCustomers.Interfaces
{
    public interface ISellerCustomerRepository
        : IGenericRepository<SellerCustomer>
    {
        Task<IEnumerable<SellerCustomer>>
            GetBySellerIdAsync(int sellerId);

        Task<SellerCustomer?> GetCustomerAsync(
            int sellerId,
            int customerId);

        Task<SellerCustomer?>
            GetByCustomerCodeAsync(
                int sellerId,
                string customerCode);

        Task<bool> CustomerCodeExistsAsync(
            int sellerId,
            string customerCode);

        Task<int> GetNextCustomerIdAsync(
            int sellerId);
    }
}