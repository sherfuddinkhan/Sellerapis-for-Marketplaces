using Marketplacesellerportal.Database;
using Marketplacesellerportal.FacilityChannel.Interfaces;
using Marketplacesellerportal.Models;
using Microsoft.EntityFrameworkCore;

namespace Marketplacesellerportal.FacilityChannel.Repositories;

public class FacilityChannelRepository(ApplicationDbContext context)
: IFacilityChannelRepository
{
    // GET: Fetch all facility channel inventory records
    public Task<List<FacilityChannelInventory>> GetAllAsync()
    => context.FacilityChannelInventories
    .AsNoTracking()
    .OrderBy(x => x.Id)
    .ToListAsync();
// GET: Fetch records by seller and customer
public Task<List<FacilityChannelInventory>> GetBySellerCustomerAsync(
    int sellerId,
    int customerId)
    => context.FacilityChannelInventories
        .Where(x => x.SellerId == sellerId &&
                    x.CustomerId == customerId)
        .AsNoTracking()
        .ToListAsync();

    // GET: Filter records by seller, customer, facility, and channel
    public Task<List<FacilityChannelInventory>> GetByFilterAsync(
        int sellerId,
        int customerId,
        string? facilityCode,
        string? channelCode)
    {
        var query = context.FacilityChannelInventories
            .Where(x => x.SellerId == sellerId &&
                        x.CustomerId == customerId);

        if (!string.IsNullOrWhiteSpace(facilityCode))
        {
            query = query.Where(
                x => x.FacilityCode == facilityCode);
        }

        if (!string.IsNullOrWhiteSpace(channelCode))
        {
            query = query.Where(
                x => x.ChannelCode == channelCode);
        }

        return query
            .AsNoTracking()
            .ToListAsync();
    }

    // GET: Fetch one record by ID
    public Task<FacilityChannelInventory?> GetByIdAsync(int id)
        => context.FacilityChannelInventories
            .FirstOrDefaultAsync(x => x.Id == id);

    // POST: Create a record
    public async Task<FacilityChannelInventory> AddAsync(
        FacilityChannelInventory entity)
    {
        context.FacilityChannelInventories.Add(entity);

        await context.SaveChangesAsync();

        return entity;
    }

    // PUT: Update a record
    public async Task<FacilityChannelInventory> UpdateAsync(
        FacilityChannelInventory entity)
    {
        context.FacilityChannelInventories.Update(entity);

        await context.SaveChangesAsync();

        return entity;
    }

    // DELETE: Delete a record by ID
    public async Task<bool> DeleteAsync(int id)
    {
        var entity = await context.FacilityChannelInventories
            .FirstOrDefaultAsync(x => x.Id == id);

        if (entity == null)
        {
            return false;
        }

        context.FacilityChannelInventories.Remove(entity);

        await context.SaveChangesAsync();

        return true;
    }

}
