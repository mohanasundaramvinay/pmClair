using System.Collections.Generic;
using System.Linq;
using ClairTourTiny.Core.Interfaces;
using ClairTourTiny.Core.Models.Lookup;
using ClairTourTiny.Core.Services;
using Moq;
using Xunit;
namespace ClairTourTiny.Tests
{
    public class LookupServiceTests
    {
        [Fact]
        public void GetExchangeRates_ReturnsCorrectExchangeRates()
        {
            // Arrange
            var mockContext = new Mock<ClairTourTinyContext>();
            var mockExchangeRates = new List<ExchangeRateBook>
            {
                new ExchangeRateBook { Currency = "USD", Enddate = DateTime.Now, Ratetodollars = 1.0m, Startdate = DateTime.Now.AddDays(-1) },
                new ExchangeRateBook { Currency = "EUR", Enddate = DateTime.Now, Ratetodollars = 0.9m, Startdate = DateTime.Now.AddDays(-1) }
            }.AsQueryable();
            var mockDbSet = new Mock<DbSet<ExchangeRateBook>>();
            mockDbSet.As<IQueryable<ExchangeRateBook>>().Setup(m => m.Provider).Returns(mockExchangeRates.Provider);
            mockDbSet.As<IQueryable<ExchangeRateBook>>().Setup(m => m.Expression).Returns(mockExchangeRates.Expression);
            mockDbSet.As<IQueryable<ExchangeRateBook>>().Setup(m => m.ElementType).Returns(mockExchangeRates.ElementType);
            mockDbSet.As<IQueryable<ExchangeRateBook>>().Setup(m => m.GetEnumerator()).Returns(mockExchangeRates.GetEnumerator());
            mockContext.Setup(c => c.ExchangeRateBooks).Returns(mockDbSet.Object);
            var service = new LookupService(mockContext.Object);
            // Act
            var result = service.GetExchangeRates();
            // Assert
            Assert.Equal(2, result.Count);
            Assert.Equal("USD", result[0].Currency);
            Assert.Equal(1.0m, result[0].Ratetodollars);
            Assert.Equal("EUR", result[1].Currency);
            Assert.Equal(0.9m, result[1].Ratetodollars);
        }
    }
}