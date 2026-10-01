using Marketplacesellerportal.Models;

namespace Marketplacesellerportal.ReversePickupItems.Interfaces
{
    public interface IReversePickupItemRepository
    {
        Task<List<ReversePickupItem>> GetAllAsync();
        Task<ReversePickupItem?> GetByIdAsync(int id);
        Task<ReversePickupItem> CreateAsync(ReversePickupItem entity);
        Task<bool> UpdateAsync(int id, ReversePickupItem entity); // 2 params
        Task<bool> DeleteAsync(int id);
    }
}