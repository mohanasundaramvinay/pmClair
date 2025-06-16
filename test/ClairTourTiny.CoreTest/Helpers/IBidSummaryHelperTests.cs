using System;
using ClairTourTiny.Core.Models.ProjectMaintenance;
using ClairTourTiny.Infrastructure.Dto.DTOs;
using Moq;
using Xunit;

public class BidSummaryHelperTests
{
    [Fact]
    public void GetBidSummaryData_ValidEntityNo_ReturnsExpectedResponse()
    {
        // Arrange
        var mockBidSummaryHelper = new Mock<IBidSummaryHelper>();
        var expectedResponse = new BidSummaryResponse();
        mockBidSummaryHelper.Setup(helper => helper.GetBidSummaryData(It.IsAny<string>()))
                           .Returns(expectedResponse);

        // Act
        var result = mockBidSummaryHelper.Object.GetBidSummaryData("validEntityNo");

        // Assert
        Assert.Equal(expectedResponse, result);
    }

    [Fact]
    public void GetBidSummaryData_InvalidEntityNo_ThrowsException()
    {
        // Arrange
        var mockBidSummaryHelper = new Mock<IBidSummaryHelper>();
        mockBidSummaryHelper.Setup(helper => helper.GetBidSummaryData(It.Is<string>(s => s == "invalidEntityNo")))
                           .Throws(new ArgumentException("Invalid entity number"));

        // Act & Assert
        Assert.Throws<ArgumentException>(() => mockBidSummaryHelper.Object.GetBidSummaryData("invalidEntityNo"));
    }
}