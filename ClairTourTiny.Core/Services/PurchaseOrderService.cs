using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using ClairTourTiny.Infrastructure.Dto.DTOs;
using ClairTourTiny.Core.Interfaces;
using ClairTourTiny.Infrastructure.Exceptions;

namespace ClairTourTiny.Core.Services
{
    public class PurchaseOrderService : IPurchaseOrderService
    {
        private readonly string _connectionString;
        private readonly IConfiguration _configuration;

        public PurchaseOrderService(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DefaultConnection");
            Console.WriteLine("PurchaseOrderService initialized with connection string");
        }

        public async Task<IEnumerable<PurchaseOrderDto>> GetPurchaseOrdersByProjectAsync(string entityNo)
        {
            Console.WriteLine($"Getting purchase orders for project: {entityNo}");
            try
            {
                using var connection = new SqlConnection(_connectionString);
                Console.WriteLine("Opening database connection...");
                await connection.OpenAsync();
                Console.WriteLine("Database connection opened successfully");

                using var command = new SqlCommand("Get_Purchase_Orders_By_Project", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@entityno", entityNo);
                Console.WriteLine($"Executing stored procedure: Get_Purchase_Orders_By_Project with entityNo: {entityNo}");

                var purchaseOrders = new List<PurchaseOrderDto>();
                using var reader = await command.ExecuteReaderAsync();
                Console.WriteLine("Reading purchase orders from database...");
                while (await reader.ReadAsync())
                {
                    purchaseOrders.Add(MapToPurchaseOrderDto(reader));
                }
                Console.WriteLine($"Successfully retrieved {purchaseOrders.Count} purchase orders for project {entityNo}");
                return purchaseOrders;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetPurchaseOrdersByProjectAsync: {ex.Message}");
                throw new PurchaseOrderServiceException($"Error retrieving purchase orders for project {entityNo}", ex);
            }
        }

        public async Task<IEnumerable<PurchaseOrderDto>> RefreshPurchaseOrdersAsync(string entityNo)
        {
            Console.WriteLine($"Refreshing purchase orders for project: {entityNo}");
            try
            {
                // This method is equivalent to the VB.NET RefreshPurchaseOrders method
                // It uses the same stored procedure and logic
                var purchaseOrders = await GetPurchaseOrdersByProjectAsync(entityNo);
                Console.WriteLine($"Successfully refreshed {purchaseOrders.Count()} purchase orders for project {entityNo}");
                return purchaseOrders;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in RefreshPurchaseOrdersAsync: {ex.Message}");
                throw new PurchaseOrderServiceException($"Error refreshing purchase orders for project {entityNo}", ex);
            }
        }

        // public async Task<PurchaseOrderDto> GetPurchaseOrderAsync(int poNumber)
        // {
        //     Console.WriteLine($"Getting purchase order details for PO Number: {poNumber}");
        //     try
        //     {
        //         using var connection = new SqlConnection(_connectionString);
        //         Console.WriteLine("Opening database connection...");
        //         await connection.OpenAsync();
        //         Console.WriteLine("Database connection opened successfully");

        //         using var command = new SqlCommand("Get_Purchase_Order_Details", connection)
        //         {
        //             CommandType = CommandType.StoredProcedure
        //         };
        //         command.Parameters.AddWithValue("@PONumber", poNumber);
        //         Console.WriteLine($"Executing stored procedure: Get_Purchase_Order_Details with PONumber: {poNumber}");

        //         using var reader = await command.ExecuteReaderAsync();
        //         if (await reader.ReadAsync())
        //         {
        //             Console.WriteLine($"Successfully retrieved purchase order {poNumber}");
        //             return MapToPurchaseOrderDto(reader);
        //         }
        //         Console.WriteLine($"Purchase order {poNumber} not found");
        //         throw new PurchaseOrderNotFoundException($"Purchase order {poNumber} not found");
        //     }
        //     catch (PurchaseOrderNotFoundException)
        //     {
        //         throw;
        //     }
        //     catch (Exception ex)
        //     {
        //         Console.WriteLine($"Error in GetPurchaseOrderAsync: {ex.Message}");
        //         throw new PurchaseOrderServiceException($"Error retrieving purchase order {poNumber}", ex);
        //     }
        // }

        public async Task<CreatePurchaseOrderResponse> CreatePurchaseOrderAsync(CreatePurchaseOrderRequest request)
        {
            Console.WriteLine($"Creating new purchase order for entity: {request.EntityNo}");
            try
            {
                using var connection = new SqlConnection(_connectionString);
                Console.WriteLine("Opening database connection...");
                await connection.OpenAsync();
                Console.WriteLine("Database connection opened successfully");

                using var command = new SqlCommand("Create_Purchase_Order_Blank", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@entityno", request.EntityNo);
                command.Parameters.AddWithValue("@PODescription", request.PODescription);
                Console.WriteLine($"Executing stored procedure: Create_Purchase_Order_Blank with EntityNo: {request.EntityNo}, Description: {request.PODescription}");
                
                var newPONumberParam = new SqlParameter("@newPONumber", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                };
                command.Parameters.Add(newPONumberParam);

                await command.ExecuteNonQueryAsync();
                var newPONumber = (int)newPONumberParam.Value;
                Console.WriteLine($"Successfully created purchase order with PO Number: {newPONumber}");
                return new CreatePurchaseOrderResponse { PONumber = newPONumber };
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in CreatePurchaseOrderAsync: {ex.Message}");
                throw new PurchaseOrderServiceException("Error creating purchase order", ex);
            }
        }

        // public async Task<bool> UpdatePurchaseOrderDescriptionAsync(int poNumber, string description)
        // {
        //     Console.WriteLine($"Updating description for purchase order: {poNumber}");
        //     try
        //     {
        //         using var connection = new SqlConnection(_connectionString);
        //         Console.WriteLine("Opening database connection...");
        //         await connection.OpenAsync();
        //         Console.WriteLine("Database connection opened successfully");

        //         using var command = new SqlCommand("Update_Purchase_Order_Description", connection)
        //         {
        //             CommandType = CommandType.StoredProcedure
        //         };

        //         command.Parameters.AddWithValue("@PONumber", poNumber);
        //         command.Parameters.AddWithValue("@Description", description);
        //         Console.WriteLine($"Executing stored procedure: Update_Purchase_Order_Description with PONumber: {poNumber}");

        //         var rowsAffected = await command.ExecuteNonQueryAsync();
        //         Console.WriteLine($"Update completed. Rows affected: {rowsAffected}");
        //         return rowsAffected > 0;
        //     }
        //     catch (Exception ex)
        //     {
        //         Console.WriteLine($"Error in UpdatePurchaseOrderDescriptionAsync: {ex.Message}");
        //         throw new PurchaseOrderServiceException($"Error updating purchase order {poNumber}", ex);
        //     }
        // }

        // public async Task<decimal> GetPurchaseOrderTotalAsync(int poNumber)
        // {
        //     Console.WriteLine($"Getting total amount for purchase order: {poNumber}");
        //     try
        //     {
        //         using var connection = new SqlConnection(_connectionString);
        //         Console.WriteLine("Opening database connection...");
        //         await connection.OpenAsync();
        //         Console.WriteLine("Database connection opened successfully");

        //         using var command = new SqlCommand("Get_Purchase_Order_Total", connection)
        //         {
        //             CommandType = CommandType.StoredProcedure
        //         };

        //         command.Parameters.AddWithValue("@PONumber", poNumber);
        //         Console.WriteLine($"Executing stored procedure: Get_Purchase_Order_Total with PONumber: {poNumber}");
        //         var result = await command.ExecuteScalarAsync();
        //         var total = Convert.ToDecimal(result);
        //         Console.WriteLine($"Successfully retrieved total amount: {total} for PO: {poNumber}");
        //         return total;
        //     }
        //     catch (Exception ex)
        //     {
        //         Console.WriteLine($"Error in GetPurchaseOrderTotalAsync: {ex.Message}");
        //         throw new PurchaseOrderServiceException($"Error getting total for purchase order {poNumber}", ex);
        //     }
        // }

        // public async Task<IEnumerable<PurchaseOrderDto>> GetPurchaseOrdersByStatusAsync(string status)
        // {
        //     Console.WriteLine($"Getting purchase orders with status: {status}");
        //     try
        //     {
        //         using var connection = new SqlConnection(_connectionString);
        //         Console.WriteLine("Opening database connection...");
        //         await connection.OpenAsync();
        //         Console.WriteLine("Database connection opened successfully");

        //         using var command = new SqlCommand("Get_Purchase_Orders_By_Status", connection)
        //         {
        //             CommandType = CommandType.StoredProcedure
        //         };

        //         command.Parameters.AddWithValue("@Status", status);
        //         Console.WriteLine($"Executing stored procedure: Get_Purchase_Orders_By_Status with Status: {status}");
        //         var purchaseOrders = new List<PurchaseOrderDto>();
        //         using var reader = await command.ExecuteReaderAsync();
        //         Console.WriteLine("Reading purchase orders from database...");
        //         while (await reader.ReadAsync())
        //         {
        //             purchaseOrders.Add(MapToPurchaseOrderDto(reader));
        //         }
        //         Console.WriteLine($"Successfully retrieved {purchaseOrders.Count} purchase orders with status {status}");
        //         return purchaseOrders;
        //     }
        //     catch (Exception ex)
        //     {
        //         Console.WriteLine($"Error in GetPurchaseOrdersByStatusAsync: {ex.Message}");
        //         throw new PurchaseOrderServiceException($"Error retrieving purchase orders by status {status}", ex);
        //     }
        // }

        // public async Task<IEnumerable<PurchaseOrderDto>> GetPurchaseOrdersByDateRangeAsync(DateTime startDate, DateTime endDate)
        // {
        //     Console.WriteLine($"Getting purchase orders between {startDate:yyyy-MM-dd} and {endDate:yyyy-MM-dd}");
        //     try
        //     {
        //         using var connection = new SqlConnection(_connectionString);
        //         Console.WriteLine("Opening database connection...");
        //         await connection.OpenAsync();
        //         Console.WriteLine("Database connection opened successfully");

        //         using var command = new SqlCommand("Get_Purchase_Orders_By_Date_Range", connection)
        //         {
        //             CommandType = CommandType.StoredProcedure
        //         };

        //         command.Parameters.AddWithValue("@StartDate", startDate);
        //         command.Parameters.AddWithValue("@EndDate", endDate);
        //         Console.WriteLine($"Executing stored procedure: Get_Purchase_Orders_By_Date_Range with StartDate: {startDate:yyyy-MM-dd}, EndDate: {endDate:yyyy-MM-dd}");
        //         var purchaseOrders = new List<PurchaseOrderDto>();
        //         using var reader = await command.ExecuteReaderAsync();
        //         Console.WriteLine("Reading purchase orders from database...");
        //         while (await reader.ReadAsync())
        //         {
        //             purchaseOrders.Add(MapToPurchaseOrderDto(reader));
        //         }
        //         Console.WriteLine($"Successfully retrieved {purchaseOrders.Count} purchase orders in the date range");
        //         return purchaseOrders;
        //     }
        //     catch (Exception ex)
        //     {
        //         Console.WriteLine($"Error in GetPurchaseOrdersByDateRangeAsync: {ex.Message}");
        //         throw new PurchaseOrderServiceException($"Error retrieving purchase orders by date range", ex);
        //     }
        // }

        private static PurchaseOrderDto MapToPurchaseOrderDto(SqlDataReader reader)
        {
            return new PurchaseOrderDto
            {
                IdPurchaseOrder = reader.GetInt32(reader.GetOrdinal("idPurchaseOrder")),
                PONumber = reader.GetInt32(reader.GetOrdinal("PONumber")),
                PODescription = reader.GetString(reader.GetOrdinal("PODescription")),
                Currency = reader.GetString(reader.GetOrdinal("currency")),
                TotalAmount = reader.GetDecimal(reader.GetOrdinal("TotalAmount")),
                Status = reader.IsDBNull(reader.GetOrdinal("Status")) ? null : reader.GetString(reader.GetOrdinal("Status")),
                CreatedDate = reader.GetDateTime(reader.GetOrdinal("CreatedDate")),
                LastModifiedDate = reader.IsDBNull(reader.GetOrdinal("LastModifiedDate")) ? 
                    null : (DateTime?)reader.GetDateTime(reader.GetOrdinal("LastModifiedDate"))
            };
        }
    }
} 