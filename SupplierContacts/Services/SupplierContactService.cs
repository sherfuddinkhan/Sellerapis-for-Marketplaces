using Marketplacesellerportal.Models;
using Marketplacesellerportal.SupplierContact.Interfaces;

using SupplierContactModel = Marketplacesellerportal.Models.SupplierContacts;

namespace Marketplacesellerportal.SupplierContact.Services
{
    public class SupplierContactService : ISupplierContactService
    {
        private readonly ISupplierContactRepository _repo;

        public SupplierContactService(
            ISupplierContactRepository repo)
        {
            _repo = repo;
        }

        public Task<List<SupplierContactModel>> GetAllAsync()
        {
            return _repo.GetAllAsync();
        }

        public Task<SupplierContactModel?> GetByIdAsync(int id)
        {
            return _repo.GetByIdAsync(id);
        }

        public Task<SupplierContactModel> CreateAsync(
            SupplierContactModel entity)
        {
            return _repo.CreateAsync(entity);
        }

        public async Task<bool> UpdateAsync(
            int id,
            SupplierContactModel entity)
        {
            entity.SupplierContactId = id;

            return await _repo.UpdateAsync(entity);
        }

        public Task<bool> DeleteAsync(int id)
        {
            return _repo.DeleteAsync(id);
        }
    }
}