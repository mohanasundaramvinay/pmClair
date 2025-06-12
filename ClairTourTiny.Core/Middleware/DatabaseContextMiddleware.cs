using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using ClairTourTiny.Infrastructure;
using ClairTourTiny.Core.Services;
using Microsoft.AspNetCore.Builder;

namespace ClairTourTiny.Core.Middleware
{
    public class DatabaseContextMiddleware
    {
        private readonly RequestDelegate _next;

        public DatabaseContextMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(
            HttpContext context, 
            IConnectionStringCache connectionStringCache,
            ClairTourTinyContext dbContext)
        {
            var username = context.User.FindFirst(ClaimTypes.Name)?.Value;
            
            if (!string.IsNullOrEmpty(username))
            {
                var connectionString = connectionStringCache.GetConnectionString(username);
                if (!string.IsNullOrEmpty(connectionString))
                {
                    // Update the DbContext with the new connection string
                    dbContext.Database.SetConnectionString(connectionString);
                }
            }

            await _next(context);
        }
    }

    public static class DatabaseContextMiddlewareExtensions
    {
        public static IApplicationBuilder UseDatabaseContext(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<DatabaseContextMiddleware>();
        }
    }
} 