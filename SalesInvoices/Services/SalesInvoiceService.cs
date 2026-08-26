using Marketplacesellerportal.Models;
using Marketplacesellerportal.SalesInvoices.DTOs;
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

        // =========================================================
        // GET ALL
        // =========================================================

        public async Task<IEnumerable<SalesInvoice>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        // =========================================================
        // GET BY ID
        // =========================================================

        public async Task<SalesInvoice?> GetByIdAsync(int salesInvoiceId)
        {
            return await _repository.GetByIdAsync(salesInvoiceId);
        }

        // =========================================================
        // GET BY SALES ORDER
        // =========================================================

        public async Task<IEnumerable<SalesInvoice>> GetBySalesOrderAsync(
            int salesOrderId)
        {
            return await _repository.GetBySalesOrderAsync(salesOrderId);
        }

        // =========================================================
        // GET BY STATUS
        // =========================================================

        public async Task<IEnumerable<SalesInvoice>> GetByStatusAsync(
            string status)
        {
            return await _repository.GetByStatusAsync(status);
        }

        // =========================================================
        // GET BY PAYMENT STATUS
        // =========================================================

        public async Task<IEnumerable<SalesInvoice>> GetByPaymentStatusAsync(
            string paymentStatus)
        {
            return await _repository.GetByPaymentStatusAsync(paymentStatus);
        }

        // =========================================================
        // GET BY INVOICE NUMBER
        // =========================================================

        public async Task<SalesInvoice?> GetByInvoiceNumberAsync(
            string invoiceNumber)
        {
            return await _repository.GetByInvoiceNumberAsync(invoiceNumber);
        }

        // =========================================================
        // CREATE
        // =========================================================

        public async Task<SalesInvoice> CreateAsync(
            SalesInvoice salesInvoice)
        {
            salesInvoice.CreatedDate = DateTime.Now;

            if (salesInvoice.InvoiceDate == DateTime.MinValue)
            {
                salesInvoice.InvoiceDate = DateTime.Now;
            }

            await _repository.AddAsync(salesInvoice);
            await _repository.SaveChangesAsync();

            return salesInvoice;
        }

        // =========================================================
        // UPDATE
        // =========================================================

        public async Task<bool> UpdateAsync(
            int salesInvoiceId,
            UpdateSalesInvoiceRequest request)
        {
            var existing = await _repository.GetByIdAsync(salesInvoiceId);

            if (existing == null)
                return false;

            // =====================================================
            // REFERENCE DETAILS
            // =====================================================

            existing.SalesOrderId = request.SalesOrderId;
            existing.SellerId = request.SellerId;
            existing.CustomerId = request.CustomerId;

            // =====================================================
            // INVOICE DETAILS
            // =====================================================

            existing.InvoiceNumber = request.InvoiceNumber;
            existing.InvoiceDate = request.InvoiceDate;
            existing.InvoiceScenario = request.InvoiceScenario;
            existing.Category = request.Category;
            existing.TransactionType = request.TransactionType;

            // =====================================================
            // GST / TAX DETAILS
            // =====================================================

            existing.UserGSTIN = request.UserGSTIN;
            existing.DocumentType = request.DocumentType;
            existing.SupplyType = request.SupplyType;
            existing.PlaceOfSupply = request.PlaceOfSupply;
            existing.FinancialYear = request.FinancialYear;
            existing.ReverseCharge = request.ReverseCharge;

            // =====================================================
            // ID / REFERENCE DETAILS
            // =====================================================

            existing.Id = request.Id;
            existing.RefId = request.RefId;

            // =====================================================
            // AMOUNT DETAILS
            // =====================================================

            existing.SubTotal = request.SubTotal;
            existing.DiscountAmount = request.DiscountAmount;
            existing.TaxAmount = request.TaxAmount;
            existing.TotalAmount = request.TotalAmount;
            existing.PaidAmount = request.PaidAmount;
            existing.BalanceAmount = request.BalanceAmount;

            // =====================================================
            // PAYMENT / STATUS
            // =====================================================

            existing.PaymentStatus = request.PaymentStatus;
            existing.Status = request.Status;
            existing.Remarks = request.Remarks;

            // =====================================================
            // AUDIT
            // =====================================================

            existing.UpdatedDate = DateTime.Now;

            await _repository.UpdateAsync(existing);
            await _repository.SaveChangesAsync();

            return true;
        }

        // =========================================================
        // DELETE
        // =========================================================

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