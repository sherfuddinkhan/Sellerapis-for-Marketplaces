using Marketplacesellerportal.DTOs;
using Marketplacesellerportal.Putaways.DTOs;
using System.Threading.Tasks;

namespace Marketplacesellerportal.Putaways.Interfaces
{
    public interface IPutawayService
    {
        Task<PutawayResponse> GetByIdAsync(int id, int sellerId, int customerId);
        Task<PutawayListResponse> GetListAsync(PutawayListRequest request);
        Task<PutawayResponse> CreateAsync(PutawayModel model);
        Task<PutawayResponse> UpdateAsync(int id, PutawayModel model);
        Task<PutawayResponse> DeleteAsync(int id, int sellerId, int customerId);
        Task<PutawayStatisticsResponse> GetStatisticsAsync(int sellerId, int customerId);
    }
}