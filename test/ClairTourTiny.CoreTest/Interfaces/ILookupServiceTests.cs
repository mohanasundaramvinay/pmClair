using System.Collections.Generic;
using ClairTourTiny.Core.Interfaces;
using ClairTourTiny.Core.Models.Lookup;
using Moq;
using Xunit;

namespace ClairTourTiny.Tests
{
    public class LookupServiceTests
    {
        [Fact]
        public void GetExchangeRates_ShouldReturnListOfExchangeRateModels()
        {
            // Arrange
            var mockLookupService = new Mock<ILookupService>();
            var expectedExchangeRates = new List<ExchangeRateModel>
            {
                new ExchangeRateModel(), // Assuming ExchangeRateModel has a parameterless constructor
                new ExchangeRateModel()
            };
            mockLookupService.Setup(service => service.GetExchangeRates()).Returns(expectedExchangeRates);

            // Act
            var result = mockLookupService.Object.GetExchangeRates();

            // Assert
            Assert.Equal(expectedExchangeRates, result);
        }
    }
}