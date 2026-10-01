using Marketplacesellerportal.Models;
using Marketplacesellerportal.ReversePickupItems.Interfaces;

namespace Marketplacesellerportal.ReversePickupItems.Services
{
    public class ReversePickupItemService : IReversePickupItemService
    {
        private readonly IReversePickupItemRepository _repo;

        public ReversePickupItemService(IReversePickupItemRepository repo)
        {
            _repo = repo;
        }

        public Task<List<ReversePickupItem>> GetAllAsync()
            => _repo.GetAllAsync();

        public Task<ReversePickupItem?> GetByIdAsync(int id)
            => _repo.GetByIdAsync(id);

        public Task<ReversePickupItem> CreateAsync(ReversePickupItem entity)
            => _repo.CreateAsync(entity);

        public Task<bool> UpdateAsync(int id, ReversePickupItem entity)
            => _repo.UpdateAsync(id, entity); // FIXED: 2 params, no entity.ReversePickupItemId = id

        public Task<bool> DeleteAsync(int id)
            => _repo.DeleteAsync(id);
    }
}