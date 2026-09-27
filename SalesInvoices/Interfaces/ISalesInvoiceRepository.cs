using Marketplacesellerportal.Models;

namespace Marketplacesellerportal.SalesInvoices.Interfaces
{
    public interface ISalesInvoiceRepository
    {
        // =========================================================
        // GET
        // =========================================================

        Task<IEnumerable<SalesInvoice>> GetAllAsync();

        Task<SalesInvoice?> GetByIdAsync(
            int salesInvoiceId);

        Task<IEnumerable<SalesInvoice>> GetBySalesOrderAsync(
            int salesOrderId);
        Task<IEnumerable<SalesInvoice>>
    GetBySellerAndCustomerAsync(
        int sellerId,
        int customerId);
        Task<IEnumerable<SalesInvoice>> GetByStatusAsync(
            string status);

        Task<IEnumerable<SalesInvoice>> GetByPaymentStatusAsync(
            string paymentStatus);

        Task<IEnumerable<SalesInvoice>> GetBySellerCustomerAsync(
            int sellerId,
            int customerId);

        Task<SalesInvoice?> GetByInvoiceNumberAsync(
            string invoiceNumber);

        // =========================================================
        // CREATE / UPDATE / DELETE
        // =========================================================

        Task AddAsync(
            SalesInvoice salesInvoice);

        Task UpdateAsync(
            SalesInvoice salesInvoice);

        Task DeleteAsync(
            int salesInvoiceId);

        // =========================================================
        // DELETE CHILDREN
        // Used when PUT replaces the invoice aggregate
        // =========================================================

        Task DeleteItemsAsync(
            int salesInvoiceId);

        Task DeletePaymentsAsync(
            int salesInvoiceId);

        Task DeleteAdditionalChargesAsync(
            int salesInvoiceId);

        // =========================================================
        // SAVE
        // =========================================================

        Task SaveChangesAsync();
    }
}