using Microsoft.EntityFrameworkCore;
using Marketplacesellerportal.Database;
using Marketplacesellerportal.SharedKernel.Interfaces;
using System.Linq.Expressions;

namespace Marketplacesellerportal.SharedKernel.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T>
        where T : class
    {
        protected readonly ApplicationDbContext _context;
        protected readonly DbSet<T> _dbSet;

        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        // Get all records
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        // Get one record by primary key
        public async Task<T?> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        // Find records using a condition
        public async Task<IEnumerable<T>> FindAsync(
            Expression<Func<T, bool>> predicate)
        {
            return await _dbSet
                .Where(predicate)
                .ToListAsync();
        }

        // Add record
        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        // Update record
        public Task UpdateAsync(T entity)
        {
            _dbSet.Update(entity);

            return Task.CompletedTask;
        }

        // Delete record
        public Task DeleteAsync(T entity)
        {
            _dbSet.Remove(entity);

            return Task.CompletedTask;
        }

        // Save changes
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}