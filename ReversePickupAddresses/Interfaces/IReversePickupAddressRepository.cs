using Marketplacesellerportal.Models;

namespace Marketplacesellerportal.Interfaces
{
    public interface IReversePickupAddressRepository
    {
        Task<List<ReversePickupAddress>> GetAllAsync();
        Task<ReversePickupAddress?> GetByIdAsync(int id);
        Task<ReversePickupAddress> CreateAsync(ReversePickupAddress entity);
        Task<bool> UpdateAsync(ReversePickupAddress entity);
        Task<bool> DeleteAsync(int id);
    }
}
