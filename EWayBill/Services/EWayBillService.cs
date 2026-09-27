using Microsoft.EntityFrameworkCore;
using Marketplacesellerportal.Database;
using Marketplacesellerportal.EWayBill.DTOs;
using Marketplacesellerportal.EWayBill.Interfaces;

namespace Marketplacesellerportal.EWayBill.Services
{
    public class EWayBillService : IEWayBillService
    {
        private readonly ApplicationDbContext _db;
        private readonly IEWayBillRepository _repo;

        public EWayBillService(ApplicationDbContext db, IEWayBillRepository repo)
        {
            _db = db;
            _repo = repo;
        }

        public async Task<EWayBillResponse> GenerateAsync(int invoiceId, GenerateEWayBillRequest req)
        {
            var inv = await _db.SalesInvoices.FirstAsync(x => x.SalesInvoiceId == invoiceId);

            if (string.IsNullOrEmpty(inv.IrnNumber))
                throw new Exception("Generate E-Invoice (IRN) first. E-Way Bill needs IRN.");

            if (!string.IsNullOrEmpty(inv.EWayBillNumber))
            {
                return new EWayBillResponse
                {
                    EWayBillNo = inv.EWayBillNumber,
                    EWayBillDate = DateTime.Now,
                    Status = "Already Generated"
                };
            }

            // Mock - replace with NIC EWB API call
            var response = new EWayBillResponse
            {
                EWayBillNo = $"4810{new Random().Next(10000000, 99999999)}",
                EWayBillDate = DateTime.Now,
                ValidUpto = DateTime.Now.AddDays(2).ToString("dd/MM/yyyy"),
                Status = "Success"
            };

            await _repo.SaveEWayBillAsync(invoiceId, response, req);
            return response;
        }
    }
}
