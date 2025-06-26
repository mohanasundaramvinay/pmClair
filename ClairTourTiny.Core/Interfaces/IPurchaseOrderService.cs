using ClairTourTiny.Core.Models.PurchaseOrder;
using ClairTourTiny.Infrastructure.Dto.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClairTourTiny.Core.Interfaces
{
    public interface IPurchaseOrderService
    {
        /// <summary>
        /// Gets all purchase orders for a specific project
        /// </summary>
        Task<IEnumerable<PurchaseOrderModel>> GetPurchaseOrdersByProjectAsync(string entityNo);

        /// <summary>
        /// Refreshes purchase orders for a specific project (equivalent to VB.NET RefreshPurchaseOrders method)
        /// </summary>
        Task<IEnumerable<PurchaseOrderModel>> RefreshPurchaseOrdersAsync(string entityNo);

        /// <summary>
        /// Gets a specific purchase order by its number
        /// </summary>
       // Task<PurchaseOrderDto> GetPurchaseOrderAsync(int poNumber);

        /// <summary>
        /// Creates a new purchase order
        /// </summary>
        Task<CreatePurchaseOrderResponse> CreatePurchaseOrderAsync(CreatePurchaseOrderRequest request);

        // /// <summary>
        // /// Updates a purchase order's description
        // /// </summary>
        // Task<bool> UpdatePurchaseOrderDescriptionAsync(int poNumber, string description);

        // /// <summary>
        // /// Gets the total amount for a purchase order
        // /// </summary>
        // Task<decimal> GetPurchaseOrderTotalAsync(int poNumber);

        // /// <summary>
        // /// Gets purchase orders by status
        // /// </summary>
        // Task<IEnumerable<PurchaseOrderDto>> GetPurchaseOrdersByStatusAsync(string status);

        // /// <summary>
        // /// Gets purchase orders by date range
        // /// </summary>
        // Task<IEnumerable<PurchaseOrderDto>> GetPurchaseOrdersByDateRangeAsync(DateTime startDate, DateTime endDate);
    }
} 