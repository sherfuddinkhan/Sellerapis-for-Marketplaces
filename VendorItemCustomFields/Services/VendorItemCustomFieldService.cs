using Marketplacesellerportal.Interfaces;
using Marketplacesellerportal.Models;
using Marketplacesellerportal.VendorItemCustomFields.Interfaces;

namespace Marketplacesellerportal.VendorItemCustomFields.Services
{
    public class VendorItemCustomFieldService : IVendorItemCustomFieldService
    {
        private readonly IVendorItemCustomFieldRepository _repo;

        public VendorItemCustomFieldService(IVendorItemCustomFieldRepository repo)
        {
            _repo = repo;
        }

        public Task<List<VendorItemCustomField>> GetAllAsync()
            => _repo.GetAllAsync();

        public Task<VendorItemCustomField?> GetByIdAsync(int id)
            => _repo.GetByIdAsync(id);

        public Task<VendorItemCustomField> CreateAsync(VendorItemCustomField entity)
            => _repo.CreateAsync(entity);

        public Task<bool> UpdateAsync(int id, VendorItemCustomField entity)
            => _repo.UpdateAsync(id, entity);

        public Task<bool> DeleteAsync(int id)
            => _repo.DeleteAsync(id);
    }
}