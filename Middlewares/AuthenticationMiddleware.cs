using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace UserManagementAPI.Middlewares
{
    public class AuthenticationMiddleware
    {
        private readonly RequestDelegate _next;

        public AuthenticationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var path = context.Request.Path.Value ?? string.Empty;
            
            // Bypass authentication for Swagger UI endpoints
            if (path.StartsWith("/swagger", StringComparison.OrdinalIgnoreCase))
            {
                await _next(context);
                return;
            }

            if (!context.Request.Headers.TryGetValue("Authorization", out var token) || token != "Bearer secret-token")
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsJsonAsync(new { error = "Unauthorized. Please provide a valid 'Authorization: Bearer secret-token' header." });
                return;
            }
            await _next(context);
        }
    }
}
