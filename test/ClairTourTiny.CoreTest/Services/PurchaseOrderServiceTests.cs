using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Moq;
using Xunit;
using ClairTourTiny.Infrastructure.Dto.DTOs;
using ClairTourTiny.Core.Interfaces;
using ClairTourTiny.Infrastructure.Exceptions;
namespace ClairTourTiny.Core.Services.Tests
{
    public class PurchaseOrderServiceTests
    {
        private readonly Mock<IConfiguration> _mockConfiguration;
        private readonly Mock<SqlConnection> _mockSqlConnection;
        private readonly Mock<SqlCommand> _mockSqlCommand;
        private readonly Mock<SqlDataReader> _mockSqlDataReader;
        private readonly PurchaseOrderService _service;
        public PurchaseOrderServiceTests()
        {
            _mockConfiguration = new Mock<IConfiguration>();
            _mockSqlConnection = new Mock<SqlConnection>();
            _mockSqlCommand = new Mock<SqlCommand>();
            _mockSqlDataReader = new Mock<SqlDataReader>();
            _mockConfiguration.Setup(c => c.GetConnectionString(It.IsAny<string>())).Returns("FakeConnectionString");
            _service = new PurchaseOrderService(_mockConfiguration.Object);
        }
        [Fact]
        public async Task GetPurchaseOrdersByProjectAsync_ReturnsPurchaseOrders()
        {
            // Arrange
            var entityNo = "123";
            var purchaseOrders = new List<PurchaseOrderDto>
            {
                new PurchaseOrderDto { IdPurchaseOrder = 1, PONumber = 1001, PODescription = "Test PO", Currency = "USD", TotalAmount = 100.00m, Status = "Open", CreatedDate = DateTime.Now }
            };
            _mockSqlConnection.Setup(c => c.OpenAsync()).Returns(Task.CompletedTask);
            _mockSqlCommand.Setup(c => c.ExecuteReaderAsync()).ReturnsAsync(_mockSqlDataReader.Object);
            _mockSqlDataReader.SetupSequence(r => r.ReadAsync()).ReturnsAsync(true).ReturnsAsync(false);
            _mockSqlDataReader.Setup(r => r.GetInt32(It.IsAny<int>())).Returns(1);
            _mockSqlDataReader.Setup(r => r.GetString(It.IsAny<int>())).Returns("Test PO");
            _mockSqlDataReader.Setup(r => r.GetDecimal(It.IsAny<int>())).Returns(100.00m);
            _mockSqlDataReader.Setup(r => r.GetDateTime(It.IsAny<int>())).Returns(DateTime.Now);
            // Act
            var result = await _service.GetPurchaseOrdersByProjectAsync(entityNo);
            // Assert
            Assert.NotNull(result);
            Assert.Single(result);
        }
        [Fact]
        public async Task CreatePurchaseOrderAsync_CreatesPurchaseOrder()
        {
            // Arrange
            var request = new CreatePurchaseOrderRequest { EntityNo = "123", PODescription = "New PO" };
            _mockSqlConnection.Setup(c => c.OpenAsync()).Returns(Task.CompletedTask);
            _mockSqlCommand.Setup(c => c.ExecuteNonQueryAsync()).ReturnsAsync(1);
            var newPONumberParam = new SqlParameter("@newPONumber", SqlDbType.Int) { Direction = ParameterDirection.Output, Value = 1002 };
            _mockSqlCommand.Setup(c => c.Parameters.Add(It.IsAny<SqlParameter>())).Returns(newPONumberParam);
            // Act
            var result = await _service.CreatePurchaseOrderAsync(request);
            // Assert
            Assert.NotNull(result);
            Assert.Equal(1002, result.PONumber);
        }
        [Fact]
        public async Task GetPurchaseOrdersByProjectAsync_ThrowsException()
        {
            // Arrange
            var entityNo = "123";
            _mockSqlConnection.Setup(c => c.OpenAsync()).ThrowsAsync(new Exception("Database error"));
            // Act & Assert
            await Assert.ThrowsAsync<PurchaseOrderServiceException>(() => _service.GetPurchaseOrdersByProjectAsync(entityNo));
        }
        [Fact]
        public async Task CreatePurchaseOrderAsync_ThrowsException()
        {
            // Arrange
            var request = new CreatePurchaseOrderRequest { EntityNo = "123", PODescription = "New PO" };
            _mockSqlConnection.Setup(c => c.OpenAsync()).ThrowsAsync(new Exception("Database error"));
            // Act & Assert
            await Assert.ThrowsAsync<PurchaseOrderServiceException>(() => _service.CreatePurchaseOrderAsync(request));
        }
    }
}