using System.Collections.Generic;
using System.Threading.Tasks;
using Marketplacesellerportal.ReversePickups.DTOs;
using ReversePickupEntity = Marketplacesellerportal.Models.ReversePickup;

namespace Marketplacesellerportal.ReversePickups.Interfaces
{
    public interface IReversePickupRepository
    {
        Task<ReversePickupEntity?> GetByIdAsync(int id, int sellerId, int customerId);
        Task<(List<ReversePickupEntity> Items, int TotalCount)> GetListAsync(ReversePickupListRequest req);
        Task<ReversePickupEntity> CreateAsync(ReversePickupEntity e);
        Task<ReversePickupEntity?> UpdateAsync(ReversePickupEntity e);
        Task<bool> DeleteAsync(int id, int sellerId, int customerId);
    }
}