using Microsoft.EntityFrameworkCore;
using Marketplacesellerportal.Database;
using Marketplacesellerportal.EInvoice.DTOs;
using Marketplacesellerportal.EInvoice.Interfaces;

namespace Marketplacesellerportal.EInvoice.Services
{
    public class EInvoiceService : IEInvoiceService
    {
        private readonly ApplicationDbContext _db;
        private readonly IEInvoiceRepository _repo;

        public EInvoiceService(ApplicationDbContext db, IEInvoiceRepository repo)
        {
            _db = db;
            _repo = repo;
        }

        public async Task<EinvoiceResponse> GenerateAsync(int invoiceId, GenerateEinvoiceRequest req)
        {
            // Check if already has IRN - like real NIC
            var existing = await _db.SalesInvoices.FirstOrDefaultAsync(x => x.SalesInvoiceId == invoiceId);
            if (!string.IsNullOrEmpty(existing?.IrnNumber))
            {
                return new EinvoiceResponse
                {
                    IrnNumber = existing.IrnNumber,
                    AckNo = existing.AckNo ?? "",
                    AckDate = existing.AckDate ?? DateTime.Now,
                    SignedQRCode = existing.SignedQRCode ?? "",
                    SignedInvoice = existing.SignedInvoice ?? "",
                    Status = "Already Generated"
                };
            }

            // Mock NIC response - replace with real NIC HttpClient later
            var response = new EinvoiceResponse
            {
                IrnNumber = "5c301c5935430675cf26b3b6080928a1fa908295e60a6c349ae96349d228f",
                AckNo = "13261080607424",
                AckDate = DateTime.Now,
                SignedQRCode = "data:image/png;base64,[STRIPPED]...",
                SignedInvoice = "eyJhbGciOiJSUzI1NiIs...",
                Status = "Success"
            };

            await _repo.SaveEinvoiceAsync(invoiceId, response);
            return response;
        }

        public async Task<object> GetPrintViewAsync(int invoiceId)
        {
            var inv = await _db.SalesInvoices
                .Include(x => x.Items)
                .FirstOrDefaultAsync(x => x.SalesInvoiceId == invoiceId);

            if (inv == null) return null;

            var so = await _db.SalesOrders
                .FirstOrDefaultAsync(x => x.SalesOrderId == inv.SalesOrderId);

            var customer = await _db.SellerCustomers
                .FirstOrDefaultAsync(x => x.CustomerId == inv.CustomerId);

            return new
            {
                invoice = inv,
                salesOrder = so,
                customer = customer,
                items = inv.Items,
                transactionType = so?.TransactionType ?? inv.TransactionType ?? "REG",
                irnNumber = so?.IrnNumber ?? inv.IrnNumber,
                ackNo = so?.AckNo ?? inv.AckNo
            };
        }
    }
}