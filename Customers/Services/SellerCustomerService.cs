using Marketplacesellerportal.Models;
using Marketplacesellerportal.Customers.Interfaces;

namespace Marketplacesellerportal.Customers.Services
{
    public class SellerCustomerService : ISellerCustomerService
    {
        private readonly ISellerCustomerRepository _repository;

        public SellerCustomerService(ISellerCustomerRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<SellerCustomer>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<SellerCustomer?> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<SellerCustomer>> GetBySellerIdAsync(int sellerId)
        {
            return await _repository.GetBySellerIdAsync(sellerId);
        }

        public async Task<SellerCustomer?> GetByCustomerCodeAsync(string customerCode)
        {
            return await _repository.GetByCustomerCodeAsync(customerCode);
        }

        public async Task AddAsync(SellerCustomer customer)
        {
            await _repository.AddAsync(customer);
            await _repository.SaveChangesAsync();
        }
        public async Task<SellerCustomer?> GetCustomerAsync(int sellerId, int customerId)
        {
            return await _repository.GetCustomerAsync(sellerId, customerId);
        }
        public async Task UpdateAsync(SellerCustomer customer)
        {
            await _repository.UpdateAsync(customer);
            await _repository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var customer = await _repository.GetByIdAsync(id);

            if (customer != null)
            {
                await _repository.DeleteAsync(customer);
                await _repository.SaveChangesAsync();
            }
        }
    }
}
