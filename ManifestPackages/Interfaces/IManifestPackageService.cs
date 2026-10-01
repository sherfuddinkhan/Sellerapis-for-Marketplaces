using Marketplacesellerportal.Models;

namespace Marketplacesellerportal.ManifestPackages.Interfaces
{
    public interface IManifestPackageService
    {
        Task<List<ManifestPackage>> GetAllAsync();
        Task<ManifestPackage?> GetByIdAsync(int id);
        Task<ManifestPackage> CreateAsync(ManifestPackage entity);
        Task<bool> UpdateAsync(int id, ManifestPackage entity);
        Task<bool> DeleteAsync(int id);
    }
}
