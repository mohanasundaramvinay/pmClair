using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Moq;
using Xunit;
using ClairTourTiny.API.Controllers;
using ClairTourTiny.Core.Models.Authentication;
using ClairTourTiny.Core.Services;
using ClairTourTiny.Infrastructure;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
namespace ClairTourTiny.Tests
{
    public class AuthControllerTests
    {
        private readonly Mock<IAuthService> _mockAuthService;
        private readonly Mock<IConnectionStringCache> _mockConnectionStringCache;
        private readonly Mock<IConfiguration> _mockConfiguration;
        private readonly AuthController _authController;
        
        public AuthControllerTests()
        {
            _mockAuthService = new Mock<IAuthService>();
            _mockConnectionStringCache = new Mock<IConnectionStringCache>();
            _mockConfiguration = new Mock<IConfiguration>();
            _authController = new AuthController(_mockAuthService.Object, _mockConnectionStringCache.Object, _mockConfiguration.Object);
        }
        
        [Fact]
        public async Task Login_ReturnsOk_WhenCredentialsAreValid()
        {
            // Arrange
            var request = new LoginRequest { Username = "user", Password = "pass", Database = "db" };
            _mockConfiguration.Setup(c => c["Database:Server"]).Returns("localhost");
            _mockAuthService.Setup(s => s.GenerateJwtToken(It.IsAny<string>())).Returns("token");
            
            // Act
            var result = await _authController.Login(request);
            
            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(StatusCodes.Status200OK, okResult.StatusCode);
        }
        
        [Fact]
        public async Task Login_ReturnsBadRequest_WhenFieldsAreMissing()
        {
            // Arrange
            var request = new LoginRequest { Username = "", Password = "", Database = "" };
            
            // Act
            var result = await _authController.Login(request);
            
            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal(StatusCodes.Status400BadRequest, badRequestResult.StatusCode);
        }
        
        [Fact]
        public async Task Login_ReturnsUnauthorized_WhenCredentialsAreInvalid()
        {
            // Arrange
            var request = new LoginRequest { Username = "user", Password = "wrongpass", Database = "db" };
            _mockConfiguration.Setup(c => c["Database:Server"]).Returns("localhost");
            
            // Simulate SqlException
            _mockAuthService.Setup(s => s.GenerateJwtToken(It.IsAny<string>())).Throws(new SqlException());
            
            // Act
            var result = await _authController.Login(request);
            
            // Assert
            var unauthorizedResult = Assert.IsType<UnauthorizedObjectResult>(result);
            Assert.Equal(StatusCodes.Status401Unauthorized, unauthorizedResult.StatusCode);
        }
        
        [Fact]
        public async Task Login_ReturnsServerError_WhenExceptionOccurs()
        {
            // Arrange
            var request = new LoginRequest { Username = "user", Password = "pass", Database = "db" };
            _mockConfiguration.Setup(c => c["Database:Server"]).Returns("localhost");
            
            // Simulate general exception
            _mockAuthService.Setup(s => s.GenerateJwtToken(It.IsAny<string>())).Throws(new Exception());
            
            // Act
            var result = await _authController.Login(request);
            
            // Assert
            var statusCodeResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(StatusCodes.Status500InternalServerError, statusCodeResult.StatusCode);
        }
        
        [Fact]
        public async Task Test_ReturnsOk_WhenDatabaseConnectionIsSuccessful()
        {
            // Arrange
            var mockDbContext = new Mock<ClairTourTinyContext>();
            mockDbContext.Setup(db => db.Database.CanConnectAsync()).ReturnsAsync(true);
            
            // Act
            var result = await _authController.Test(mockDbContext.Object);
            
            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(StatusCodes.Status200OK, okResult.StatusCode);
        }
        
        [Fact]
        public async Task Test_ReturnsServerError_WhenDatabaseConnectionFails()
        {
            // Arrange
            var mockDbContext = new Mock<ClairTourTinyContext>();
            mockDbContext.Setup(db => db.Database.CanConnectAsync()).ReturnsAsync(false);
            
            // Act
            var result = await _authController.Test(mockDbContext.Object);
            
            // Assert
            var statusCodeResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(StatusCodes.Status500InternalServerError, statusCodeResult.StatusCode);
        }
    }
}