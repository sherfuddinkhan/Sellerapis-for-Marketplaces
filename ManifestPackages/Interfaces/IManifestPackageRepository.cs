using Marketplacesellerportal.Models;

namespace Marketplacesellerportal.Interfaces
{
    public interface IManifestPackageRepository
    {
        Task<List<ManifestPackage>> GetAllAsync();
        Task<ManifestPackage?> GetByIdAsync(int id);
        Task<ManifestPackage> CreateAsync(ManifestPackage entity);
        Task<bool> UpdateAsync(ManifestPackage entity);
        Task<bool> DeleteAsync(int id);
    }

  
}
