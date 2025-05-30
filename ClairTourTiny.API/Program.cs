using ClairTourTiny.Core.Helpers;
using ClairTourTiny.Core.Interfaces;
using ClairTourTiny.Core.Mapping;
using ClairTourTiny.Core.Services;
using ClairTourTiny.Infrastructure;
using ClairTourTiny.Infrastructure.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Configure ClairTourTinyContext
builder.Services.AddDbContext<ClairTourTinyContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add Swagger documentation
builder.Services.AddScoped(typeof(IProjectService), typeof(ProjectService));
builder.Services.AddScoped(typeof(IProjectMaintenanceService), typeof(ProjectMaintenanceService));
builder.Services.AddScoped(typeof(IProjectMaintenanceHelper), typeof(ProjectMaintenanceHelper));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Clair Tour Tiny API",
        Version = "v1",
        Description = "API for Clair Tour Tiny application"
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

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Clair Tour Tiny API V1");
        c.RoutePrefix = "swagger";
    });
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseCors("AllowAll");
app.UseAuthorization();
app.MapControllers();

app.Run();
