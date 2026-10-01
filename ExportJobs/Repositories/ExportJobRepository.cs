using Marketplacesellerportal.Database;
using Marketplacesellerportal.Interfaces;
using Marketplacesellerportal.Models;
using Microsoft.EntityFrameworkCore;

namespace Marketplacesellerportal.ExportJobs.Repositories
{
    public class ExportJobRepository
        : IExportJobRepository
    {
        private readonly ApplicationDbContext _context;

        public ExportJobRepository(
            ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<ExportJob>> GetAllAsync()
            => await _context.ExportJobs.ToListAsync();

        public async Task<ExportJob?> GetByIdAsync(int id)
            => await _context.ExportJobs.FindAsync(id);

        public async Task<ExportJob> CreateAsync(
            ExportJob entity)
        {
            _context.ExportJobs.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> UpdateAsync(
            ExportJob entity)
        {
            _context.ExportJobs.Update(entity);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity =
                await _context.ExportJobs.FindAsync(id);

            if (entity == null)
                return false;

            _context.ExportJobs.Remove(entity);

            return await _context.SaveChangesAsync() > 0;
        }
    }
}
