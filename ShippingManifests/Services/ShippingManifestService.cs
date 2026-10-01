using ShippingManifestEntity =
    Marketplacesellerportal.Models.ShippingManifest;

namespace Marketplacesellerportal.ShippingManifests.Services
{
    public class ShippingManifestService :
        Marketplacesellerportal.ShippingManifests.Interfaces.IShippingManifestService
    {
        private readonly
            Marketplacesellerportal.ShippingManifests.Interfaces.IShippingManifestRepository
            _repository;

        public ShippingManifestService(
            Marketplacesellerportal.ShippingManifests.Interfaces.IShippingManifestRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<ShippingManifestEntity>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<ShippingManifestEntity?> GetByIdAsync(
            string id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<ShippingManifestEntity> CreateAsync(
            ShippingManifestEntity entity)
        {
            return await _repository.CreateAsync(entity);
        }

        public async Task<bool> UpdateAsync(
            string id,
            ShippingManifestEntity entity)
        {
            return await _repository.UpdateAsync(
                id,
                entity);
        }

        public async Task<bool> DeleteAsync(
            string id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}