using Marketplacesellerportal.FacilityChannel.DTOs;
using Marketplacesellerportal.FacilityChannel.Interfaces;
using Marketplacesellerportal.Models;

namespace Marketplacesellerportal.FacilityChannel.Services;

public class FacilityChannelService(IFacilityChannelRepository repository) : IFacilityChannelService
{
    public async Task<List<FacilityChannelInventoryResponse>> GetAsync(int sellerId, int customerId)
    {
        var entities = await repository.GetBySellerCustomerAsync(sellerId, customerId);
        return entities.Select(MapToResponse).ToList();
    }

    public async Task<List<FacilityChannelInventoryResponse>> GetByFilterAsync(FacilityChannelInventoryFilterRequest filter)
    {
        var entities = await repository.GetByFilterAsync(filter.SellerId, filter.CustomerId, filter.FacilityCode, filter.ChannelCode);
        return entities.Select(MapToResponse).ToList();
    }

    public async Task<FacilityChannelInventoryResponse> CreateAsync(CreateFacilityChannelInventoryRequest request)
    {
        var entity = new FacilityChannelInventory
        {
            SellerId = request.SellerId,
            CustomerId = request.CustomerId,
            ProductId = request.ProductId,
            SkuCode = request.SkuCode,
            FacilityCode = request.FacilityCode,
            ChannelCode = request.ChannelCode,
            SellableQuantity = request.SellableQuantity
        };
        var created = await repository.AddAsync(entity);
        return MapToResponse(created);
    }

    public async Task<FacilityChannelInventoryResponse> UpdateAsync(int id, UpdateFacilityChannelInventoryRequest request)
    {
        var existing = await repository.GetByIdAsync(id) ?? throw new KeyNotFoundException($"FacilityChannelInventory with id {id} not found");
        existing.SellerId = request.SellerId;
        existing.CustomerId = request.CustomerId;
        existing.ProductId = request.ProductId;
        existing.SkuCode = request.SkuCode;
        existing.FacilityCode = request.FacilityCode;
        existing.ChannelCode = request.ChannelCode;
        existing.SellableQuantity = request.SellableQuantity;
        var updated = await repository.UpdateAsync(existing);
        return MapToResponse(updated);
    }

    public Task<bool> DeleteAsync(int id) => repository.DeleteAsync(id);

    private static FacilityChannelInventoryResponse MapToResponse(FacilityChannelInventory e)
        => new(e.Id, e.SellerId, e.CustomerId, e.ProductId, e.SkuCode, e.FacilityCode, e.ChannelCode, e.SellableQuantity);
}