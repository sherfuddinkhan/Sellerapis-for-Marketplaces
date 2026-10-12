using Marketplacesellerportal.FacilityChannel.DTOs;

namespace Marketplacesellerportal.FacilityChannel.Interfaces;

public interface IFacilityChannelService
{
    // Fetch all records
    Task<List<FacilityChannelInventoryResponse>> GetAllAsync();
// Fetch records by seller and customer
Task<List<FacilityChannelInventoryResponse>> GetAsync(
    int sellerId,
    int customerId);

    // Fetch one record by ID
    Task<FacilityChannelInventoryResponse?> GetByIdAsync(int id);

    // Filter records
    Task<List<FacilityChannelInventoryResponse>> GetByFilterAsync(
        FacilityChannelInventoryFilterRequest filter);

    // Create a record
    Task<FacilityChannelInventoryResponse> CreateAsync(
        CreateFacilityChannelInventoryRequest request);

    // Update a record
    Task<FacilityChannelInventoryResponse> UpdateAsync(
        int id,
        UpdateFacilityChannelInventoryRequest request);

    // Delete a record
    Task<bool> DeleteAsync(int id);

}
