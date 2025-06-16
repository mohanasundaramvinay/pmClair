using System.Collections.Generic;
using System.Linq;
using ClairTourTiny.Core.Models.Lookup;
using ClairTourTiny.Core.Services;
using ClairTourTiny.Infrastructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
namespace ClairTourTiny.Tests
{
    [TestClass]
    public class LookupServiceTests
    {
        private Mock<ClairTourTinyContext> _mockContext;
        private LookupService _lookupService;
        [TestInitialize]
        public void Setup()
        {
            _mockContext = new Mock<ClairTourTinyContext>();
            _lookupService = new LookupService(_mockContext.Object);
        }
        [TestMethod]
        public void GetExchangeRates_ReturnsCorrectExchangeRates()
        {
            // Arrange
            var exchangeRates = new List<ExchangeRateBook>
            {
                new ExchangeRateBook { Currency = "USD", Enddate = "2023-12-31", Ratetodollars = 1.0, Startdate = "2023-01-01" },
                new ExchangeRateBook { Currency = "EUR", Enddate = "2023-12-31", Ratetodollars = 0.9, Startdate = "2023-01-01" }
            }.AsQueryable();
            _mockContext.Setup(c => c.ExchangeRateBooks).Returns(exchangeRates);
            // Act
            var result = _lookupService.GetExchangeRates();
            // Assert
            Assert.AreEqual(2, result.Count);
            Assert.AreEqual("USD", result[0].Currency);
            Assert.AreEqual(1.0, result[0].Ratetodollars);
            Assert.AreEqual("EUR", result[1].Currency);
            Assert.AreEqual(0.9, result[1].Ratetodollars);
        }
        [TestMethod]
        public void GetExchangeRates_ReturnsEmptyList_WhenNoExchangeRates()
        {
            // Arrange
            var exchangeRates = new List<ExchangeRateBook>().AsQueryable();
            _mockContext.Setup(c => c.ExchangeRateBooks).Returns(exchangeRates);
            // Act
            var result = _lookupService.GetExchangeRates();
            // Assert
            Assert.AreEqual(0, result.Count);
        }
    }
}