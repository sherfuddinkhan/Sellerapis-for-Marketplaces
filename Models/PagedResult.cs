namespace Marketplacesellerportal.Models
{
    public class PagedResult<T>
    {
        public int Page { get; set; }

        public int Limit { get; set; }

        public int TotalCount { get; set; }

        public IEnumerable<T> Items { get; set; } = new List<T>();
    }
}

