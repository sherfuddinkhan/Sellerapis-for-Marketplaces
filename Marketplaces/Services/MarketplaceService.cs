using Marketplacesellerportal.Marketplaces.Interfaces;
using Marketplacesellerportal.Models;

namespace Marketplacesellerportal.Marketplaces.Services
{
    public class MarketplaceService
        : IMarketplaceService
    {
        private readonly IMarketplaceRepository _repository;

        public MarketplaceService(
            IMarketplaceRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Marketplace>>
            GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Marketplace?>
            GetByIdAsync(int marketplaceId)
        {
            return await _repository.GetByIdAsync(
                marketplaceId);
        }

        public async Task<Marketplace?>
            GetByCodeAsync(string marketplaceCode)
        {
            return await _repository.GetByCodeAsync(
                marketplaceCode);
        }

        public async Task<IEnumerable<Marketplace>>
            GetActiveAsync()
        {
            return await _repository.GetActiveAsync();
        }

        public async Task<IEnumerable<Marketplace>>
            SearchAsync(string? search)
        {
            return await _repository.SearchAsync(
                search);
        }

        public async Task<IEnumerable<Marketplace>>
            GetSortedAsync(string? sort)
        {
            return await _repository.GetSortedAsync(
                sort);
        }

        public async Task<Marketplace>
            CreateAsync(Marketplace marketplace)
        {
            marketplace.CreatedDate = DateTime.Now;

            await _repository.AddAsync(
                marketplace);

            await _repository.SaveChangesAsync();

            return marketplace;
        }

        public async Task<bool>
            UpdateAsync(
                int marketplaceId,
                Marketplace marketplace)
        {
            var existing =
                await _repository.GetByIdAsync(
                    marketplaceId);

            if (existing == null)
                return false;

            existing.MarketplaceName =
                marketplace.MarketplaceName;

            existing.MarketplaceCode =
                marketplace.MarketplaceCode;

            existing.Description =
                marketplace.Description;

            existing.IsActive =
                marketplace.IsActive;

            existing.UpdatedDate =
                DateTime.Now;

            await _repository.UpdateAsync(
                existing);

            await _repository.SaveChangesAsync();

            return true;
        }

        public async Task<bool>
            DeleteAsync(int marketplaceId)
        {
            var existing =
                await _repository.GetByIdAsync(
                    marketplaceId);

            if (existing == null)
                return false;

            await _repository.DeleteAsync(
                marketplaceId);

            await _repository.SaveChangesAsync();

            return true;
        }
    }
}
