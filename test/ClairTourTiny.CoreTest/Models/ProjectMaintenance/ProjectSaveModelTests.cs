using System.Collections.Generic;
using Xunit;
using ClairTourTiny.Infrastructure.Models.ProjectMaintenance;
using ClairTourTiny.Core.Models.ProjectMaintenance.Save;
public class ProjectSaveModelTests
{
    [Fact]
    public void Projects_Should_Be_Initialized_As_Empty_List()
    {
        var model = new ProjectSaveModel();
        Assert.NotNull(model.Projects);
        Assert.Empty(model.Projects);
    }
    [Fact]
    public void Equipment_Should_Be_Initialized_As_Empty_List()
    {
        var model = new ProjectSaveModel();
        Assert.NotNull(model.Equipment);
        Assert.Empty(model.Equipment);
    }
    [Fact]
    public void Crew_Should_Be_Initialized_As_Empty_List()
    {
        var model = new ProjectSaveModel();
        Assert.NotNull(model.Crew);
        Assert.Empty(model.Crew);
    }
    [Fact]
    public void AssignedCrew_Should_Be_Initialized_As_Empty_List()
    {
        var model = new ProjectSaveModel();
        Assert.NotNull(model.AssignedCrew);
        Assert.Empty(model.AssignedCrew);
    }
    [Fact]
    public void RFIs_Should_Be_Initialized_As_Empty_List()
    {
        var model = new ProjectSaveModel();
        Assert.NotNull(model.RFIs);
        Assert.Empty(model.RFIs);
    }
    [Fact]
    public void BidExpenses_Should_Be_Initialized_As_Empty_List()
    {
        var model = new ProjectSaveModel();
        Assert.NotNull(model.BidExpenses);
        Assert.Empty(model.BidExpenses);
    }
    [Fact]
    public void BidRevenue_Should_Be_Initialized_As_Empty_List()
    {
        var model = new ProjectSaveModel();
        Assert.NotNull(model.BidRevenue);
        Assert.Empty(model.BidRevenue);
    }
    [Fact]
    public void ProjectNotes_Should_Be_Initialized_As_Empty_List()
    {
        var model = new ProjectSaveModel();
        Assert.NotNull(model.ProjectNotes);
        Assert.Empty(model.ProjectNotes);
    }
    [Fact]
    public void ProjectBillingPeriods_Should_Be_Initialized_As_Empty_List()
    {
        var model = new ProjectSaveModel();
        Assert.NotNull(model.ProjectBillingPeriods);
        Assert.Empty(model.ProjectBillingPeriods);
    }
    [Fact]
    public void ProjectClientContacts_Should_Be_Initialized_As_Empty_List()
    {
        var model = new ProjectSaveModel();
        Assert.NotNull(model.ProjectClientContacts);
        Assert.Empty(model.ProjectClientContacts);
    }
    [Fact]
    public void ProjectEmployeeOvertimeRates_Should_Be_Initialized_As_Empty_List()
    {
        var model = new ProjectSaveModel();
        Assert.NotNull(model.ProjectEmployeeOvertimeRates);
        Assert.Empty(model.ProjectEmployeeOvertimeRates);
    }
    [Fact]
    public void ProjectProductionSchedule_Should_Be_Initialized_As_Empty_List()
    {
        var model = new ProjectSaveModel();
        Assert.NotNull(model.ProjectProductionSchedule);
        Assert.Empty(model.ProjectProductionSchedule);
    }
    [Fact]
    public void ProjectBillingPeriodItems_Should_Be_Initialized_As_Empty_List()
    {
        var model = new ProjectSaveModel();
        Assert.NotNull(model.ProjectBillingPeriodItems);
        Assert.Empty(model.ProjectBillingPeriodItems);
    }
    [Fact]
    public void ProjectBillingItems_Should_Be_Initialized_As_Empty_List()
    {
        var model = new ProjectSaveModel();
        Assert.NotNull(model.ProjectBillingItems);
        Assert.Empty(model.ProjectBillingItems);
    }
    [Fact]
    public void FavoriteProjects_Should_Be_Initialized_As_Empty_List()
    {
        var model = new ProjectSaveModel();
        Assert.NotNull(model.FavoriteProjects);
        Assert.Empty(model.FavoriteProjects);
    }
    [Fact]
    public void EquipmentSubhires_Should_Be_Initialized_As_Empty_List()
    {
        var model = new ProjectSaveModel();
        Assert.NotNull(model.EquipmentSubhires);
        Assert.Empty(model.EquipmentSubhires);
    }
}