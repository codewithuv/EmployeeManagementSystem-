var builder = WebApplication.CreateBuilder(args);

// =====================
// SERVICES
// =====================
builder.Services.AddControllers();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader());
});

// Swagger (EXPLICIT for .NET 8)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new()
    {
        Title = "Employee Management API",
        Version = "v1"
    });
});

// Render port
builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenAnyIP(10000);
});

var app = builder.Build();

// =====================
// MIDDLEWARE (ORDER MATTERS)
// =====================

// Swagger MUST be before MapControllers
app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "Employee Management API v1");
    options.RoutePrefix = "swagger"; // /swagger
});

app.UseCors("AllowAll");

app.MapControllers();

app.Run();
