using System.Collections.Generic;
using NUnit.Framework;
using Moq;
using ClairTourTiny.Infrastructure.Models.ProjectMaintenance;
using ClairTourTiny.Core.Models.ProjectMaintenance.Save;
// Assuming other necessary using directives for the types used in the lists
namespace ClairTourTiny.Tests
{
    [TestFixture]
    public class ProjectSaveModelTests
    {
        private ProjectSaveModel _projectSaveModel;
        
        [SetUp]
        public void Setup()
        {
            _projectSaveModel = new ProjectSaveModel();
        }
        
        [Test]
        public void Projects_ShouldInitializeAsEmptyList()
        {
            Assert.IsNotNull(_projectSaveModel.Projects);
            Assert.IsEmpty(_projectSaveModel.Projects);
        }
        
        [Test]
        public void Equipment_ShouldInitializeAsEmptyList()
        {
            Assert.IsNotNull(_projectSaveModel.Equipment);
            Assert.IsEmpty(_projectSaveModel.Equipment);
        }
        
        [Test]
        public void Crew_ShouldInitializeAsEmptyList()
        {
            Assert.IsNotNull(_projectSaveModel.Crew);
            Assert.IsEmpty(_projectSaveModel.Crew);
        }
        
        [Test]
        public void AssignedCrew_ShouldInitializeAsEmptyList()
        {
            Assert.IsNotNull(_projectSaveModel.AssignedCrew);
            Assert.IsEmpty(_projectSaveModel.AssignedCrew);
        }
        
        [Test]
        public void RFIs_ShouldInitializeAsEmptyList()
        {
            Assert.IsNotNull(_projectSaveModel.RFIs);
            Assert.IsEmpty(_projectSaveModel.RFIs);
        }
        
        [Test]
        public void BidExpenses_ShouldInitializeAsEmptyList()
        {
            Assert.IsNotNull(_projectSaveModel.BidExpenses);
            Assert.IsEmpty(_projectSaveModel.BidExpenses);
        }
        
        [Test]
        public void BidRevenue_ShouldInitializeAsEmptyList()
        {
            Assert.IsNotNull(_projectSaveModel.BidRevenue);
            Assert.IsEmpty(_projectSaveModel.BidRevenue);
        }
        
        [Test]
        public void ProjectNotes_ShouldInitializeAsEmptyList()
        {
            Assert.IsNotNull(_projectSaveModel.ProjectNotes);
            Assert.IsEmpty(_projectSaveModel.ProjectNotes);
        }
        
        [Test]
        public void ProjectBillingPeriods_ShouldInitializeAsEmptyList()
        {
            Assert.IsNotNull(_projectSaveModel.ProjectBillingPeriods);
            Assert.IsEmpty(_projectSaveModel.ProjectBillingPeriods);
        }
        
        [Test]
        public void ProjectClientContacts_ShouldInitializeAsEmptyList()
        {
            Assert.IsNotNull(_projectSaveModel.ProjectClientContacts);
            Assert.IsEmpty(_projectSaveModel.ProjectClientContacts);
        }
        
        [Test]
        public void ProjectEmployeeOvertimeRates_ShouldInitializeAsEmptyList()
        {
            Assert.IsNotNull(_projectSaveModel.ProjectEmployeeOvertimeRates);
            Assert.IsEmpty(_projectSaveModel.ProjectEmployeeOvertimeRates);
        }
        
        [Test]
        public void ProjectProductionSchedule_ShouldInitializeAsEmptyList()
        {
            Assert.IsNotNull(_projectSaveModel.ProjectProductionSchedule);
            Assert.IsEmpty(_projectSaveModel.ProjectProductionSchedule);
        }
        
        [Test]
        public void ProjectBillingPeriodItems_ShouldInitializeAsEmptyList()
        {
            Assert.IsNotNull(_projectSaveModel.ProjectBillingPeriodItems);
            Assert.IsEmpty(_projectSaveModel.ProjectBillingPeriodItems);
        }
        
        [Test]
        public void ProjectBillingItems_ShouldInitializeAsEmptyList()
        {
            Assert.IsNotNull(_projectSaveModel.ProjectBillingItems);
            Assert.IsEmpty(_projectSaveModel.ProjectBillingItems);
        }
        
        [Test]
        public void FavoriteProjects_ShouldInitializeAsEmptyList()
        {
            Assert.IsNotNull(_projectSaveModel.FavoriteProjects);
            Assert.IsEmpty(_projectSaveModel.FavoriteProjects);
        }
        
        [Test]
        public void EquipmentSubhires_ShouldInitializeAsEmptyList()
        {
            Assert.IsNotNull(_projectSaveModel.EquipmentSubhires);
            Assert.IsEmpty(_projectSaveModel.EquipmentSubhires);
        }
        
        // Additional tests can be added to check adding items to each list and verifying the count
    }
}