using Marketplacesellerportal.Models;
using Marketplacesellerportal.SellerCustomers.DTOs;

namespace Marketplacesellerportal.SellerCustomers.Interfaces
{
    public interface ISellerCustomerService
    {
        Task<IEnumerable<SellerCustomer>> GetAllAsync();

        Task<IEnumerable<SellerCustomer>> GetBySellerIdAsync(
            int sellerId);

        Task<SellerCustomer?> GetCustomerAsync(
            int sellerId,
            int customerId);
        Task<SellerCustomerWithProductsResponse?>
    GetCustomerWithProductsAsync(
        int sellerId,
        int customerId);
        Task<SellerCustomer?> GetByCustomerCodeAsync(
            int sellerId,
            string customerCode);

        Task<SellerCustomer> CreateAsync(
            CreateSellerCustomerRequest request);

        Task<bool> UpdateAsync(
            int sellerId,
            int customerId,
            UpdateSellerCustomerRequest request);

        Task<bool> DeleteAsync(
            int sellerId,
            int customerId);
    }
}
