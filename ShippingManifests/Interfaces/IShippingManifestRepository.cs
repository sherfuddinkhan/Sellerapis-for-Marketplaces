using ShippingManifestEntity =
    Marketplacesellerportal.Models.ShippingManifest;

namespace Marketplacesellerportal.ShippingManifests.Interfaces
{
    public interface IShippingManifestRepository
    {
        Task<List<ShippingManifestEntity>> GetAllAsync();

        Task<ShippingManifestEntity?> GetByIdAsync(
            string id);

        Task<ShippingManifestEntity> CreateAsync(
            ShippingManifestEntity entity);

        Task<bool> UpdateAsync(
            string id,
            ShippingManifestEntity entity);

        Task<bool> DeleteAsync(
            string id);
    }
}