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
app.UseMiddleware<UserManagementAPI.Middlewares.ErrorHandlingMiddleware>();

// 2. Authentication middleware
app.UseMiddleware<UserManagementAPI.Middlewares.AuthenticationMiddleware>();

// 3. Logging middleware
app.UseMiddleware<UserManagementAPI.Middlewares.LoggingMiddleware>();

app.MapControllers();

app.Run();
