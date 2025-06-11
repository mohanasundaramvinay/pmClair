using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ClairTourTiny.Core.Models.Authentication;
using ClairTourTiny.Core.Services;
using ClairTourTiny.Infrastructure;

namespace ClairTourTiny.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IConnectionStringCache _connectionStringCache;
        private readonly IConfiguration _configuration;

        public AuthController(
            IAuthService authService, 
            IConnectionStringCache connectionStringCache,
            IConfiguration configuration)
        {
            _authService = authService;
            _connectionStringCache = connectionStringCache;
            _configuration = configuration;
        }

        /// <summary>
        /// Authenticates a user and returns a JWT token
        /// </summary>
        [HttpPost("login")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(object), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            if (string.IsNullOrEmpty(request.Username) || 
                string.IsNullOrEmpty(request.Password) || 
                string.IsNullOrEmpty(request.Database))
            {
                return BadRequest("Username, password, and database are required");
            }

            try
            {
                // Build connection string
                var connectionString = $"Server={_configuration["Database:Server"]};" +
                                    $"Database={request.Database};" +
                                    $"User Id={request.Username};" +
                                    $"Password={request.Password};" +
                                    "TrustServerCertificate=True;";

                // Test the connection and get current user
                using (var connection = new SqlConnection(connectionString))
                {
                    await connection.OpenAsync();                    
                               
                    // If we get here, the connection was successful
                    // Cache the connection string
                    _connectionStringCache.SetConnectionString(request.Username, connectionString);

                    // Generate JWT token
                    var token = _authService.GenerateJwtToken(request.Username);

                    return Ok(new { Token = token });
                }
            }
            catch (SqlException ex)
            {
                return Unauthorized(new { Message = "Invalid credentials or database access denied" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An error occurred during login" });
            }
        }

        /// <summary>
        /// Tests the authentication and database connection
        /// </summary>
        [HttpGet("test")]
        [Authorize]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Test([FromServices] ClairTourTinyContext dbContext)
        {
            try
            {
                // Test database connection using the scoped DbContext
                var canConnect = await dbContext.Database.CanConnectAsync();
                if (!canConnect)
                {
                    return StatusCode(500, "Database connection failed");
                }
               
                return Ok("Authorized access and database connection successful!");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Database connection failed");
            }
        }
    }
} 