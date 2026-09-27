using Marketplacesellerportal.DTOs;
using Marketplacesellerportal.ShelfwiseInventory.DTOs;
using Marketplacesellerportal.ShelfwiseInventory.DTOs.Marketplacesellerportal.DTOs;
using System.Threading.Tasks;

namespace Marketplacesellerportal.Interfaces
{
    public interface IShelfwiseInventoryService
    {
        Task<ShelfwiseInventoryResponse> GetByIdAsync(int id, int sellerId, int customerId);
        Task<ShelfwiseInventoryListResponse> GetListAsync(ShelfwiseInventoryListRequest request);
        Task<ShelfwiseInventoryResponse> CreateAsync(ShelfwiseInventoryModel model);
        Task<ShelfwiseInventoryResponse> UpdateAsync(int id, ShelfwiseInventoryModel model);
        Task<ShelfwiseInventoryResponse> DeleteAsync(int id, int sellerId, int customerId);
    }
}

