var builder = WebApplication.CreateBuilder(args);

// =====================
// SERVICES
// =====================
builder.Services.AddControllers();

// CORS (Allow Angular – local + deployed)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngular", policy =>
    {
        policy.AllowAnyOrigin()      // Allow Netlify / GitHub Pages
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// =====================
// PORT CONFIG (REQUIRED FOR RENDER)
// =====================
builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenAnyIP(10000);
});

var app = builder.Build();

// =====================
// MIDDLEWARE
// =====================
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// ❌ Comment HTTPS redirection for Render free tier
// app.UseHttpsRedirection();

app.UseCors("AllowAngular");

app.UseAuthorization();

app.MapControllers();

app.Run();
