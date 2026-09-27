public class SellerCustomerBrandResponse
{
    public int BrandId { get; set; }

    public string BrandName { get; set; } = string.Empty;
    public string BrandCode { get; set; } = string.Empty; // single is enough - Samsung = SAMSUNG
    public string? Description { get; set; }

    public int? SellerId { get; set; }
    public int? customerId { get; set; }
   
    public bool IsActive { get; set; }

    public DateTime? CreatedDate { get; set; }

    // === YOU MISSED - ADD THESE 3 ===
    public int? BrandXID { get; set; } // TOPAZ BrandXID = b.BrandId
    public string? LogoUrl { get; set; } // b.LogoUrl
    public string? BrandImageUrl { get; set; } // alias for LogoUrl
    public DateTime? UpdatedDate { get; set; }
}
