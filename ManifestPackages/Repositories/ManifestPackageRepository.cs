using Marketplacesellerportal.Database;
using Marketplacesellerportal.Interfaces;
using Marketplacesellerportal.Models;
using Microsoft.EntityFrameworkCore;

namespace Marketplacesellerportal.Repositories
{
    public class ManifestPackageRepository
        : IManifestPackageRepository
    {
        private readonly ApplicationDbContext _context;

        public ManifestPackageRepository(
            ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<ManifestPackage>> GetAllAsync()
            => await _context.ManifestPackages.ToListAsync();

        public async Task<ManifestPackage?> GetByIdAsync(int id)
            => await _context.ManifestPackages.FindAsync(id);

        public async Task<ManifestPackage> CreateAsync(
            ManifestPackage entity)
        {
            _context.ManifestPackages.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> UpdateAsync(
            ManifestPackage entity)
        {
            _context.ManifestPackages.Update(entity);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity =
                await _context.ManifestPackages.FindAsync(id);

            if (entity == null)
                return false;

            _context.ManifestPackages.Remove(entity);

            return await _context.SaveChangesAsync() > 0;
        }
    }
}
