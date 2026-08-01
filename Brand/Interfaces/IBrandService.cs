using Marketplacesellerportal.Brand.DTOs;

namespace Marketplacesellerportal.Brand.Interfaces
{
    public interface IBrandService
    {
        Task<IEnumerable<BrandResponse>> GetAllAsync();

        Task<BrandResponse?> GetByIdAsync(int brandId);

        Task<IEnumerable<BrandResponse>> GetActiveBrandsAsync();

        Task<bool> CreateAsync(CreateBrandRequest request);

        Task<bool> UpdateAsync(UpdateBrandRequest request);

        Task<bool> DeleteAsync(int brandId);
    }
}
