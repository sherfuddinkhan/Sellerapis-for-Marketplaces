using Marketplacesellerportal.Interfaces;
using Marketplacesellerportal.ManifestPackages.Interfaces;
using Marketplacesellerportal.Models;

namespace Marketplacesellerportal.Services
{
    public class ManifestPackageService
        : IManifestPackageService
    {
        private readonly IManifestPackageRepository _repo;

        public ManifestPackageService(
            IManifestPackageRepository repo)
        {
            _repo = repo;
        }

        public Task<List<ManifestPackage>> GetAllAsync()
            => _repo.GetAllAsync();

        public Task<ManifestPackage?> GetByIdAsync(int id)
            => _repo.GetByIdAsync(id);

        public Task<ManifestPackage> CreateAsync(
            ManifestPackage entity)
            => _repo.CreateAsync(entity);

        public async Task<bool> UpdateAsync(
            int id,
            ManifestPackage entity)
        {
            entity.ManifestPackageId = id;

            return await _repo.UpdateAsync(entity);
        }

        public Task<bool> DeleteAsync(int id)
            => _repo.DeleteAsync(id);
    }
}
