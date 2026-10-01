using Marketplacesellerportal.ExportJobs.Interfaces;
using Marketplacesellerportal.Interfaces;
using Marketplacesellerportal.Models;

namespace Marketplacesellerportal.ExportJobs.Services
{ 
    public class ExportJobService
        : IExportJobService
    {
        private readonly IExportJobRepository _repo;

        public ExportJobService(
            IExportJobRepository repo)
        {
            _repo = repo;
        }

        public Task<List<ExportJob>> GetAllAsync()
            => _repo.GetAllAsync();

        public Task<ExportJob?> GetByIdAsync(int id)
            => _repo.GetByIdAsync(id);

        public Task<ExportJob> CreateAsync(
            ExportJob entity)
            => _repo.CreateAsync(entity);

        public async Task<bool> UpdateAsync(
            int id,
            ExportJob entity)
        {
            entity.ExportJobId = id;
            return await _repo.UpdateAsync(entity);
        }

        public Task<bool> DeleteAsync(int id)
            => _repo.DeleteAsync(id);
    }
}