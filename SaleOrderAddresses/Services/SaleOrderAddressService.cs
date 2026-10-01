using Marketplacesellerportal.Interfaces;
using Marketplacesellerportal.Models;
using Marketplacesellerportal.SaleOrderAddresses.Interfaces;

namespace Marketplacesellerportal.SaleOrderAddresses.Services
{
    public class SaleOrderAddressService
        : ISaleOrderAddressService
    {
        private readonly ISaleOrderAddressRepository _repo;

        public SaleOrderAddressService(
            ISaleOrderAddressRepository repo)
        {
            _repo = repo;
        }

        public Task<List<SaleOrderAddress>> GetAllAsync()
            => _repo.GetAllAsync();

        public Task<SaleOrderAddress?> GetByIdAsync(int id)
            => _repo.GetByIdAsync(id);

        public Task<SaleOrderAddress> CreateAsync(
            SaleOrderAddress entity)
            => _repo.CreateAsync(entity);

        public async Task<bool> UpdateAsync(
            int id,
            SaleOrderAddress entity)
        {
            entity.SalesOrderId= id;

            return await _repo.UpdateAsync(entity);
        }

        public Task<bool> DeleteAsync(int id)
            => _repo.DeleteAsync(id);
    }
}
