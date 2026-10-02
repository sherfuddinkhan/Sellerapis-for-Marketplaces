using Marketplacesellerportal.FacilityChannel.DTOs;

namespace Marketplacesellerportal.FacilityChannel.Interfaces;

public interface IFacilityChannelService
{
    Task<List<FacilityChannelInventoryResponse>> GetAsync(int sellerId, int customerId);
    Task<List<FacilityChannelInventoryResponse>> GetByFilterAsync(FacilityChannelInventoryFilterRequest filter);
    Task<FacilityChannelInventoryResponse> CreateAsync(CreateFacilityChannelInventoryRequest request);
    Task<FacilityChannelInventoryResponse> UpdateAsync(int id, UpdateFacilityChannelInventoryRequest request);
    Task<bool> DeleteAsync(int id);
}