using Marketplacesellerportal.Models;
using Marketplacesellerportal.SupplierAddresses.Interfaces;

namespace Marketplacesellerportal.SupplierAddresses.Services
{
    public class SupplierAddressService : ISupplierAddressService
    {
        private readonly ISupplierAddressRepository _repo;

        public SupplierAddressService(
            ISupplierAddressRepository repo)
            => _repo = repo;

        public Task<List<SupplierAddress>> GetAllAsync()
            => _repo.GetAllAsync();

        public Task<SupplierAddress?> GetByIdAsync(int id)
            => _repo.GetByIdAsync(id);

        public Task<SupplierAddress> CreateAsync(
            SupplierAddress entity)
            => _repo.CreateAsync(entity);

        public async Task<bool> UpdateAsync(
            int id,
            SupplierAddress entity)
        {
            entity.SupplierAddressId = id;

            return await _repo.UpdateAsync(entity);
        }

        public Task<bool> DeleteAsync(int id)
            => _repo.DeleteAsync(id);
    }
}
