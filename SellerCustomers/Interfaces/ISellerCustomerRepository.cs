using Marketplacesellerportal.SharedKernel.Interfaces;
using SellerCustomerEntity = Marketplacesellerportal.Models.SellerCustomer;

namespace Marketplacesellerportal.SellerCustomers.Interfaces
{
    public interface ISellerCustomerRepository : IGenericRepository<SellerCustomerEntity>
    {
        Task<IEnumerable<SellerCustomerEntity>> GetBySellerIdAsync(int sellerId);
        Task<SellerCustomerEntity?> GetCustomerAsync(int sellerId, int customerId);
        Task<SellerCustomerEntity?> GetByCustomerCodeAsync(int sellerId, string customerCode);
        Task<bool> CustomerCodeExistsAsync(int sellerId, string customerCode);
        Task<int> GetNextCustomerIdAsync(int sellerId);
    }
}