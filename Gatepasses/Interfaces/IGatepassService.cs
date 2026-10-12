
using Marketplacesellerportal.Gatepasses.DTOs;
using System.Threading.Tasks;

namespace Marketplacesellerportal.Gatepasses.Interfaces
{
    public interface IGatepassService
    {
        // Get all gatepasses
        Task<GatepassListResponse> GetAllAsync();

        // Get gatepasses by seller and customer
        Task<GatepassListResponse> GetAllBySellerCustomerAsync(
            int sellerId,
            int customerId);

        // Get gatepass by ID
        Task<GatepassResponse> GetByIdAsync(
            int id,
            int sellerId,
            int customerId);

        // Get gatepass by code
        Task<GatepassResponse> GetByCodeAsync(
            string code,
            int sellerId,
            int customerId);

        // Get filtered or paginated gatepass list
        Task<GatepassListResponse> GetListAsync(
            GatepassListRequest request);

        // Create gatepass
        Task<GatepassResponse> CreateAsync(GatepassModel model);

        // Update gatepass
        Task<GatepassResponse> UpdateAsync(
            int id,
            GatepassModel model);

        // Delete gatepass
        Task<GatepassResponse> DeleteAsync(
            int id,
            int sellerId,
            int customerId);
    }
}