namespace Marketplacesellerportal.ShelfwiseInventory.DTOs
{
    using System.Collections.Generic;

    namespace Marketplacesellerportal.DTOs
    {
        public class ShelfwiseInventoryResponse
        {
            public bool Success { get; set; }
            public string Message { get; set; } = string.Empty;
            public ShelfwiseInventoryModel? Data { get; set; }
        }
    }

}
