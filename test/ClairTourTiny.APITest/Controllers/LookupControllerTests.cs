using ClairTourTiny.Core.Interfaces;
using ClairTourTiny.Core.Models.Lookup;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace ClairTourTiny.API.Tests
{
    public class LookupControllerTests
    {
        private readonly Mock<ILookupService> _mockService;
        private readonly LookupController _controller;

        public LookupControllerTests()
        {
            _mockService = new Mock<ILookupService>();
            _controller = new LookupController(_mockService.Object);
        }

        [Fact]
        public void GetExchangeRates_ReturnsOkResult_WithListOfExchangeRates()
        {
            // Arrange
            var exchangeRates = new List<ExchangeRateModel>
            {
                new ExchangeRateModel { /* Initialize properties */ },
                new ExchangeRateModel { /* Initialize properties */ }
            };
            _mockService.Setup(service => service.GetExchangeRates()).Returns(exchangeRates);

            // Act
            var result = _controller.GetExchangeRates();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<List<ExchangeRateModel>>(okResult.Value);
            Assert.Equal(exchangeRates.Count, returnValue.Count);
        }

        [Fact]
        public void GetExchangeRates_ReturnsInternalServerError_OnException()
        {
            // Arrange
            _mockService.Setup(service => service.GetExchangeRates()).Throws(new System.Exception());

            // Act
            var result = _controller.GetExchangeRates();

            // Assert
            var statusCodeResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(StatusCodes.Status500InternalServerError, statusCodeResult.StatusCode);
        }
    }
}