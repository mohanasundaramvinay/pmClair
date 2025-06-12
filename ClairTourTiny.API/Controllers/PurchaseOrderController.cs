using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using ClairTourTiny.Core.Services;
using ClairTourTiny.Infrastructure.Dto.DTOs;
using ClairTourTiny.Infrastructure.Exceptions;
using ClairTourTiny.Core.Interfaces;

namespace ClairTourTiny.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PurchaseOrderController : ControllerBase
    {
        private readonly IPurchaseOrderService _purchaseOrderService;

        public PurchaseOrderController(IPurchaseOrderService purchaseOrderService)
        {
            _purchaseOrderService = purchaseOrderService;
        }

        /// <summary>
        /// Gets all purchase orders for a specific project
        /// </summary>
        /// <param name="entityNo">The entity number of the project</param>
        /// <returns>List of purchase orders</returns>
        [HttpGet("project/{entityNo}")]
        [ProducesResponseType(typeof(PurchaseOrderDto[]), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetPurchaseOrdersByProject(string entityNo)
        {
            try
            {
                var purchaseOrders = await _purchaseOrderService.GetPurchaseOrdersByProjectAsync(entityNo);
                return Ok(purchaseOrders);
            }
            catch (PurchaseOrderServiceException ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Refreshes purchase orders for a specific project (equivalent to VB.NET RefreshPurchaseOrders method)
        /// </summary>
        /// <param name="entityNo">The entity number of the project</param>
        /// <returns>List of purchase orders with refresh metadata</returns>
        /// <remarks>
        /// This endpoint is equivalent to the VB.NET RefreshPurchaseOrders method.
        /// It calls the Get_Purchase_Orders_By_Project stored procedure and returns
        /// the results with additional metadata about the refresh operation.
        /// 
        /// Example usage:
        /// GET /api/PurchaseOrder/refresh/12345
        /// 
        /// Response includes:
        /// - Success status
        /// - Message with count of purchase orders
        /// - Data array of purchase orders
        /// - Refresh timestamp
        /// </remarks>
        [HttpGet("refresh/{entityNo}")]
        [ProducesResponseType(typeof(PurchaseOrderDto[]), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> RefreshPurchaseOrders(string entityNo)
        {
            try
            {
                var purchaseOrders = await _purchaseOrderService.RefreshPurchaseOrdersAsync(entityNo);
                return Ok(new 
                { 
                    Success = true,
                    Message = $"Successfully refreshed {purchaseOrders.Count()} purchase orders for project {entityNo}",
                    Data = purchaseOrders,
                    RefreshTime = DateTime.UtcNow
                });
            }
            catch (PurchaseOrderServiceException ex)
            {
                return StatusCode(500, new 
                { 
                    Success = false,
                    Message = ex.Message,
                    RefreshTime = DateTime.UtcNow
                });
            }
        }

        /// <summary>
        /// Gets a specific purchase order by its number
        /// </summary>
        /// <param name="poNumber">The purchase order number</param>
        /// <returns>Purchase order details</returns>
        // [HttpGet("{poNumber}")]
        // [ProducesResponseType(typeof(PurchaseOrderDto), 200)]
        // [ProducesResponseType(404)]
        // [ProducesResponseType(500)]
        // public async Task<IActionResult> GetPurchaseOrder(int poNumber)
        // {
        //     try
        //     {
        //         var purchaseOrder = await _purchaseOrderService.GetPurchaseOrderAsync(poNumber);
        //         return Ok(purchaseOrder);
        //     }
        //     catch (PurchaseOrderNotFoundException)
        //     {
        //         return NotFound($"Purchase order {poNumber} not found");
        //     }
        //     catch (PurchaseOrderServiceException ex)
        //     {
        //         return StatusCode(500, ex.Message);
        //     }
        // }

        /// <summary>
        /// Creates a new purchase order
        /// </summary>
        /// <param name="request">Purchase order creation request</param>
        /// <returns>Created purchase order number</returns>
        [HttpPost]
        [ProducesResponseType(typeof(CreatePurchaseOrderResponse), 201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> CreatePurchaseOrder([FromBody] CreatePurchaseOrderRequest request)
        {
            try
            {
                var response = await _purchaseOrderService.CreatePurchaseOrderAsync(request);
                return CreatedAtAction(nameof(GetPurchaseOrdersByProject), new { poNumber = response.PONumber }, response);
            }
            catch (PurchaseOrderValidationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (PurchaseOrderServiceException ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Updates a purchase order's description
        /// </summary>
        /// <param name="poNumber">The purchase order number</param>
        /// <param name="request">Update request containing new description</param>
        /// <returns>Success status</returns>
        // [HttpPut("{poNumber}/description")]
        // [ProducesResponseType(204)]
        // [ProducesResponseType(400)]
        // [ProducesResponseType(404)]
        // [ProducesResponseType(500)]
        // public async Task<IActionResult> UpdatePurchaseOrderDescription(int poNumber, [FromBody] UpdatePurchaseOrderRequest request)
        // {
        //     try
        //     {
        //         var success = await _purchaseOrderService.UpdatePurchaseOrderDescriptionAsync(poNumber, request.PODescription);
        //         if (!success)
        //         {
        //             return NotFound($"Purchase order {poNumber} not found");
        //         }
        //         return NoContent();
        //     }
        //     catch (PurchaseOrderValidationException ex)
        //     {
        //         return BadRequest(ex.Message);
        //     }
        //     catch (PurchaseOrderServiceException ex)
        //     {
        //         return StatusCode(500, ex.Message);
        //     }
        // }

        // /// <summary>
        // /// Gets the total amount for a purchase order
        // /// </summary>
        // /// <param name="poNumber">The purchase order number</param>
        // /// <returns>Total amount</returns>
        // [HttpGet("{poNumber}/total")]
        // [ProducesResponseType(typeof(decimal), 200)]
        // [ProducesResponseType(404)]
        // [ProducesResponseType(500)]
        // public async Task<IActionResult> GetPurchaseOrderTotal(int poNumber)
        // {
        //     try
        //     {
        //         var total = await _purchaseOrderService.GetPurchaseOrderTotalAsync(poNumber);
        //         return Ok(total);
        //     }
        //     catch (PurchaseOrderNotFoundException)
        //     {
        //         return NotFound($"Purchase order {poNumber} not found");
        //     }
        //     catch (PurchaseOrderServiceException ex)
        //     {
        //         return StatusCode(500, ex.Message);
        //     }
        // }

        // /// <summary>
        // /// Gets purchase orders by status
        // /// </summary>
        // /// <param name="request">Status request</param>
        // /// <returns>List of purchase orders</returns>
        // [HttpGet("by-status")]
        // [ProducesResponseType(typeof(PurchaseOrderDto[]), 200)]
        // [ProducesResponseType(400)]
        // [ProducesResponseType(500)]
        // public async Task<IActionResult> GetPurchaseOrdersByStatus([FromQuery] PurchaseOrderStatusRequest request)
        // {
        //     try
        //     {
        //         var purchaseOrders = await _purchaseOrderService.GetPurchaseOrdersByStatusAsync(request.Status);
        //         return Ok(purchaseOrders);
        //     }
        //     catch (PurchaseOrderValidationException ex)
        //     {
        //         return BadRequest(ex.Message);
        //     }
        //     catch (PurchaseOrderServiceException ex)
        //     {
        //         return StatusCode(500, ex.Message);
        //     }
        // }

        // /// <summary>
        // /// Gets purchase orders by date range
        // /// </summary>
        // /// <param name="request">Date range request</param>
        // /// <returns>List of purchase orders</returns>
        // [HttpGet("by-date-range")]
        // [ProducesResponseType(typeof(PurchaseOrderDto[]), 200)]
        // [ProducesResponseType(400)]
        // [ProducesResponseType(500)]
        // public async Task<IActionResult> GetPurchaseOrdersByDateRange([FromQuery] DateRangeRequest request)
        // {
        //     try
        //     {
        //         var purchaseOrders = await _purchaseOrderService.GetPurchaseOrdersByDateRangeAsync(request.StartDate, request.EndDate);
        //         return Ok(purchaseOrders);
        //     }
        //     catch (PurchaseOrderValidationException ex)
        //     {
        //         return BadRequest(ex.Message);
        //     }
        //     catch (PurchaseOrderServiceException ex)
        //     {
        //         return StatusCode(500, ex.Message);
        //     }
        // }
    
    }

    public class PurchaseOrderDto
    {
        public int IdPurchaseOrder { get; set; }
        public int PONumber { get; set; }
        public string PODescription { get; set; }
        public string Currency { get; set; }
        public decimal TotalAmount { get; set; }
    }

    // public class CreatePurchaseOrderRequest
    // {
    //     public string EntityNo { get; set; }
    //     public string PODescription { get; set; }
    // }

    public class CreatePurchaseOrderResponse
    {
        public int PONumber { get; set; }
    }
} 