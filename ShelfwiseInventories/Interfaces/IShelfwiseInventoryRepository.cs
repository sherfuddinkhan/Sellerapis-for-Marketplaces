using Marketplacesellerportal.DTOs;
using Marketplacesellerportal.ShelfwiseInventory.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;
// ALIAS to fix "is a namespace but is used like a type"
using ShelfwiseInventoryEntity = Marketplacesellerportal.Models.ShelfwiseInventory;

namespace Marketplacesellerportal.ShelfwiseInventory.Interfaces
{
    public interface IShelfwiseInventoryRepository
    {
        Task<ShelfwiseInventoryEntity?> GetByIdAsync(int id, int sellerId, int customerId);
        Task<(List<ShelfwiseInventoryEntity> Items, int TotalCount)> GetListAsync(ShelfwiseInventoryListRequest request);
        Task<ShelfwiseInventoryEntity> CreateAsync(ShelfwiseInventoryEntity entity);
        Task<ShelfwiseInventoryEntity?> UpdateAsync(ShelfwiseInventoryEntity entity);
        Task<bool> DeleteAsync(int id, int sellerId, int customerId);
    }
}