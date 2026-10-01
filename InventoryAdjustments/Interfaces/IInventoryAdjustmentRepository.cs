using Marketplacesellerportal.Models;

namespace Marketplacesellerportal.Interfaces
{
    public interface IInventoryAdjustmentRepository
    {
        Task<List<InventoryAdjustment>> GetAllAsync();
        Task<InventoryAdjustment?> GetByIdAsync(int id);
        Task<InventoryAdjustment> CreateAsync(
            InventoryAdjustment entity);
        Task<bool> UpdateAsync(
            InventoryAdjustment entity);
        Task<bool> DeleteAsync(int id);
    }
}