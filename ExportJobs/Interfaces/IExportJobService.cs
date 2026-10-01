using Marketplacesellerportal.Models;

namespace Marketplacesellerportal.ExportJobs.Interfaces
{
    public interface IExportJobService
    {
        Task<List<ExportJob>> GetAllAsync();
        Task<ExportJob?> GetByIdAsync(int id);
        Task<ExportJob> CreateAsync(ExportJob entity);
        Task<bool> UpdateAsync(int id, ExportJob entity);
        Task<bool> DeleteAsync(int id);
    }
}
