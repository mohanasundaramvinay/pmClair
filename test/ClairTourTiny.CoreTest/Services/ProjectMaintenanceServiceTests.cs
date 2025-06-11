using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using AutoMapper;
using ClairTourTiny.Core.Interfaces;
using ClairTourTiny.Core.Models.ProjectMaintenance;
using ClairTourTiny.Infrastructure;
using ClairTourTiny.Infrastructure.Dto.ProjectMaintenance;
using Microsoft.Data.SqlClient;
using Moq;
using Xunit;
namespace ClairTourTiny.Core.Services.Tests
{
    public class ProjectMaintenanceServiceTests
    {
        private readonly Mock<ClairTourTinyContext> _mockDbContext;
        private readonly Mock<IMapper> _mockMapper;
        private readonly Mock<IProjectMaintenanceHelper> _mockPjtHelper;
        private readonly Mock<IProjectDataPointsService> _mockProjectDataPointsService;
        private readonly ProjectMaintenanceService _service;
        public ProjectMaintenanceServiceTests()
        {
            _mockDbContext = new Mock<ClairTourTinyContext>();
            _mockMapper = new Mock<IMapper>();
            _mockPjtHelper = new Mock<IProjectMaintenanceHelper>();
            _mockProjectDataPointsService = new Mock<IProjectDataPointsService>();
            _service = new ProjectMaintenanceService(_mockDbContext.Object, _mockMapper.Object, _mockPjtHelper.Object, _mockProjectDataPointsService.Object);
        }
        [Fact]
        public async Task GetNextAvailableProjectNumber_ShouldReturnCorrectNumber()
        {
            // Arrange
            var param = new SqlParameter("@nextProjectNumber", SqlDbType.Int)
            {
                Direction = ParameterDirection.Output,
                Value = 123
            };
            _mockDbContext.Setup(db => db.ExecuteStoredProcedureNonQueryOutputParamAsync("get_next_project_number", It.IsAny<SqlParameter>()))
                .Callback<string, SqlParameter>((sp, p) => p.Value = param.Value)
                .Returns(Task.CompletedTask);
            // Act
            var result = await _service.GetNextAvailableProjectNumber();
            // Assert
            Assert.Equal(123, result);
        }
        [Fact]
        public async Task GetPhases_ShouldReturnMappedPhases()
        {
            // Arrange
            var entityNo = "entity123";
            var phaseDtos = new List<PhaseDto> { new PhaseDto() };
            var phaseModels = new List<PhaseModel> { new PhaseModel() };
            _mockDbContext.Setup(db => db.ExecuteStoredProcedureAsync<PhaseDto>("pm2_get_phases_new", It.IsAny<SqlParameter>()))
                .ReturnsAsync(phaseDtos);
            _mockMapper.Setup(m => m.Map<List<PhaseModel>>(phaseDtos)).Returns(phaseModels);
            // Act
            var result = await _service.GetPhases(entityNo);
            // Assert
            Assert.Equal(phaseModels, result);
        }
        [Fact]
        public async Task SubmitPhases_ShouldCommitTransactionOnSuccess()
        {
            // Arrange
            var entityNo = "entity123";
            var model = new ProjectSaveModel();
            var mockTransaction = new Mock<IDbContextTransaction>();
            _mockDbContext.Setup(db => db.Database.BeginTransactionAsync())
                .ReturnsAsync(mockTransaction.Object);
            _mockDbContext.Setup(db => db.ExecuteStoredProcedureNonQueryAsync("clear_pm2_temp_tables", It.IsAny<object[]>()))
                .Returns(Task.CompletedTask);
            _mockPjtHelper.Setup(helper => helper.ProcessAllBulkSaves(model, _mockMapper.Object, _mockDbContext.Object))
                .Returns(Task.CompletedTask);
            _mockDbContext.Setup(db => db.ExecuteStoredProcedureNonQueryAsync("commit_project_maintenance", It.IsAny<object[]>()))
                .Returns(Task.CompletedTask);
            // Act
            var result = await _service.SubmitPhases(entityNo, model);
            // Assert
            Assert.True(result);
            mockTransaction.Verify(t => t.CommitAsync(), Times.Once);
        }
        [Fact]
        public async Task SubmitPhases_ShouldRollbackTransactionOnException()
        {
            // Arrange
            var entityNo = "entity123";
            var model = new ProjectSaveModel();
            var mockTransaction = new Mock<IDbContextTransaction>();
            _mockDbContext.Setup(db => db.Database.BeginTransactionAsync())
                .ReturnsAsync(mockTransaction.Object);
            _mockDbContext.Setup(db => db.ExecuteStoredProcedureNonQueryAsync("clear_pm2_temp_tables", It.IsAny<object[]>()))
                .ThrowsAsync(new Exception());
            // Act & Assert
            await Assert.ThrowsAsync<Exception>(() => _service.SubmitPhases(entityNo, model));
            mockTransaction.Verify(t => t.RollbackAsync(), Times.Once);
        }
        // Additional tests for other methods can be added here following the same pattern.
    }
}