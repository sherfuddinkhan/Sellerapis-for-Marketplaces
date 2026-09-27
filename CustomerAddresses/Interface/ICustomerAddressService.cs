using Marketplacesellerportal.Models;

namespace Marketplacesellerportal.CustomerAddresses.Interface
{
    public interface ICustomerAddressService
    {
        Task<List<CustomerAddress>> GetAllAsync();

        Task<List<CustomerAddress>> GetByCustomerIdAsync(
            int customerId);

        Task<CustomerAddress?> GetByIdAsync(
            int customerAddressId);

        Task<CustomerAddress> CreateAsync(
            CustomerAddress address);

        Task<CustomerAddress?> GetBySellerAndCustomerAsync(
    int sellerId,
    int customerId);
        Task<bool> UpdateAsync(
            CustomerAddress address);

        Task<bool> DeleteAsync(
            int customerAddressId);
    }
}