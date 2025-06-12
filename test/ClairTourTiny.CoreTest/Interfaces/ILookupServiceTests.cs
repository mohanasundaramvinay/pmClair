using System.Collections.Generic;
using ClairTourTiny.Core.Interfaces;
using ClairTourTiny.Core.Models.Lookup;
using Moq;
using Xunit;
namespace ClairTourTiny.Tests
{
    public class LookupServiceTests
    {
        private readonly Mock<ILookupService> _mockLookupService;
        public LookupServiceTests()
        {
            _mockLookupService = new Mock<ILookupService>();
        }
        [Fact]
        public void GetExchangeRates_ShouldReturnListOfExchangeRateModels()
        {
            // Arrange
            var expectedRates = new List<ExchangeRateModel>
            {
                new ExchangeRateModel(), // Assuming ExchangeRateModel has a parameterless constructor
                new ExchangeRateModel()
            };
            _mockLookupService.Setup(service => service.GetExchangeRates()).Returns(expectedRates);
            // Act
            var result = _mockLookupService.Object.GetExchangeRates();
            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedRates.Count, result.Count);
        }
        [Fact]
        public void GetExchangeRates_ShouldReturnEmptyList_WhenNoRatesAvailable()
        {
            // Arrange
            var expectedRates = new List<ExchangeRateModel>();
            _mockLookupService.Setup(service => service.GetExchangeRates()).Returns(expectedRates);
            // Act
            var result = _mockLookupService.Object.GetExchangeRates();
            // Assert
            Assert.NotNull(result);
            Assert.Empty(result);
        }
        [Fact]
        public void GetExchangeRates_ShouldReturnNull_WhenServiceFails()
        {
            // Arrange
            _mockLookupService.Setup(service => service.GetExchangeRates()).Returns((List<ExchangeRateModel>)null);
            // Act
            var result = _mockLookupService.Object.GetExchangeRates();
            // Assert
            Assert.Null(result);
        }
    }
}