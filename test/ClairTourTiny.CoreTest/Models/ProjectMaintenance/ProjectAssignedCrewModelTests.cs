using System;
using System.Collections.Generic;
using Xunit;
using ClairTourTiny.Core.Models.ProjectMaintenance;
using Moq;
public class ProjectAssignedCrewModelTests
{
    [Fact]
    public void Test_EntityNo_DefaultValue()
    {
        var model = new ProjectAssignedCrewModel();
        Assert.Equal(string.Empty, model.EntityNo);
    }
    [Fact]
    public void Test_EmpNo_DefaultValue()
    {
        var model = new ProjectAssignedCrewModel();
        Assert.Equal(string.Empty, model.EmpNo);
    }
    [Fact]
    public void Test_JobType_DefaultValue()
    {
        var model = new ProjectAssignedCrewModel();
        Assert.Equal(string.Empty, model.JobType);
    }
    [Fact]
    public void Test_StatusCode_DefaultValue()
    {
        var model = new ProjectAssignedCrewModel();
        Assert.Equal(string.Empty, model.StatusCode);
    }
    [Fact]
    public void Test_AssignedCrewOt_CanBeSet()
    {
        var model = new ProjectAssignedCrewModel();
        var mockAssignedCrewOt = new List<ProjectAssignedCrewOtModel>();
        model.AssignedCrewOt = mockAssignedCrewOt;
        Assert.Equal(mockAssignedCrewOt, model.AssignedCrewOt);
    }
    [Fact]
    public void Test_PerDiemRate_CanBeSet()
    {
        var model = new ProjectAssignedCrewModel();
        double? rate = 100.0;
        model.PerDiemRate = rate;
        Assert.Equal(rate, model.PerDiemRate);
    }
    // Additional tests for other properties can be added similarly
}