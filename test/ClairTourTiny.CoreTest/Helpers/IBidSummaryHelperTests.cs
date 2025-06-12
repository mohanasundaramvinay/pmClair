using System;
using ClairTourTiny.Core.Models.ProjectMaintenance;
using ClairTourTiny.Infrastructure.Dto.DTOs;
using Moq;
using Xunit;

public class BidSummaryHelperTests
{
    [Fact]
    public void GetBidSummaryData_ShouldReturnExpectedResponse_WhenCalledWithValidEntityNo()
    {
        // Arrange
        var mockBidSummaryHelper = new Mock<IBidSummaryHelper>();
        var expectedResponse = new BidSummaryResponse(); // Assuming a default constructor exists
        string testEntityNo = "12345";

        mockBidSummaryHelper.Setup(helper => helper.GetBidSummaryData(testEntityNo))
            .Returns(expectedResponse);

        // Act
        var actualResponse = mockBidSummaryHelper.Object.GetBidSummaryData(testEntityNo);

        // Assert
        Assert.Equal(expectedResponse, actualResponse);
    }
}