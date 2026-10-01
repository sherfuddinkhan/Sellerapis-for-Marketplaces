using Marketplacesellerportal.Interfaces;
using Marketplacesellerportal.InvoiceTaxDetails.Interfaces;
using Marketplacesellerportal.Models;

namespace Marketplacesellerportal.Services
{
    public class InvoiceTaxDetailService
        : IInvoiceTaxDetailService
    {
        private readonly IInvoiceTaxDetailRepository _repo;

        public InvoiceTaxDetailService(
            IInvoiceTaxDetailRepository repo)
        {
            _repo = repo;
        }

        public Task<List<InvoiceTaxDetail>> GetAllAsync()
            => _repo.GetAllAsync();

        public Task<InvoiceTaxDetail?> GetByIdAsync(int id)
            => _repo.GetByIdAsync(id);

        public Task<InvoiceTaxDetail> CreateAsync(
            InvoiceTaxDetail entity)
            => _repo.CreateAsync(entity);

        public async Task<bool> UpdateAsync(
            int id,
            InvoiceTaxDetail entity)
        {
            entity.InvoiceTaxDetailId = id;

            return await _repo.UpdateAsync(entity);
        }

        public Task<bool> DeleteAsync(int id)
            => _repo.DeleteAsync(id);
    }
}
