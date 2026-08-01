using System.Collections.Generic;

namespace Marketplacesellerportal.Catalog.DTOs
{
    public class ProductDetailsResponse
    {
        public CatalogProductResponse Product { get; set; } = new();

        public List<ProductImageResponse> Images { get; set; } = new();

        public List<ProductAttributeResponse> Attributes { get; set; } = new();

        public List<ProductReviewResponse> Reviews { get; set; } = new();

        public List<CatalogProductResponse> RelatedProducts { get; set; } = new();
    }
}
