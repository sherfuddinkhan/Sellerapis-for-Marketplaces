using Marketplacesellerportal.Models;
using Marketplacesellerportal.Sellers.DTOs;
using Marketplacesellerportal.Sellers.Interfaces;

namespace Marketplacesellerportal.Sellers.Services
{
    public class SellerService : ISellerService
    {
        private readonly ISellerRepository _repository;

        public SellerService(ISellerRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Seller>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Seller?> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<Seller> CreateAsync(Seller seller)
        {
            if (string.IsNullOrWhiteSpace(seller.SellerCode))
            {
                seller.SellerCode =
                    "SEL-" + Guid.NewGuid().ToString("N")[..8].ToUpper();
            }

            seller.CreatedAt = DateTime.UtcNow;
            seller.IsActive = true;

            await _repository.AddAsync(seller);
            await _repository.SaveChangesAsync();

            return seller;
        }

        public async Task UpdateAsync(Seller seller)
        {
            await _repository.UpdateAsync(seller);
            await _repository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var seller = await _repository.GetByIdAsync(id);

            if (seller == null)
                return;

            await _repository.DeleteAsync(seller);
            await _repository.SaveChangesAsync();
        }
    
public async Task<IEnumerable<Seller>>
    SearchAsync(string? search)
        {
            return await _repository.SearchAsync(search);
        }


        public async Task<SellerStatistics>
            GetStatisticsAsync()
        {
            return await _repository.GetStatisticsAsync();
        }


        public async Task<(
            IEnumerable<Seller> Items,
            int TotalCount)>
            GetPagedAsync(
                int page,
                int limit)
        {
            return await _repository.GetPagedAsync(
                page,
                limit);
        }


        public async Task<IEnumerable<Seller>>
            GetSortedAsync(string? sort)
        {
            return await _repository.GetSortedAsync(sort);
        }


        public async Task<IEnumerable<Seller>>
            GetByStatusAsync(bool isActive)
        {
            return await _repository.GetByStatusAsync(
                isActive);
        }


    }
}
