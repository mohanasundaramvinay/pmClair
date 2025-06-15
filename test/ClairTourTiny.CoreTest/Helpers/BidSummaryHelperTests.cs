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
    private List<ExpenseCode> _expenseCode;
    private List<JobType> _jobTypes;
    private List<PropertyTypeDTO> _propertyTypes;
    private BidSummaryHelper _bidSummaryHelper;
    public BidSummaryHelperTests()
    {
        _mockDbContext = new Mock<ClairTourTinyContext>();
        _phases = new List<PhaseModel>();
        _billingItems = new List<ProjectBillingItemModel>();
        _billingPeriods = new List<ProjectBillingPeriodModel>();
        _billingPeriodItems = new List<ProjectBillingPeriodItemModel>();
        _bidExpenses = new List<ProjectBidExpenseModel>();
        _crews = new List<ProjectCrewModel>();
        _expenseCode = new List<ExpenseCode>();
        _jobTypes = new List<JobType>();
        _propertyTypes = new List<PropertyTypeDTO>();
        _bidSummaryHelper = new BidSummaryHelper(_phases, _billingItems, _billingPeriods, _billingPeriodItems, _bidExpenses, _crews, _expenseCode, _jobTypes, _propertyTypes, _mockDbContext.Object);
    }
    [Fact]
    public void GetBidSummaryData_ShouldReturnDefaultResponse_WhenEntityNoDoesNotMatch()
    {
        // Arrange
        string entityNo = "NonExistentEntity";
        // Act
        var result = _bidSummaryHelper.GetBidSummaryData(entityNo);
        // Assert
        Assert.NotNull(result);
        Assert.Equal(0, result.WeeklyTotal);
        Assert.Equal(0, result.GrandTotal);
    }
    [Fact]
    public void GetBidSummaryData_ShouldCalculateCorrectTotals_WhenValidEntityNoProvided()
    {
        // Arrange
        string entityNo = "ValidEntity";
        _phases.Add(new PhaseModel { EntityNo = entityNo, PropType = "Type1", BidMarkup = 0.1 });
        _propertyTypes.Add(new PropertyTypeDTO { PropType = "Type1", BidFactor = 1.2 });
        // Act
        var result = _bidSummaryHelper.GetBidSummaryData(entityNo);
        // Assert
        Assert.NotNull(result);
        Assert.True(result.WeeklyTotal > 0);
        Assert.True(result.GrandTotal > 0);
    }
    // Additional tests for edge cases and other methods can be added here
}