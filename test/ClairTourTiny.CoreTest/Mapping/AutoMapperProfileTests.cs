using AutoMapper;
using Xunit;
using ClairTourTiny.Core.Mapping;
using ClairTourTiny.Core.Models.ProjectMaintenance;
using ClairTourTiny.Core.Models.ProjectMaintenance.Save;
using ClairTourTiny.Core.Models.Projects;
using ClairTourTiny.Infrastructure.Dto.ProjectMaintenance;
using ClairTourTiny.Infrastructure.Dto.Projects;
using ClairTourTiny.Infrastructure.Models;
namespace ClairTourTiny.Tests
{
    public class AutoMapperProfileTests
    {
        private readonly IMapper _mapper;
        public AutoMapperProfileTests()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<AutoMapperProfile>();
            });
            _mapper = config.CreateMapper();
        }
        [Fact]
        public void ProjectFavouriteDto_To_Project_Mapping_IsValid()
        {
            var source = new ProjectFavouriteDto();
            var destination = _mapper.Map<Models.Projects.Project>(source);
            Assert.NotNull(destination);
        }
        [Fact]
        public void ProjectRecentDto_To_Project_Mapping_IsValid()
        {
            var source = new ProjectRecentDto { DisplayOrder = 1, GroupDisplayOrder = 2 };
            var destination = _mapper.Map<Models.Projects.Project>(source);
            Assert.Equal("1", destination.DisplayOrder);
            Assert.Equal("2", destination.GroupDisplayOrder);
        }
        [Fact]
        public void ProjectSearchDto_To_Project_Mapping_IsValid()
        {
            var source = new ProjectSearchDto();
            var destination = _mapper.Map<Models.Projects.Project>(source);
            Assert.NotNull(destination);
        }
        [Fact]
        public void PhaseDto_To_PhaseModel_Mapping_IsValid()
        {
            var source = new PhaseDto();
            var destination = _mapper.Map<PhaseModel>(source);
            Assert.NotNull(destination);
        }
        [Fact]
        public void ProjectModel_To_Pm2Project_Mapping_IsValid()
        {
            var source = new Models.ProjectMaintenance.Save.ProjectModel();
            var destination = _mapper.Map<Pm2Project>(source);
            Assert.Equal(1, destination.SessionId);
        }
        [Fact]
        public void Equipment_To_Pm2Equipment_Mapping_IsValid()
        {
            var source = new Equipment();
            var destination = _mapper.Map<Pm2Equipment>(source);
            Assert.Equal(1, destination.SessionId);
        }
        [Fact]
        public void Equipment_To_Pm2Equipment_QuantityToSubhire_Mapping_IsValid()
        {
            // Arrange
            var source = new Equipment
            {
                QuantityToSubhire = 5.5,
                Entityno = "TEST-001",
                PartnoNew = "PART123"
            };

            // Act
            var destination = _mapper.Map<Pm2Equipment>(source);

            // Assert
            Assert.Equal(1, destination.SessionId);
            Assert.Equal(5.5, destination.QuantityToSubhire);
            Assert.Equal("TEST-001", destination.Entityno);
            Assert.Equal("PART123", destination.PartnoNew);
        }
        [Fact]
        public void Crew_To_Pm2Crew_Mapping_IsValid()
        {
            var source = new Crew();
            var destination = _mapper.Map<Pm2Crew>(source);
            Assert.Equal(1, destination.SessionId);
        }
        [Fact]
        public void AssignedCrew_To_Pm2AssignedCrew_Mapping_IsValid()
        {
            var source = new AssignedCrew();
            var destination = _mapper.Map<Pm2AssignedCrew>(source);
            Assert.Equal(1, destination.SessionId);
        }
        [Fact]
        public void RfiModel_To_Pm2Rfi_Mapping_IsValid()
        {
            var source = new RfiModel();
            var destination = _mapper.Map<Pm2Rfi>(source);
            Assert.Equal(1, destination.SessionId);
        }
        [Fact]
        public void BidExpense_To_Pm2BidExpense_Mapping_IsValid()
        {
            var source = new BidExpense();
            var destination = _mapper.Map<Pm2BidExpense>(source);
            Assert.Equal(1, destination.SessionId);
        }
        [Fact]
        public void BidRevenue_To_Pm2BidRevenue_Mapping_IsValid()
        {
            var source = new BidRevenue();
            var destination = _mapper.Map<Pm2BidRevenue>(source);
            Assert.Equal(1, destination.SessionId);
        }
        [Fact]
        public void ProjectNote_To_Pm2ProjectNote_Mapping_IsValid()
        {
            var source = new ProjectNote();
            var destination = _mapper.Map<Pm2ProjectNote>(source);
            Assert.Equal(1, destination.SessionId);
        }
        [Fact]
        public void ProjectBillingPeriod_To_Pm2ProjectBillingPeriod_Mapping_IsValid()
        {
            var source = new Models.ProjectMaintenance.Save.ProjectBillingPeriod();
            var destination = _mapper.Map<Pm2ProjectBillingPeriod>(source);
            Assert.Equal(1, destination.SessionId);
        }
        [Fact]
        public void ProjectClientContactModel_To_Pm2ProjectClientContact_Mapping_IsValid()
        {
            var source = new ProjectClientContactModel();
            var destination = _mapper.Map<Pm2ProjectClientContact>(source);
            Assert.Equal(1, destination.SessionId);
        }
        [Fact]
        public void ProjectEmployeeOvertimeRate_To_Pm2ProjectEmployeeOvertimeRate_Mapping_IsValid()
        {
            var source = new Models.ProjectMaintenance.Save.ProjectEmployeeOvertimeRate();
            var destination = _mapper.Map<Pm2ProjectEmployeeOvertimeRate>(source);
            Assert.Equal(1, destination.SessionId);
        }
        [Fact]
        public void ProjectBillingPeriodItem_To_Pm2ProjectBillingPeriodItem_Mapping_IsValid()
        {
            var source = new Models.ProjectMaintenance.Save.ProjectBillingPeriodItem();
            var destination = _mapper.Map<Pm2ProjectBillingPeriodItem>(source);
            Assert.Equal(1, destination.SessionId);
        }
        [Fact]
        public void ProjectProductionScheduleModel_To_Pm2ProjectProductionSchedule_Mapping_IsValid()
        {
            var source = new ProjectProductionScheduleModel();
            var destination = _mapper.Map<Pm2ProjectProductionSchedule>(source);
            Assert.Equal(1, destination.SessionId);
        }
        [Fact]
        public void ProjectBillingItemModel_To_Pm2ProjectBillingItem_Mapping_IsValid()
        {
            var source = new ProjectBillingItemModel();
            var destination = _mapper.Map<Pm2ProjectBillingItem>(source);
            Assert.Equal(1, destination.SessionId);
        }
        [Fact]
        public void FavoriteProject_To_Pm2FavoriteProjects_Mapping_IsValid()
        {
            var source = new FavoriteProject();
            var destination = _mapper.Map<Pm2FavoriteProjects>(source);
            Assert.Equal(1, destination.SessionId);
        }
        [Fact]
        public void ProjectEquipmentSubhireModel_To_Pm2EquipmentSubhire_Mapping_IsValid()
        {
            var source = new ProjectEquipmentSubhireModel();
            var destination = _mapper.Map<Pm2EquipmentSubhire>(source);
            Assert.Equal(1, destination.SessionId);
        }
        [Fact]
        public void EquipmentDto_To_ProjectEquipmentModel_Mapping_IsValid()
        {
            var source = new EquipmentDto();
            var destination = _mapper.Map<ProjectEquipmentModel>(source);
            Assert.NotNull(destination);
        }
        [Fact]
        public void EquipmentSubhireDto_To_ProjectEquipmentSubhireModel_Mapping_IsValid()
        {
            var source = new EquipmentSubhireDto();
            var destination = _mapper.Map<ProjectEquipmentSubhireModel>(source);
            Assert.NotNull(destination);
        }
        [Fact]
        public void PurchaseDto_To_ProjectPurchaseModel_Mapping_IsValid()
        {
            var source = new PurchaseDto();
            var destination = _mapper.Map<ProjectPurchaseModel>(source);
            Assert.NotNull(destination);
        }
        [Fact]
        public void ShipmentDto_To_ProjectShipmentModel_Mapping_IsValid()
        {
            var source = new ShipmentDto();
            var destination = _mapper.Map<ProjectShipmentModel>(source);
            Assert.NotNull(destination);
        }
        [Fact]
        public void BidExpenseDto_To_ProjectBidExpenseModel_Mapping_IsValid()
        {
            var source = new BidExpenseDto { ItemCost = 10, Quantity = 2 };
            var destination = _mapper.Map<ProjectBidExpenseModel>(source);
            Assert.Equal(20, destination.Cost);
        }
        [Fact]
        public void RfiDto_To_ProjectRfiModel_Mapping_IsValid()
        {
            var source = new RfiDto();
            var destination = _mapper.Map<ProjectRfiModel>(source);
            Assert.NotNull(destination);
        }
        [Fact]
        public void NoteDto_To_ProjectNoteModel_Mapping_IsValid()
        {
            var source = new NoteDto();
            var destination = _mapper.Map<ProjectNoteModel>(source);
            Assert.NotNull(destination);
        }
        [Fact]
        public void AssignedCrewOtDto_To_ProjectAssignedCrewOtModel_Mapping_IsValid()
        {
            var source = new AssignedCrewOtDto();
            var destination = _mapper.Map<ProjectAssignedCrewOtModel>(source);
            Assert.NotNull(destination);
        }
        [Fact]
        public void BillingItemDto_To_ProjectBillingItemModel_Mapping_IsValid()
        {
            var source = new BillingItemDto();
            var destination = _mapper.Map<ProjectBillingItemModel>(source);
            Assert.NotNull(destination);
        }
        [Fact]
        public void PartBidValueDto_To_ProjectPartBidValueModel_Mapping_IsValid()
        {
            var source = new PartBidValueDto();
            var destination = _mapper.Map<ProjectPartBidValueModel>(source);
            Assert.NotNull(destination);
        }
        [Fact]
        public void ProductionScheduleDto_To_ProjectProductionScheduleModel_Mapping_IsValid()
        {
            var source = new ProductionScheduleDto();
            var destination = _mapper.Map<ProjectProductionScheduleModel>(source);
            Assert.NotNull(destination);
        }
        [Fact]
        public void AssignedCrewDto_To_ProjectAssignedCrewModel_Mapping_IsValid()
        {
            var source = new AssignedCrewDto();
            var destination = _mapper.Map<ProjectAssignedCrewModel>(source);
            Assert.NotNull(destination);
        }
        [Fact]
        public void CrewDto_To_ProjectCrewModel_Mapping_IsValid()
        {
            var source = new CrewDto();
            var destination = _mapper.Map<ProjectCrewModel>(source);
            Assert.NotNull(destination);
        }
        [Fact]
        public void BillingPeriodDto_To_ProjectBillingPeriodModel_Mapping_IsValid()
        {
            var source = new BillingPeriodDto();
            var destination = _mapper.Map<ProjectBillingPeriodModel>(source);
            Assert.NotNull(destination);
        }
        [Fact]
        public void BillingPeriodItemDto_To_ProjectBillingPeriodItemModel_Mapping_IsValid()
        {
            var source = new BillingPeriodItemDto();
            var destination = _mapper.Map<ProjectBillingPeriodItemModel>(source);
            Assert.NotNull(destination);
        }
        [Fact]
        public void ClientShippingAddressDto_To_ProjectClientShippingAddressModel_Mapping_IsValid()
        {
            var source = new ClientShippingAddressDto();
            var destination = _mapper.Map<ProjectClientShippingAddressModel>(source);
            Assert.NotNull(destination);
        }
        [Fact]
        public void PartDto_To_ProjectPartModel_Mapping_IsValid()
        {
            var source = new PartDto();
            var destination = _mapper.Map<ProjectPartModel>(source);
            Assert.NotNull(destination);
        }
        [Fact]
        public void ClientContactDto_To_ProjectClientContactModel_Mapping_IsValid()
        {
            var source = new ClientContactDto();
            var destination = _mapper.Map<ProjectClientContactModel>(source);
            Assert.NotNull(destination);
        }
        [Fact]
        public void ClientAddressDto_To_ProjectClientAddressModel_Mapping_IsValid()
        {
            var source = new ClientAddressDto();
            var destination = _mapper.Map<ProjectClientAddressModel>(source);
            Assert.NotNull(destination);
        }
    }
}