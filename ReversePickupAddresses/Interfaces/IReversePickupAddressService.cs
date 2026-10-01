using Marketplacesellerportal.Models;

namespace Marketplacesellerportal.Interfaces
{
    public interface IReversePickupAddressService
    {
        Task<List<ReversePickupAddress>> GetAllAsync();
        Task<ReversePickupAddress?> GetByIdAsync(int id);
        Task<ReversePickupAddress> CreateAsync(ReversePickupAddress entity);
        Task<bool> UpdateAsync(int id, ReversePickupAddress entity);
        Task<bool> DeleteAsync(int id);
    }
}
