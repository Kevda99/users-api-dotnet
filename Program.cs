var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Configure Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// 1. Error-handling middleware
app.Use(async (context, next) =>
{
    try
    {
        await next(context);
    }
    catch (Exception ex)
    {
        context.Response.StatusCode = 500;
        context.Response.ContentType = "application/json";
        await context.Response.WriteAsJsonAsync(new { error = "Internal server error.", details = ex.Message });
    }
});

// 2. Authentication middleware
app.Use(async (context, next) =>
{
    var path = context.Request.Path.Value ?? string.Empty;
    
    // Bypass authentication for Swagger UI endpoints
    if (path.StartsWith("/swagger", StringComparison.OrdinalIgnoreCase))
    {
        await next(context);
        return;
    }

    if (!context.Request.Headers.TryGetValue("Authorization", out var token) || token != "Bearer secret-token")
    {
        context.Response.StatusCode = 401;
        context.Response.ContentType = "application/json";
        await context.Response.WriteAsJsonAsync(new { error = "Unauthorized. Please provide a valid 'Authorization: Bearer secret-token' header." });
        return;
    }
    await next(context);
});

// 3. Logging middleware
app.Use(async (context, next) =>
{
    var method = context.Request.Method;
    var path = context.Request.Path;
    
    await next(context);
    
    var statusCode = context.Response.StatusCode;
    Console.WriteLine($"[Log] {method} {path} => Status: {statusCode}");
});

app.MapControllers();

app.Run();
