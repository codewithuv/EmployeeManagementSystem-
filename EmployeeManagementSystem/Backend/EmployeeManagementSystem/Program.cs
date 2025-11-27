var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Enable CORS for Angular
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngular", policy =>
        policy.WithOrigins("http://localhost:4200")   // Angular dev server
              .AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials());
});

// Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Enable Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// IMPORTANT: Enable HTTPS redirection
app.UseHttpsRedirection();

// Apply CORS BEFORE Authorization & MapControllers
app.UseCors("AllowAngular");


app.MapControllers();

app.Run();
