using Marketplacesellerportal.Models;
using Marketplacesellerportal.Models;
using Marketplacesellerportal.SalesOrderItems.DTOs;
using Marketplacesellerportal.SalesOrderItems.Interfaces;
using System;


namespace Marketplacesellerportal.SalesOrderItems.Interfaces
{
    public interface ISalesOrderItemService
    {
        Task<IEnumerable<SalesOrderItem>> GetAllAsync();

        Task<SalesOrderItem?> GetByIdAsync(int salesOrderItemId);

        Task<IEnumerable<SalesOrderItem>> GetBySalesOrderAsync(int salesOrderId);

        Task<IEnumerable<SalesOrderItem>> GetByProductAsync(int productId);
        Task<IEnumerable<SalesOrderItem>> SearchAsync(
    string? search);

        Task<SalesOrderItemStatistics> GetStatisticsAsync();

        Task<(IEnumerable<SalesOrderItem> Items, int TotalCount)>
            GetPagedAsync(
                int page,
                int limit);

        Task<IEnumerable<SalesOrderItem>> GetSortedAsync(
            string? sort);
        Task<SalesOrderItem> CreateAsync(SalesOrderItem salesOrderItem);

        Task<bool> UpdateAsync(int salesOrderItemId, SalesOrderItem salesOrderItem);

        Task<bool> DeleteAsync(int salesOrderItemId);
    }
}
