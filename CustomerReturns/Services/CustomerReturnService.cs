using Marketplacesellerportal.Models;
using Marketplacesellerportal.CustomerReturns.Interfaces;

namespace Marketplacesellerportal.CustomerReturns.Services
{
    public class CustomerReturnService : ICustomerReturnService
    {
        private readonly ICustomerReturnRepository _repository;

        public CustomerReturnService(ICustomerReturnRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<CustomerReturn>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<CustomerReturn?> GetByIdAsync(int customerReturnId)
        {
            return await _repository.GetByIdAsync(customerReturnId);
        }

        public async Task<IEnumerable<CustomerReturn>> GetBySalesInvoiceAsync(int salesInvoiceId)
        {
            return await _repository.GetBySalesInvoiceAsync(salesInvoiceId);
        }

        public async Task<IEnumerable<CustomerReturn>> GetByProductAsync(int productId)
        {
            return await _repository.GetByProductAsync(productId);
        }

        public async Task<IEnumerable<CustomerReturn>> GetByStatusAsync(string status)
        {
            return await _repository.GetByStatusAsync(status);
        }

        public async Task<CustomerReturn?> GetByReturnNumberAsync(string returnNumber)
        {
            return await _repository.GetByReturnNumberAsync(returnNumber);
        }

        public async Task<CustomerReturn> CreateAsync(CustomerReturn customerReturn)
        {
            customerReturn.CreatedDate = DateTime.Now;

            if (customerReturn.ReturnDate == null)
                customerReturn.ReturnDate = DateTime.Now;

            await _repository.AddAsync(customerReturn);
            await _repository.SaveChangesAsync();

            return customerReturn;
        }

        public async Task<bool> UpdateAsync(int customerReturnId, CustomerReturn customerReturn)
        {
            var existing = await _repository.GetByIdAsync(customerReturnId);

            if (existing == null)
                return false;

            existing.SalesInvoiceId = customerReturn.SalesInvoiceId;
            existing.ProductId = customerReturn.ProductId;
            existing.ReturnNumber = customerReturn.ReturnNumber;
            existing.ReturnDate = customerReturn.ReturnDate;
            existing.Quantity = customerReturn.Quantity;
            existing.ReturnAmount = customerReturn.ReturnAmount;
            existing.Reason = customerReturn.Reason;
            existing.Status = customerReturn.Status;

            await _repository.UpdateAsync(existing);
            await _repository.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(int customerReturnId)
        {
            var existing = await _repository.GetByIdAsync(customerReturnId);

            if (existing == null)
                return false;

            await _repository.DeleteAsync(customerReturnId);
            await _repository.SaveChangesAsync();

            return true;
        }
    }
}
