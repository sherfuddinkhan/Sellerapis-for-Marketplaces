using Microsoft.EntityFrameworkCore;
using Marketplacesellerportal.Database;
using Marketplacesellerportal.EInvoice.DTOs;
using Marketplacesellerportal.EInvoice.Interfaces;

namespace Marketplacesellerportal.EInvoice.Repositories
{
    public class EInvoiceRepository : IEInvoiceRepository
    {
        private readonly ApplicationDbContext _db;

        public EInvoiceRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task SaveEinvoiceAsync(int invoiceId, EinvoiceResponse res)
        {
            var inv = await _db.SalesInvoices.FirstOrDefaultAsync(x => x.SalesInvoiceId == invoiceId);
            if (inv == null) throw new Exception($"SalesInvoice {invoiceId} not found");

            var so = await _db.SalesOrders.FirstOrDefaultAsync(x => x.SalesOrderId == inv.SalesOrderId);
            if (so == null) throw new Exception($"SalesOrder {inv.SalesOrderId} not found");

            // Save to both - so your Print API gets IRN
            inv.IrnNumber = res.IrnNumber;
            inv.AckNo = res.AckNo;
            inv.AckDate = res.AckDate;
            inv.SignedQRCode = res.SignedQRCode;
            inv.SignedInvoice = res.SignedInvoice;

            so.IrnNumber = res.IrnNumber;
            so.AckNo = res.AckNo;
            so.AckDate = res.AckDate;
            so.SignedQRCode = res.SignedQRCode;
            so.SignedInvoice = res.SignedInvoice;

            await _db.SaveChangesAsync();
        }
    }
}
