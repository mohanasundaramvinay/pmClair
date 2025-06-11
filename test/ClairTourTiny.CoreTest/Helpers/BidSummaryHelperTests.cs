using System;
using System.Collections.Generic;
using System.Linq;
using Moq;
using Xunit;
using ClairTourTiny.Core.Models.ProjectMaintenance;
using ClairTourTiny.Infrastructure;
using ClairTourTiny.Infrastructure.Dto.DTOs;
public class BidSummaryHelperTests
{
    private Mock<ClairTourTinyContext> _mockDbContext;
    private List<PhaseModel> _phases;
    private List<ProjectBillingItemModel> _billingItems;
    private List<ProjectBillingPeriodModel> _billingPeriods;
    private List<ProjectBillingPeriodItemModel> _billingPeriodItems;
    private List<ProjectBidExpenseModel> _bidExpenses;
    private List<ProjectCrewModel> _crews;
    private List<ExpenseCode> _expenseCodes;
    private List<JobType> _jobTypes;
    private List<PropertyTypeDTO> _propertyTypes;
    public BidSummaryHelperTests()
    {
        _mockDbContext = new Mock<ClairTourTinyContext>();
        _phases = new List<PhaseModel>();
        _billingItems = new List<ProjectBillingItemModel>();
        _billingPeriods = new List<ProjectBillingPeriodModel>();
        _billingPeriodItems = new List<ProjectBillingPeriodItemModel>();
        _bidExpenses = new List<ProjectBidExpenseModel>();
        _crews = new List<ProjectCrewModel>();
        _expenseCodes = new List<ExpenseCode>();
        _jobTypes = new List<JobType>();
        _propertyTypes = new List<PropertyTypeDTO>();
    }
    [Fact]
    public void GetBidSummaryData_ValidEntityNo_ReturnsCorrectResponse()
    {
        // Arrange
        var entityNo = "123";
        var phase = new PhaseModel { EntityNo = entityNo, PropType = "Type1", BidMarkup = 0.1 };
        _phases.Add(phase);
        var propertyType = new PropertyTypeDTO { PropType = "Type1", BidFactor = 0.2, BidValueType = "Dry Hire" };
        _propertyTypes.Add(propertyType);
        var helper = new BidSummaryHelper(_phases, _billingItems, _billingPeriods, _billingPeriodItems, _bidExpenses, _crews, _expenseCodes, _jobTypes, _propertyTypes, _mockDbContext.Object);
        // Act
        var response = helper.GetBidSummaryData(entityNo);
        // Assert
        Assert.NotNull(response);
        Assert.Equal(0.2, response.DefaultMarkupPercentage);
        Assert.Equal(0.1 * 100, response.OverrideMarkupPercentage);
    }
    [Fact]
    public void GetBidSummaryData_InvalidEntityNo_ReturnsEmptyResponse()
    {
        // Arrange
        var entityNo = "999";
        var helper = new BidSummaryHelper(_phases, _billingItems, _billingPeriods, _billingPeriodItems, _bidExpenses, _crews, _expenseCodes, _jobTypes, _propertyTypes, _mockDbContext.Object);
        // Act
        var response = helper.GetBidSummaryData(entityNo);
        // Assert
        Assert.NotNull(response);
        Assert.Equal(0, response.DefaultMarkupPercentage);
        Assert.Equal(0, response.OverrideMarkupPercentage);
    }
    // Additional tests for other scenarios and methods can be added here
}