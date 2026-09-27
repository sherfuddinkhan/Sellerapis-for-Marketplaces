using Marketplacesellerportal.CustomerAddresses.Interface;
using Marketplacesellerportal.Models;

namespace Marketplacesellerportal.CustomerAddresses.Services
{
    public class CustomerAddressService : ICustomerAddressService
    {
        private readonly ICustomerAddressRepository _repository;

        public CustomerAddressService(
            ICustomerAddressRepository repository)
        {
            _repository = repository;
        }

        // ============================================================
        // GET ALL
        // ============================================================

        public async Task<List<CustomerAddress>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        // ============================================================
        // GET BY CUSTOMER
        // ============================================================

        public async Task<List<CustomerAddress>> GetByCustomerIdAsync(
            int customerId)
        {
            return await _repository.GetByCustomerIdAsync(customerId);
        }

        // ============================================================
        // GET BY ID
        // ============================================================

        public async Task<CustomerAddress?> GetByIdAsync(
            int customerAddressId)
        {
            return await _repository.GetByIdAsync(customerAddressId);
        }

        // ============================================================
        // CREATE
        // ============================================================

        public async Task<CustomerAddress> CreateAsync(
            CustomerAddress address)
        {
            return await _repository.CreateAsync(address);
        }

        // ============================================================
        // UPDATE
        // ============================================================

        public async Task<bool> UpdateAsync(
            CustomerAddress address)
        {
            return await _repository.UpdateAsync(address);
        }

        // NEW METHOD
        public async Task<CustomerAddress?>
            GetBySellerAndCustomerAsync(
                int sellerId,
                int customerId)
        {
            return await _repository
                .GetBySellerAndCustomerAsync(
                    sellerId,
                    customerId);
        }

        // ============================================================
        // DELETE
        // ============================================================

        public async Task<bool> DeleteAsync(
            int customerAddressId)
        {
            return await _repository.DeleteAsync(customerAddressId);
        }
    }
}