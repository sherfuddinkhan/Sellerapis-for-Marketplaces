using Marketplacesellerportal.FacilityChannel.DTOs;
using Marketplacesellerportal.FacilityChannel.Interfaces;
using Marketplacesellerportal.Models;

namespace Marketplacesellerportal.FacilityChannel.Services;

public class FacilityChannelService(
IFacilityChannelRepository repository) : IFacilityChannelService
{
    // GET: Fetch all facility channel inventory records
    public async Task<List<FacilityChannelInventoryResponse>> GetAllAsync()
    {
        var entities = await repository.GetAllAsync();

    return entities.Select(MapToResponse).ToList();
    }

    // GET: Fetch records by seller and customer
    public async Task<List<FacilityChannelInventoryResponse>> GetAsync(
        int sellerId,
        int customerId)
    {
        var entities = await repository.GetBySellerCustomerAsync(
            sellerId,
            customerId);

        return entities.Select(MapToResponse).ToList();
    }

    // GET: Fetch a single record by ID
    public async Task<FacilityChannelInventoryResponse?> GetByIdAsync(int id)
    {
        var entity = await repository.GetByIdAsync(id);

        if (entity == null)
        {
            return null;
        }

        return MapToResponse(entity);
    }

    // GET: Fetch records using filters
    public async Task<List<FacilityChannelInventoryResponse>> GetByFilterAsync(
        FacilityChannelInventoryFilterRequest filter)
    {
        var entities = await repository.GetByFilterAsync(
            filter.SellerId,
            filter.CustomerId,
            filter.FacilityCode,
            filter.ChannelCode);

        return entities.Select(MapToResponse).ToList();
    }

    // POST: Create a facility channel inventory record
    public async Task<FacilityChannelInventoryResponse> CreateAsync(
        CreateFacilityChannelInventoryRequest request)
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

    // PUT: Update an existing facility channel inventory record
    public async Task<FacilityChannelInventoryResponse> UpdateAsync(
        int id,
        UpdateFacilityChannelInventoryRequest request)
    {
        var existing = await repository.GetByIdAsync(id)
            ?? throw new KeyNotFoundException(
                $"FacilityChannelInventory with id {id} not found");

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

    // DELETE: Delete a facility channel inventory record
    public Task<bool> DeleteAsync(int id)
    {
        return repository.DeleteAsync(id);
    }

    // Map entity to response DTO
    private static FacilityChannelInventoryResponse MapToResponse(
        FacilityChannelInventory e)
    {
        return new FacilityChannelInventoryResponse(
            e.Id,
            e.SellerId,
            e.CustomerId,
            e.ProductId,
            e.SkuCode,
            e.FacilityCode,
            e.ChannelCode,
            e.SellableQuantity);
    }
}
