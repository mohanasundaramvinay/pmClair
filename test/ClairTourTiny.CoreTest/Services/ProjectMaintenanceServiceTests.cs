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
        private readonly Mock<ClairTourTinyContext> _dbContextMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly Mock<IProjectMaintenanceHelper> _pjtHelperMock;
        private readonly Mock<IProjectDataPointsService> _projectDataPointsServiceMock;
        private readonly ProjectMaintenanceService _service;
        public ProjectMaintenanceServiceTests()
        {
            _dbContextMock = new Mock<ClairTourTinyContext>();
            _mapperMock = new Mock<IMapper>();
            _pjtHelperMock = new Mock<IProjectMaintenanceHelper>();
            _projectDataPointsServiceMock = new Mock<IProjectDataPointsService>();
            _service = new ProjectMaintenanceService(_dbContextMock.Object, _mapperMock.Object, _pjtHelperMock.Object, _projectDataPointsServiceMock.Object);
        }
        [Fact]
        public async Task GetNextAvailableProjectNumber_ReturnsCorrectNumber()
        {
            // Arrange
            var param = new SqlParameter("@nextProjectNumber", SqlDbType.Int)
            {
                Direction = ParameterDirection.Output,
                Value = 42
            };
            _dbContextMock.Setup(db => db.ExecuteStoredProcedureNonQueryOutputParamAsync("get_next_project_number", It.IsAny<SqlParameter>()))
                .Callback<string, SqlParameter>((_, p) => p.Value = param.Value)
                .Returns(Task.CompletedTask);
            // Act
            var result = await _service.GetNextAvailableProjectNumber();
            // Assert
            Assert.Equal(42, result);
        }
        [Fact]
        public async Task GetPhases_ReturnsMappedPhases()
        {
            // Arrange
            var entityNo = "123";
            var phaseDtos = new List<PhaseDto> { new PhaseDto() };
            var phaseModels = new List<PhaseModel> { new PhaseModel() };
            _dbContextMock.Setup(db => db.ExecuteStoredProcedureAsync<PhaseDto>("pm2_get_phases_new", It.IsAny<SqlParameter>()))
                .ReturnsAsync(phaseDtos);
            _mapperMock.Setup(m => m.Map<List<PhaseModel>>(phaseDtos)).Returns(phaseModels);
            // Act
            var result = await _service.GetPhases(entityNo);
            // Assert
            Assert.Equal(phaseModels, result);
        }
        [Fact]
        public async Task GetPurchases_ReturnsMappedPurchases()
        {
            // Arrange
            var entityNo = "123";
            var purchaseDtos = new List<PurchaseDto> { new PurchaseDto() };
            var purchaseModels = new List<ProjectPurchaseModel> { new ProjectPurchaseModel() };
            _dbContextMock.Setup(db => db.ExecuteStoredProcedureAsync<PurchaseDto>("Get_Purchase_Orders_By_Project", It.IsAny<SqlParameter>()))
                .ReturnsAsync(purchaseDtos);
            _mapperMock.Setup(m => m.Map<List<ProjectPurchaseModel>>(purchaseDtos)).Returns(purchaseModels);
            // Act
            var result = await _service.GetPurchases(entityNo);
            // Assert
            Assert.Equal(purchaseModels, result);
        }
        [Fact]
        public async Task GetEquipments_ReturnsMappedEquipments()
        {
            // Arrange
            var entityNo = "123";
            var equipmentDtos = new List<EquipmentDto> { new EquipmentDto() };
            var equipmentModels = new List<ProjectEquipmentModel> { new ProjectEquipmentModel() };
            _dbContextMock.Setup(db => db.ExecuteStoredProcedureAsync<EquipmentDto>("pm2_get_equipment", It.IsAny<SqlParameter>()))
                .ReturnsAsync(equipmentDtos);
            _mapperMock.Setup(m => m.Map<List<ProjectEquipmentModel>>(equipmentDtos)).Returns(equipmentModels);
            // Act
            var result = await _service.GetEquipments(entityNo);
            // Assert
            Assert.Equal(equipmentModels, result);
        }
        [Fact]
        public async Task GetEquipmentSubhires_ReturnsMappedSubhires()
        {
            // Arrange
            var entityNo = "123";
            var subhireDtos = new List<EquipmentSubhireDto> { new EquipmentSubhireDto() };
            var subhireModels = new List<ProjectEquipmentSubhireModel> { new ProjectEquipmentSubhireModel() };
            _dbContextMock.Setup(db => db.ExecuteStoredProcedureAsync<EquipmentSubhireDto>("pm2_get_equipment_subhires", It.IsAny<SqlParameter>()))
                .ReturnsAsync(subhireDtos);
            _mapperMock.Setup(m => m.Map<List<ProjectEquipmentSubhireModel>>(subhireDtos)).Returns(subhireModels);
            _dbContextMock.Setup(db => db.ExecuteStoredProcedureAsync<PhaseDto>("pm2_get_phases_new", It.IsAny<SqlParameter>()))
                .ReturnsAsync(new List<PhaseDto>());
            _dbContextMock.Setup(db => db.ExecuteStoredProcedureAsync<EquipmentDto>("pm2_get_equipment", It.IsAny<SqlParameter>()))
                .ReturnsAsync(new List<EquipmentDto>());
            // Act
            var result = await _service.GetEquipmentSubhires(entityNo);
            // Assert
            Assert.Equal(subhireModels, result);
        }
        // Additional tests for other methods would follow the same pattern
    }
}