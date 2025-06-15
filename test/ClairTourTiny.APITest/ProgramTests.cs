using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Moq;
using Xunit;
using ClairTourTiny.Core.Interfaces;
using ClairTourTiny.Core.Services;
using ClairTourTiny.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.OpenApi.Models;
public class StartupTests
{
    private readonly Mock<IServiceCollection> _serviceCollectionMock;
    private readonly Mock<IConfiguration> _configurationMock;
    private readonly ServiceProvider _serviceProvider;
    public StartupTests()
    {
        _serviceCollectionMock = new Mock<IServiceCollection>();
        _configurationMock = new Mock<IConfiguration>();
        var services = new ServiceCollection();
        services.AddLogging();
        _serviceProvider = services.BuildServiceProvider();
    }
    [Fact]
    public void TestServiceRegistrations()
    {
        // Arrange
        var services = new ServiceCollection();
        var configuration = new ConfigurationBuilder().Build();
        services.AddScoped<IProjectService, ProjectService>();
        services.AddScoped<IPhaseService, PhaseService>();
        services.AddScoped<IProjectMaintenanceService, ProjectMaintenanceService>();
        services.AddScoped<IProjectMaintenanceHelper, ProjectMaintenanceHelper>();
        services.AddScoped<IProjectDataPointsService, ProjectDataPointsService>();
        services.AddScoped<IVendorService, VendorService>();
        services.AddScoped<ILookupService, LookupService>();
        services.AddScoped<IPurchaseOrderService, PurchaseOrderService>();
        services.AddScoped<IFileExplorerService, FileExplorerService>();
        services.AddDbContext<ClairTourTinyContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        // Act
        var serviceProvider = services.BuildServiceProvider();
        // Assert
        Assert.NotNull(serviceProvider.GetService<IProjectService>());
        Assert.NotNull(serviceProvider.GetService<IPhaseService>());
        Assert.NotNull(serviceProvider.GetService<IProjectMaintenanceService>());
        Assert.NotNull(serviceProvider.GetService<IProjectMaintenanceHelper>());
        Assert.NotNull(serviceProvider.GetService<IProjectDataPointsService>());
        Assert.NotNull(serviceProvider.GetService<IVendorService>());
        Assert.NotNull(serviceProvider.GetService<ILookupService>());
        Assert.NotNull(serviceProvider.GetService<IPurchaseOrderService>());
        Assert.NotNull(serviceProvider.GetService<IFileExplorerService>());
    }
    [Fact]
    public void TestJwtAuthenticationSetup()
    {
        // Arrange
        var services = new ServiceCollection();
        var configuration = new ConfigurationBuilder().AddInMemoryCollection(new Dictionary<string, string>
        {
            { "Jwt:Issuer", "TestIssuer" },
            { "Jwt:Audience", "TestAudience" },
            { "Jwt:Key", "TestKey" }
        }).Build();
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = configuration["Jwt:Issuer"],
                    ValidAudience = configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]))
                };
            });
        // Act
        var serviceProvider = services.BuildServiceProvider();
        var authService = serviceProvider.GetService<IAuthenticationService>();
        // Assert
        Assert.NotNull(authService);
    }
    [Fact]
    public void TestSwaggerSetup()
    {
        // Arrange
        var services = new ServiceCollection();
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "Clair Tour Tiny API", Version = "v1" });
        });
        // Act
        var serviceProvider = services.BuildServiceProvider();
        var swaggerGen = serviceProvider.GetService<ISwaggerProvider>();
        // Assert
        Assert.NotNull(swaggerGen);
    }
}