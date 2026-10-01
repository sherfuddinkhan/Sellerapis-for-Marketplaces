using Marketplacesellerportal.Interfaces;
using Marketplacesellerportal.Models;
using Marketplacesellerportal.Picklists.Interfaces;

namespace Marketplacesellerportal.Picklists.Services
{
    public class PicklistService : IPicklistService
    {
        private readonly IPicklistRepository _repo;

        public PicklistService(IPicklistRepository repo)
        {
            _repo = repo;
        }

        public Task<List<Picklist>> GetAllAsync()
            => _repo.GetAllAsync();

        public Task<Picklist?> GetByCodeAsync(string picklistCode)
            => _repo.GetByCodeAsync(picklistCode);

        public Task<Picklist> CreateAsync(Picklist entity)
            => _repo.CreateAsync(entity);

        public async Task<bool> UpdateAsync(
            string picklistCode,
            Picklist entity)
        {
            entity.PicklistCode = picklistCode;

            return await _repo.UpdateAsync(entity);
        }

        public Task<bool> DeleteAsync(string picklistCode)
            => _repo.DeleteAsync(picklistCode);
    }
}