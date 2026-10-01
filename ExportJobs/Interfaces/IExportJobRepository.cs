using Marketplacesellerportal.Models;

namespace Marketplacesellerportal.Interfaces
{
    public interface IExportJobRepository
    {
        Task<List<ExportJob>> GetAllAsync();
        Task<ExportJob?> GetByIdAsync(int id);
        Task<ExportJob> CreateAsync(ExportJob entity);
        Task<bool> UpdateAsync(ExportJob entity);
        Task<bool> DeleteAsync(int id);
    }
}
