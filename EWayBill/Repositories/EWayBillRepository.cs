using Microsoft.EntityFrameworkCore;
using Marketplacesellerportal.Database;
using Marketplacesellerportal.EWayBill.DTOs;
using Marketplacesellerportal.EWayBill.Interfaces;

namespace Marketplacesellerportal.EWayBill.Repositories
{
    public class EWayBillRepository : IEWayBillRepository
    {
        private readonly ApplicationDbContext _db;
        public EWayBillRepository(ApplicationDbContext db) => _db = db;

        public async Task SaveEWayBillAsync(int invoiceId, EWayBillResponse res, GenerateEWayBillRequest req)
        {
            var inv = await _db.SalesInvoices.FirstAsync(x => x.SalesInvoiceId == invoiceId);
            var so = await _db.SalesOrders.FirstAsync(x => x.SalesOrderId == inv.SalesOrderId);

            inv.EWayBillNumber = res.EWayBillNo;
            inv.VehicleNo = req.VehicleNo;
            inv.Distance = req.Distance;
            inv.TransporterID = req.TransporterID;
            inv.TransporterName = req.TransporterName;
            inv.TransportMode = req.TransportMode;

            so.EWayBillNumber = res.EWayBillNo;
            so.VehicleNo = req.VehicleNo;
            so.Distance = req.Distance;
            so.TransporterID = req.TransporterID;
            so.TransporterName = req.TransporterName;
            so.TransportMode = req.TransportMode;

            await _db.SaveChangesAsync();
        }
    }
}