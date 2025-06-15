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
        public ProjectDataPointsServiceTests()
        {
            _mockConfiguration = new Mock<IConfiguration>();
            _mockLogger = new Mock<ILogger<ProjectDataPointsService>>();
            _mockContext = new Mock<ClairTourTinyContext>();
            _service = new ProjectDataPointsService(_mockConfiguration.Object, _mockLogger.Object, _mockContext.Object);
        }
        [Fact]
        public async Task GetAllProjectData_ReturnsCorrectData()
        {
            // Arrange
            var mockConnection = new Mock<IDbConnection>();
            var mockTransaction = new Mock<IDbTransaction>();
            var mockCommand = new Mock<IDbCommand>();
            var mockReader = new Mock<IDataReader>();
            mockConnection.Setup(c => c.CreateCommand()).Returns(mockCommand.Object);
            mockCommand.Setup(c => c.ExecuteReader()).Returns(mockReader.Object);
            mockReader.Setup(r => r.Read()).Returns(false);
            SqlMapper.AddTypeMap(typeof(string), DbType.String);
            SqlMapper.AddTypeMap(typeof(int), DbType.Int32);
            // Act
            var result = await _service.GetAllProjectData();
            // Assert
            Assert.NotNull(result);
            Assert.IsType<AllProjectData>(result);
        }
        [Fact]
        public async Task GetUserPermissions_ReturnsCorrectPermissions()
        {
            // Arrange
            var mockConnection = new Mock<IDbConnection>();
            var mockTransaction = new Mock<IDbTransaction>();
            var mockCommand = new Mock<IDbCommand>();
            var mockReader = new Mock<IDataReader>();
            mockConnection.Setup(c => c.CreateCommand()).Returns(mockCommand.Object);
            mockCommand.Setup(c => c.ExecuteReader()).Returns(mockReader.Object);
            mockReader.Setup(r => r.Read()).Returns(false);
            SqlMapper.AddTypeMap(typeof(string), DbType.String);
            SqlMapper.AddTypeMap(typeof(int), DbType.Int32);
            // Act
            var result = await _service.GetUserPermissions();
            // Assert
            Assert.NotNull(result);
            Assert.IsType<UserPermissions>(result);
        }
        [Fact]
        public async Task GetUserCompanyInfo_ReturnsCorrectInfo()
        {
            // Arrange
            var mockConnection = new Mock<IDbConnection>();
            var mockTransaction = new Mock<IDbTransaction>();
            var mockCommand = new Mock<IDbCommand>();
            var mockReader = new Mock<IDataReader>();
            mockConnection.Setup(c => c.CreateCommand()).Returns(mockCommand.Object);
            mockCommand.Setup(c => c.ExecuteReader()).Returns(mockReader.Object);
            mockReader.Setup(r => r.Read()).Returns(false);
            SqlMapper.AddTypeMap(typeof(string), DbType.String);
            SqlMapper.AddTypeMap(typeof(int), DbType.Int32);
            // Act
            var result = await _service.GetUserCompanyInfo();
            // Assert
            Assert.NotNull(result);
            Assert.IsType<UserCompanyInfo>(result);
        }
        // Additional tests for other methods can be added here following the same pattern.
    }
}