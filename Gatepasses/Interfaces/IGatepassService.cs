using Marketplacesellerportal.Gatepasses.DTOs;
using Marketplacesellerportal.Gatepasses.DTOs.Marketplacesellerportal.Gatepasses.DTOs;
using System.Threading.Tasks;

namespace Marketplacesellerportal.Gatepasses.Interfaces
{
    public interface IGatepassService
    {
        Task<GatepassResponse> GetByIdAsync(int id, int sellerId, int customerId);
        Task<GatepassResponse> GetByCodeAsync(string code, int sellerId, int customerId);
        Task<GatepassListResponse> GetListAsync(GatepassListRequest request);
        Task<GatepassListResponse> GetAllBySellerCustomerAsync(int sellerId, int customerId);
        Task<GatepassResponse> CreateAsync(GatepassModel model);
        Task<GatepassResponse> UpdateAsync(int id, GatepassModel model);
        Task<GatepassResponse> DeleteAsync(int id, int sellerId, int customerId);
    }
}

