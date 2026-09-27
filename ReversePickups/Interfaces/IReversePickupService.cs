using Marketplacesellerportal.ReversePickup.DTOs;
using Marketplacesellerportal.ReversePickups.DTOs;
using System.Threading.Tasks;

namespace Marketplacesellerportal.ReversePickups.Interfaces
{
    public interface IReversePickupService
    {
        Task<ReversePickupResponse> GetByIdAsync(int id, int sellerId, int customerId);
        Task<ReversePickupListResponse> GetListAsync(ReversePickupListRequest request);
        Task<ReversePickupResponse> CreateAsync(ReversePickupModel model);
        Task<ReversePickupResponse> UpdateAsync(int id, ReversePickupModel model);
        Task<ReversePickupResponse> DeleteAsync(int id, int sellerId, int customerId);
    }
}