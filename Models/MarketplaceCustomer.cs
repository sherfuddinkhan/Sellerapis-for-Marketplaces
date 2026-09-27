using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("MarketplaceCustomers")]
public class MarketplaceCustomer
{
    [Key]
    public int Id { get; set; }
    public int SellerId { get; set; }
    public int CustomerId { get; set; }
    public string? MarketplaceCustomerId { get; set; } = "";
    public string? MarketplaceName { get; set; } = "MANUAL";
    public string CompanyName { get; set; } = "";
    public string? Gstin { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public string? Address { get; set; }
    public string? City { get; set; }
    public string? State { get; set; }
    public string? StateCode { get; set; }
    public string? Pincode { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
}