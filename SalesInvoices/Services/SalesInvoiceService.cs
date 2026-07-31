using Marketplacesellerportal.Models;
using Marketplacesellerportal.SalesInvoices.Interfaces;

namespace Marketplacesellerportal.SalesInvoices.Services
{
    public class SalesInvoiceService : ISalesInvoiceService
    {
        private readonly ISalesInvoiceRepository _repository;

        public SalesInvoiceService(ISalesInvoiceRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<SalesInvoice>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<SalesInvoice?> GetByIdAsync(int salesInvoiceId)
        {
            return await _repository.GetByIdAsync(salesInvoiceId);
        }

        public async Task<IEnumerable<SalesInvoice>> GetBySalesOrderAsync(int salesOrderId)
        {
            return await _repository.GetBySalesOrderAsync(salesOrderId);
        }

        public async Task<IEnumerable<SalesInvoice>> GetByStatusAsync(string status)
        {
            return await _repository.GetByStatusAsync(status);
        }

        public async Task<IEnumerable<SalesInvoice>> GetByPaymentStatusAsync(string paymentStatus)
        {
            return await _repository.GetByPaymentStatusAsync(paymentStatus);
        }

        public async Task<SalesInvoice?> GetByInvoiceNumberAsync(string invoiceNumber)
        {
            return await _repository.GetByInvoiceNumberAsync(invoiceNumber);
        }

        public async Task<SalesInvoice> CreateAsync(SalesInvoice salesInvoice)
        {
            salesInvoice.CreatedDate = DateTime.Now;

            if (salesInvoice.InvoiceDate == DateTime.MinValue)
                salesInvoice.InvoiceDate = DateTime.Now;

            await _repository.AddAsync(salesInvoice);
            await _repository.SaveChangesAsync();

            return salesInvoice;
        }

        public async Task<bool> UpdateAsync(int salesInvoiceId, SalesInvoice salesInvoice)
        {
            var existing = await _repository.GetByIdAsync(salesInvoiceId);

            if (existing == null)
                return false;

            existing.SalesOrderId = salesInvoice.SalesOrderId;
            existing.InvoiceNumber = salesInvoice.InvoiceNumber;
            existing.InvoiceDate = salesInvoice.InvoiceDate;
            existing.SubTotal = salesInvoice.SubTotal;
            existing.DiscountAmount = salesInvoice.DiscountAmount;
            existing.TaxAmount = salesInvoice.TaxAmount;
            existing.TotalAmount = salesInvoice.TotalAmount;
            existing.PaidAmount = salesInvoice.PaidAmount;
            existing.BalanceAmount = salesInvoice.BalanceAmount;
            existing.PaymentStatus = salesInvoice.PaymentStatus;
            existing.Status = salesInvoice.Status;
            existing.Remarks = salesInvoice.Remarks;
            existing.UpdatedDate = DateTime.Now;

            await _repository.UpdateAsync(existing);
            await _repository.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(int salesInvoiceId)
        {
            var existing = await _repository.GetByIdAsync(salesInvoiceId);

            if (existing == null)
                return false;

            await _repository.DeleteAsync(salesInvoiceId);
            await _repository.SaveChangesAsync();

            return true;
        }
    }
}
