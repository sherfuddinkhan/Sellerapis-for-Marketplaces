using Marketplacesellerportal.DTOs;
using Marketplacesellerportal.Putaways.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;
// FIX: Tell C# exactly which Putaway you mean
using PutawayEntity = Marketplacesellerportal.Models.Putaway;
using PutawayStats = Marketplacesellerportal.Putaways.DTOs.PutawayStatistics;

namespace Marketplacesellerportal.Putaways.Interfaces
{
    public interface IPutawayRepository
    {
        Task<PutawayEntity?> GetByIdAsync(int id, int sellerId, int customerId);
        Task<(List<PutawayEntity> items, int totalCount)> GetListAsync(PutawayListRequest request);
        Task<PutawayEntity> CreateAsync(PutawayEntity entity);
        Task<PutawayEntity?> UpdateAsync(PutawayEntity entity);
        Task<bool> DeleteAsync(int id, int sellerId, int customerId);
        Task<PutawayStats> GetStatisticsAsync(int sellerId, int customerId);
        Task<bool> ExistsAsync(int id, int sellerId, int customerId);
    }
}