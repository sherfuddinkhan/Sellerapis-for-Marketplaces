namespace Marketplacesellerportal.Suppliers.DTOs
{
    public class CreateSupplierDto
    {
        public int SellerId { get; set; }

        public string SupplierCode { get; set; } = string.Empty;

        public string SupplierName { get; set; } = string.Empty;

        public string? ContactPerson { get; set; }

        public string? Phone { get; set; }

        public string? Email { get; set; }

        public string? GSTIN { get; set; }

        public string? AddressLine1 { get; set; }

        public string? AddressLine2 { get; set; }

        public string? City { get; set; }

        public string? State { get; set; }

        public string? Country { get; set; }

        public string? PostalCode { get; set; }

        public string? PaymentTerms { get; set; }

        public decimal? CreditLimit { get; set; }
    }
}
