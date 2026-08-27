using Marketplacesellerportal.Models;
using Marketplacesellerportal.Suppliers.DTOs;
using Marketplacesellerportal.Suppliers.Interfaces;

namespace Marketplacesellerportal.Suppliers.Services
{
    public class SupplierService : ISupplierService
    {
        private readonly ISupplierRepository _repository;

        public SupplierService(ISupplierRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Supplier>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Supplier?> GetByIdAsync(int supplierId)
        {
            return await _repository.GetByIdAsync(supplierId);
        }

        public async Task<IEnumerable<Supplier>> GetBySellerIdAsync(int sellerId)
        {
            return await _repository.GetBySellerIdAsync(sellerId);
        }

        public async Task<Supplier?> GetSupplierAsync(int sellerId, int supplierId)
        {
            return await _repository.GetSupplierAsync(sellerId, supplierId);
        }

        public async Task<Supplier> CreateAsync(Supplier supplier)
        {
            supplier.CreatedDate = DateTime.Now;

            await _repository.AddAsync(supplier);
            await _repository.SaveChangesAsync();

            return supplier;
        }

        public async Task<bool> UpdateAsync(int supplierId, Supplier supplier)
        {
            var existing = await _repository.GetByIdAsync(supplierId);

            if (existing == null)
                return false;

            existing.SupplierCode = supplier.SupplierCode;
            existing.SupplierName = supplier.SupplierName;
            existing.ContactPerson = supplier.ContactPerson;
            existing.Phone = supplier.Phone;
            existing.Email = supplier.Email;
            existing.GSTIN = supplier.GSTIN;
            existing.AddressLine1 = supplier.AddressLine1;
            existing.AddressLine2 = supplier.AddressLine2;
            existing.City = supplier.City;
            existing.State = supplier.State;
            existing.Country = supplier.Country;
            existing.PostalCode = supplier.PostalCode;
            existing.PaymentTerms = supplier.PaymentTerms;
            existing.CreditLimit = supplier.CreditLimit;
            existing.IsActive = supplier.IsActive;
            existing.UpdatedDate = DateTime.Now;

            await _repository.UpdateAsync(existing);
            await _repository.SaveChangesAsync();

            return true;
        }
        
// =====================================================
// SEARCH
// =====================================================

public async Task<IEnumerable<Supplier>> SearchAsync(
    string search)
        {
            return await _repository.SearchAsync(search);
        }


        // =====================================================
        // SORT
        // =====================================================

        public async Task<IEnumerable<Supplier>> GetSortedAsync(
            string? sort)
        {
            return await _repository.GetSortedAsync(sort);
        }


        // =====================================================
        // PAGINATION
        // =====================================================

        public async Task<PagedResult<Supplier>> GetPagedAsync(
            int page,
            int limit)
        {
            return await _repository.GetPagedAsync(
                page,
                limit);
        }


        // =====================================================
        // STATISTICS
        // =====================================================

        public async Task<SupplierStatistics> GetStatisticsAsync()
        {
            return await _repository.GetStatisticsAsync();
        }


        public async Task<bool> DeleteAsync(int supplierId)
        {
            var existing = await _repository.GetByIdAsync(supplierId);

            if (existing == null)
                return false;

            await _repository.DeleteAsync(supplierId);
            await _repository.SaveChangesAsync();

            return true;
        }
    }
}
