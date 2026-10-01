using SellerCustomerEntity = Marketplacesellerportal.Models.SellerCustomer;
using Marketplacesellerportal.SellerCustomers.DTOs;

namespace Marketplacesellerportal.SellerCustomers.Interfaces
{
    public interface ISellerCustomerService
    {
        Task<IEnumerable<SellerCustomerEntity>> GetAllAsync();
        Task<IEnumerable<SellerCustomerEntity>> GetBySellerIdAsync(int sellerId);
        Task<SellerCustomerEntity?> GetCustomerAsync(int sellerId, int customerId);
        Task<SellerCustomerEntity?> GetByCustomerCodeAsync(int sellerId, string customerCode);
        Task<IEnumerable<SellerCustomerEntity>> FilterAsync(int sellerId, string? search, bool? isActive);
        Task<SellerCustomerWithProductsResponse?> GetCustomerWithProductsAsync(int sellerId, int customerId);
        Task<SellerCustomerEntity> CreateAsync(CreateSellerCustomerRequest request);
        Task<bool> UpdateAsync(int sellerId, int customerId, UpdateSellerCustomerRequest request);
        Task<bool> DeleteAsync(int sellerId, int customerId);
    }
}