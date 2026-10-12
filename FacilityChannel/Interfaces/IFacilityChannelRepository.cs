using Marketplacesellerportal.Models;

namespace Marketplacesellerportal.FacilityChannel.Interfaces;

public interface IFacilityChannelRepository
{
    Task<List<FacilityChannelInventory>> GetAllAsync();
Task<List<FacilityChannelInventory>> GetBySellerCustomerAsync(
    int sellerId,
    int customerId);

    Task<FacilityChannelInventory?> GetByIdAsync(int id);

    Task<List<FacilityChannelInventory>> GetByFilterAsync(
        int sellerId,
        int customerId,
        string? facilityCode,
        string? channelCode);

    Task<FacilityChannelInventory> AddAsync(
        FacilityChannelInventory entity);

    Task<FacilityChannelInventory> UpdateAsync(
        FacilityChannelInventory entity);

    Task<bool> DeleteAsync(int id);

}
