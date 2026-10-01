using InventoryAdjustmentEntity =
    Marketplacesellerportal.Models.InventoryAdjustment;

namespace Marketplacesellerportal.InventoryAdjustments.Interfaces
{
    public interface IInventoryAdjustmentService
    {
        Task<List<InventoryAdjustmentEntity>> GetAllAsync();

        Task<InventoryAdjustmentEntity?> GetByIdAsync(
            int id);

        Task<InventoryAdjustmentEntity> CreateAsync(
            InventoryAdjustmentEntity entity);

        Task<bool> UpdateAsync(
            int id,
            InventoryAdjustmentEntity entity);

        Task<bool> DeleteAsync(
            int id);
    }
}
