using Marketplacesellerportal.Database; // <-- If error, change to Marketplacesellerportal.Data - check your AppDbContext.cs namespace
using Marketplacesellerportal.FacilityChannel.Interfaces;
using Marketplacesellerportal.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Marketplacesellerportal.FacilityChannel.Repositories;

// PRIMARY CONSTRUCTOR
public class FacilityChannelRepository(ApplicationDbContext context) : IFacilityChannelRepository
{
    public Task<List<FacilityChannelInventory>> GetBySellerCustomerAsync(int sellerId, int customerId)
        => context.FacilityChannelInventories.Where(x => x.SellerId == sellerId && x.CustomerId == customerId).AsNoTracking().ToListAsync();

    public Task<List<FacilityChannelInventory>> GetByFilterAsync(int sellerId, int customerId, string? facilityCode, string? channelCode)
    {
        var q = context.FacilityChannelInventories.Where(x => x.SellerId == sellerId && x.CustomerId == customerId).AsQueryable();
        if (!string.IsNullOrEmpty(facilityCode)) q = q.Where(x => x.FacilityCode == facilityCode);
        if (!string.IsNullOrEmpty(channelCode)) q = q.Where(x => x.ChannelCode == channelCode);
        return q.AsNoTracking().ToListAsync();
    }

    public Task<FacilityChannelInventory?> GetByIdAsync(int id)
        => context.FacilityChannelInventories.FirstOrDefaultAsync(x => x.Id == id);

    public async Task<FacilityChannelInventory> AddAsync(FacilityChannelInventory entity)
    {
        context.FacilityChannelInventories.Add(entity);
        await context.SaveChangesAsync();
        return entity;
    }

    public async Task<FacilityChannelInventory> UpdateAsync(FacilityChannelInventory entity)
    {
        context.FacilityChannelInventories.Update(entity);
        await context.SaveChangesAsync();
        return entity;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var e = await context.FacilityChannelInventories.FirstOrDefaultAsync(x => x.Id == id);
        if (e == null) return false;
        context.FacilityChannelInventories.Remove(e);
        await context.SaveChangesAsync();
        return true;
    }
}