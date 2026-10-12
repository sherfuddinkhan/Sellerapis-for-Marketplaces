namespace Marketplacesellerportal.Brands.Interfaces
{
    public interface IBrandModelRepository
    {
        Task<IEnumerable<Models.BrandModel>> GetByBrandIdAsync(int brandId);
        Task<Models.BrandModel?> GetByIdAsync(int id);
        Task<Models.BrandModel> AddAsync(Models.BrandModel entity);
        Task UpdateAsync(Models.BrandModel entity);
        Task DeleteAsync(Models.BrandModel entity);
        Task SaveChangesAsync();
    }
}
