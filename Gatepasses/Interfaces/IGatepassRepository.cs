using Marketplacesellerportal.Models;
using Marketplacesellerportal.Gatepasses.DTOs;

namespace Marketplacesellerportal.Gatepasses.Interfaces
{
    public interface IGatepassRepository
    {
        Task<Gatepass?> GetByIdAsync(int gatepassId, int sellerId, int customerId);
        Task<Gatepass?> GetByCodeAsync(string gatepassCode, int sellerId, int customerId);
        Task<(List<Gatepass> Items, int TotalCount)> GetListAsync(GatepassListRequest request);
        Task<List<Gatepass>> GetAllBySellerCustomerAsync(int sellerId, int customerId);
        Task<Gatepass> CreateAsync(Gatepass entity);
        Task<Gatepass?> UpdateAsync(Gatepass entity);
        Task<bool> DeleteAsync(int gatepassId, int sellerId, int customerId);
        Task<bool> ExistsAsync(int gatepassId, int sellerId, int customerId);
    }
}

