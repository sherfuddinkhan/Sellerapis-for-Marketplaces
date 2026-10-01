using Marketplacesellerportal.Interfaces;
using Marketplacesellerportal.InventoryAdjustments.Interfaces;
using Marketplacesellerportal.Models;

namespace Marketplacesellerportal.InventoryAdjustments.Services
{
    public class InventoryAdjustmentService
        : IInventoryAdjustmentService
    {
        private readonly IInventoryAdjustmentRepository _repo;

        public InventoryAdjustmentService(
            IInventoryAdjustmentRepository repo)
        {
            _repo = repo;
        }

        public Task<List<InventoryAdjustment>>
            GetAllAsync()
            => _repo.GetAllAsync();

        public Task<InventoryAdjustment?>
            GetByIdAsync(int id)
            => _repo.GetByIdAsync(id);

        public Task<InventoryAdjustment>
            CreateAsync(InventoryAdjustment entity)
            => _repo.CreateAsync(entity);

        public async Task<bool>
            UpdateAsync(
                int id,
                InventoryAdjustment entity)
        {
            entity.InventoryAdjustmentId = id;

            return await _repo.UpdateAsync(entity);
        }

        public Task<bool>
            DeleteAsync(int id)
            => _repo.DeleteAsync(id);
    }
}
