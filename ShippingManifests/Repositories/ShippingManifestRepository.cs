using Microsoft.EntityFrameworkCore;
using Marketplacesellerportal.Database;

using ShippingManifestEntity =
    Marketplacesellerportal.Models.ShippingManifest;

namespace Marketplacesellerportal.ShippingManifests.Repositories
{
    public class ShippingManifestRepository :
        Marketplacesellerportal.ShippingManifests.Interfaces.IShippingManifestRepository
    {
        private readonly Marketplacesellerportal.Database.ApplicationDbContext _context;

        public ShippingManifestRepository(
            Marketplacesellerportal.Database.ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<ShippingManifestEntity>> GetAllAsync()
        {
            return await _context.ShippingManifests
                .ToListAsync();
        }

        public async Task<ShippingManifestEntity?> GetByIdAsync(
            string id)
        {
            return await _context.ShippingManifests
                .FirstOrDefaultAsync(x =>
                    x.ShippingManifestCode == id);
        }

        public async Task<ShippingManifestEntity> CreateAsync(
            ShippingManifestEntity entity)
        {
            await _context.ShippingManifests.AddAsync(entity);

            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<bool> UpdateAsync(
            string id,
            ShippingManifestEntity entity)
        {
            var existing =
                await _context.ShippingManifests
                    .FirstOrDefaultAsync(x =>
                        x.ShippingManifestCode == id);

            if (existing == null)
            {
                return false;
            }

            existing.Channel =
                entity.Channel;

            existing.ShippingProviderCode =
                entity.ShippingProviderCode;

            existing.ShippingProviderName =
                entity.ShippingProviderName;

            existing.ShippingMethodCode =
                entity.ShippingMethodCode;

            existing.Comments =
                entity.Comments;

            existing.Status =
                entity.Status;

            existing.ThirdPartyShipping =
                entity.ThirdPartyShipping;

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(
            string id)
        {
            var existing =
                await _context.ShippingManifests
                    .FirstOrDefaultAsync(x =>
                        x.ShippingManifestCode == id);

            if (existing == null)
            {
                return false;
            }

            _context.ShippingManifests.Remove(existing);

            await _context.SaveChangesAsync();

            return true;
        }
    }
}