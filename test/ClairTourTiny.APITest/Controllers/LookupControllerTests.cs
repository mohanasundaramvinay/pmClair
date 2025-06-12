using ClairTourTiny.Core.Interfaces;
using ClairTourTiny.Core.Models.Lookup;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Moq;
using Xunit;
using System.Collections.Generic;
namespace ClairTourTiny.API.Tests.Controllers
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
                new ExchangeRateModel { Currency = "USD", Rate = 1.0 },
                new ExchangeRateModel { Currency = "EUR", Rate = 0.9 }
            };
            _mockService.Setup(service => service.GetExchangeRates()).Returns(exchangeRates);
            // Act
            var result = _controller.GetExchangeRates();
            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<List<ExchangeRateModel>>(okResult.Value);
            Assert.Equal(2, returnValue.Count);
        }
        [Fact]
        public void GetExchangeRates_ReturnsInternalServerError_WhenExceptionThrown()
        {
            // Arrange
            _mockService.Setup(service => service.GetExchangeRates()).Throws(new System.Exception());
            // Act
            var result = _controller.GetExchangeRates();
            // Assert
            Assert.IsType<ObjectResult>(result);
            var objectResult = result as ObjectResult;
            Assert.Equal(StatusCodes.Status500InternalServerError, objectResult.StatusCode);
        }
    }
}