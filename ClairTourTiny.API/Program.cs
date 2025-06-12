using ClairTourTiny.Core.Helpers;
using ClairTourTiny.Core.Interfaces;
using ClairTourTiny.Core.Mapping;
using ClairTourTiny.Core.Services;
using ClairTourTiny.Infrastructure;
using ClairTourTiny.Infrastructure.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using ClairTourTiny.Core.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Configure ClairTourTinyContext
builder.Services.AddDbContext<ClairTourTinyContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add Swagger documentation
builder.Services.AddScoped(typeof(IProjectService), typeof(ProjectService));
builder.Services.AddScoped(typeof(IPhaseService), typeof(PhaseService));
builder.Services.AddScoped(typeof(IProjectMaintenanceService), typeof(ProjectMaintenanceService));
builder.Services.AddScoped(typeof(IProjectMaintenanceHelper), typeof(ProjectMaintenanceHelper));
builder.Services.AddScoped(typeof(IProjectDataPointsService), typeof(ProjectDataPointsService));        
builder.Services.AddScoped(typeof(IVendorService), typeof(VendorService));
builder.Services.AddScoped(typeof(ILookupService), typeof(LookupService));
builder.Services.AddScoped(typeof(IPurchaseOrderService), typeof(PurchaseOrderService));
builder.Services.AddScoped(typeof(IFileExplorerService), typeof(FileExplorerService));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Clair Tour Tiny API",
        Version = "v1",
        Description = "API for Clair Tour Tiny application"
    });
    // Add custom schema ID generation
    c.CustomSchemaIds(type =>
    {
        // Infrastructure Models
        if (type.FullName?.StartsWith("ClairTourTiny.Infrastructure.Models.") == true)
        {
            var typeName = type.Name;
            if (typeName == "ProjectBillingPeriod") return "InfrastructureProjectBillingPeriod";
            if (typeName == "ProjectClientContact") return "InfrastructureProjectClientContact";
            if (typeName == "ProjectBillingPeriodItem") return "InfrastructureProjectBillingPeriodItem";
            if (typeName == "ProjectBillingItem") return "InfrastructureProjectBillingItem";
            if (typeName == "ProjectProductionSchedule") return "InfrastructureProjectProductionSchedule";
            if (typeName == "ProjectNote") return "InfrastructureProjectNote";
            if (typeName == "ProjectEmployeeOvertimeRate") return "InfrastructureProjectEmployeeOvertimeRate";
            return $"Infrastructure{typeName}";
        }

        // Core Models in ProjectMaintenance.Save namespace
        if (type.FullName?.StartsWith("ClairTourTiny.Core.Models.ProjectMaintenance.Save.") == true)
        {
            var typeName = type.Name;
            if (typeName == "ProjectBillingPeriod") return "CoreProjectBillingPeriod";
            if (typeName == "ProjectClientContact") return "CoreProjectClientContact";
            if (typeName == "ProjectBillingPeriodItem") return "CoreProjectBillingPeriodItem";
            if (typeName == "ProjectBillingItem") return "CoreProjectBillingItem";
            if (typeName == "ProjectProductionSchedule") return "CoreProjectProductionSchedule";
            if (typeName == "ProjectNote") return "CoreProjectNote";
            if (typeName == "ProjectEmployeeOvertimeRate") return "CoreProjectEmployeeOvertimeRate";
            return $"Core{typeName}";
        }

        // Core Models in ProjectMaintenance namespace (not in Save)
        if (type.FullName?.StartsWith("ClairTourTiny.Core.Models.ProjectMaintenance.") == true)
        {
            var typeName = type.Name;
            if (typeName.EndsWith("Model")) return typeName;
            return $"{typeName}Model";
        }

        // Default case
        return type.Name;
    });

    // Add XML comments if available
    var xmlFile = $"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    if (File.Exists(xmlPath))
    {
        c.IncludeXmlComments(xmlPath);
    }

    // Add JWT Authentication
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});

// Add CORS
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

builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

// Add Memory Cache
builder.Services.AddMemoryCache();

// Add JWT Authentication
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
        };
    });

// Register services
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddSingleton<IConnectionStringCache, ConnectionStringCache>();

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Clair Tour Tiny API V1");
        c.RoutePrefix = "swagger";
    });
//}

app.UseHttpsRedirection();
app.UseRouting();
app.UseCors("AllowAll");

// Add authentication and authorization middleware
app.UseAuthentication();
app.UseAuthorization();

// Add database context middleware
app.UseDatabaseContext();

app.MapControllers();

app.Run();
