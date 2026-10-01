using Marketplacesellerportal.Models;

namespace Marketplacesellerportal.ReversePickupItems.Interfaces
{
    public interface IReversePickupItemService
    {
        Task<List<ReversePickupItem>> GetAllAsync();
        Task<ReversePickupItem?> GetByIdAsync(int id);
        Task<ReversePickupItem> CreateAsync(ReversePickupItem entity);
        Task<bool> UpdateAsync(int id, ReversePickupItem entity);
        Task<bool> DeleteAsync(int id);
    }
}
