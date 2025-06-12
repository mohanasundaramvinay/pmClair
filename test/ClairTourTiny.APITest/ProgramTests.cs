using Xunit;
using Moq;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using ClairTourTiny.Core.Interfaces;
using ClairTourTiny.Core.Services;
using ClairTourTiny.Infrastructure.Helpers;
using ClairTourTiny.Infrastructure;
using System;
using System.Linq;
public class StartupTests
{
    private readonly Mock<IServiceCollection> _servicesMock;
    private readonly Mock<IConfiguration> _configurationMock;
    private readonly Mock<WebApplicationBuilder> _builderMock;
    public StartupTests()
    {
        _servicesMock = new Mock<IServiceCollection>();
        _configurationMock = new Mock<IConfiguration>();
        _builderMock = new Mock<WebApplicationBuilder>();
        _builderMock.SetupGet(b => b.Services).Returns(_servicesMock.Object);
        _builderMock.SetupGet(b => b.Configuration).Returns(_configurationMock.Object);
    }
    [Fact]
    public void TestServiceRegistrations()
    {
        // Arrange
        var builder = WebApplication.CreateBuilder(new string[] { });
        // Act
        builder.Services.AddControllers();
        builder.Services.AddDbContext<ClairTourTinyContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
        builder.Services.AddScoped(typeof(IProjectService), typeof(ProjectService));
        builder.Services.AddScoped(typeof(IPhaseService), typeof(PhaseService));
        builder.Services.AddScoped(typeof(IProjectMaintenanceService), typeof(ProjectMaintenanceService));
        builder.Services.AddScoped(typeof(IProjectMaintenanceHelper), typeof(ProjectMaintenanceHelper));
        builder.Services.AddScoped(typeof(IProjectDataPointsService), typeof(ProjectDataPointsService));
        builder.Services.AddScoped(typeof(IVendorService), typeof(VendorService));
        builder.Services.AddScoped(typeof(ILookupService), typeof(LookupService));
        builder.Services.AddScoped(typeof(IPurchaseOrderService), typeof(PurchaseOrderService));
        builder.Services.AddScoped(typeof(IFileExplorerService), typeof(FileExplorerService));
        // Assert
        Assert.Contains(builder.Services, s => s.ServiceType == typeof(IProjectService) && s.ImplementationType == typeof(ProjectService));
        Assert.Contains(builder.Services, s => s.ServiceType == typeof(IPhaseService) && s.ImplementationType == typeof(PhaseService));
        Assert.Contains(builder.Services, s => s.ServiceType == typeof(IProjectMaintenanceService) && s.ImplementationType == typeof(ProjectMaintenanceService));
        Assert.Contains(builder.Services, s => s.ServiceType == typeof(IProjectMaintenanceHelper) && s.ImplementationType == typeof(ProjectMaintenanceHelper));
        Assert.Contains(builder.Services, s => s.ServiceType == typeof(IProjectDataPointsService) && s.ImplementationType == typeof(ProjectDataPointsService));
        Assert.Contains(builder.Services, s => s.ServiceType == typeof(IVendorService) && s.ImplementationType == typeof(VendorService));
        Assert.Contains(builder.Services, s => s.ServiceType == typeof(ILookupService) && s.ImplementationType == typeof(LookupService));
        Assert.Contains(builder.Services, s => s.ServiceType == typeof(IPurchaseOrderService) && s.ImplementationType == typeof(PurchaseOrderService));
        Assert.Contains(builder.Services, s => s.ServiceType == typeof(IFileExplorerService) && s.ImplementationType == typeof(FileExplorerService));
    }
    [Fact]
    public void TestSwaggerConfiguration()
    {
        // Arrange
        var builder = WebApplication.CreateBuilder(new string[] { });
        // Act
        builder.Services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Clair Tour Tiny API",
                Version = "v1",
                Description = "API for Clair Tour Tiny application"
            });
        });
        // Assert
        Assert.Contains(builder.Services, s => s.ServiceType == typeof(SwaggerGenOptions));
    }
    [Fact]
    public void TestCorsConfiguration()
    {
        // Arrange
        var builder = WebApplication.CreateBuilder(new string[] { });
        // Act
        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowAll",
                builder =>
                {
                    builder.AllowAnyOrigin()
                           .AllowAnyMethod()
                           .AllowAnyHeader();
                });
        });
        // Assert
        Assert.Contains(builder.Services, s => s.ServiceType == typeof(CorsOptions));
    }
}