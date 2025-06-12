using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using ClairTourTiny.Core.Interfaces;
using ClairTourTiny.Core.Models;
using ClairTourTiny.Infrastructure.Dto.DTOs;
using ClairTourTiny.Infrastructure.Models;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;
namespace ClairTourTiny.Tests
{
    public class ProjectDataPointsServiceTests
    {
        private readonly Mock<IConfiguration> _mockConfiguration;
        private readonly Mock<ILogger<ProjectDataPointsService>> _mockLogger;
        private readonly Mock<ClairTourTinyContext> _mockContext;
        private readonly ProjectDataPointsService _service;
        private readonly string _connectionString = "Server=myServerAddress;Database=myDataBase;User Id=myUsername;Password=myPassword;";
        public ProjectDataPointsServiceTests()
        {
            _mockConfiguration = new Mock<IConfiguration>();
            _mockLogger = new Mock<ILogger<ProjectDataPointsService>>();
            _mockContext = new Mock<ClairTourTinyContext>();
            _mockConfiguration.Setup(c => c.GetConnectionString("DefaultConnection")).Returns(_connectionString);
            _service = new ProjectDataPointsService(_mockConfiguration.Object, _mockLogger.Object, _mockContext.Object);
        }
        [Fact]
        public async Task GetAllProjectData_ReturnsCorrectData()
        {
            // Arrange
            var mockConnection = new Mock<IDbConnection>();
            var mockTransaction = new Mock<IDbTransaction>();
            var mockCommand = new Mock<IDbCommand>();
            var mockDataReader = new Mock<IDataReader>();
            mockConnection.Setup(c => c.CreateCommand()).Returns(mockCommand.Object);
            mockCommand.Setup(c => c.ExecuteReader()).Returns(mockDataReader.Object);
            mockDataReader.SetupSequence(r => r.Read()).Returns(true).Returns(false);
            mockDataReader.Setup(r => r["isOperations"]).Returns(true);
            mockDataReader.Setup(r => r["isSales"]).Returns(false);
            // Act
            var result = await _service.GetAllProjectData();
            // Assert
            Assert.NotNull(result);
            Assert.True(result.UserPermissions.isOperations);
            Assert.False(result.UserPermissions.isSales);
        }
        [Fact]
        public async Task GetUserPermissions_ReturnsCorrectPermissions()
        {
            // Arrange
            var mockConnection = new Mock<IDbConnection>();
            var mockTransaction = new Mock<IDbTransaction>();
            var mockCommand = new Mock<IDbCommand>();
            var mockDataReader = new Mock<IDataReader>();
            mockConnection.Setup(c => c.CreateCommand()).Returns(mockCommand.Object);
            mockCommand.Setup(c => c.ExecuteReader()).Returns(mockDataReader.Object);
            mockDataReader.SetupSequence(r => r.Read()).Returns(true).Returns(false);
            mockDataReader.Setup(r => r["isOperations"]).Returns(true);
            mockDataReader.Setup(r => r["isSales"]).Returns(false);
            // Act
            var result = await _service.GetUserPermissions();
            // Assert
            Assert.NotNull(result);
            Assert.True(result.isOperations);
            Assert.False(result.isSales);
        }
        [Fact]
        public async Task GetUserCompanyInfo_ReturnsCorrectInfo()
        {
            // Arrange
            var mockConnection = new Mock<IDbConnection>();
            var mockTransaction = new Mock<IDbTransaction>();
            var mockCommand = new Mock<IDbCommand>();
            var mockDataReader = new Mock<IDataReader>();
            mockConnection.Setup(c => c.CreateCommand()).Returns(mockCommand.Object);
            mockCommand.Setup(c => c.ExecuteReader()).Returns(mockDataReader.Object);
            mockDataReader.SetupSequence(r => r.Read()).Returns(true).Returns(false);
            mockDataReader.Setup(r => r["warehouse_entity"]).Returns("WH1");
            mockDataReader.Setup(r => r["currency"]).Returns("USD");
            // Act
            var result = await _service.GetUserCompanyInfo();
            // Assert
            Assert.NotNull(result);
            Assert.Equal("WH1", result.warehouse_entity);
            Assert.Equal("USD", result.currency);
        }
        // Additional tests for other methods would follow a similar pattern
    }
}