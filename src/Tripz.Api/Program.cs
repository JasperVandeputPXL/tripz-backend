using Microsoft.AspNetCore.OpenApi;
using Microsoft.EntityFrameworkCore;
using Tripz.AppLogic;
using Tripz.AppLogic.Services;
using Tripz.Infrastructure.Data;
using Tripz.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddOpenApi();

// Add Swagger/Swashbuckle
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "Tripz API", Version = "v1" });
});

// Configure in-memory database
builder.Services.AddDbContext<TripzDbContext>(options =>
    options.UseInMemoryDatabase("TripzDb"));

// Register application services
builder.Services.AddScoped<ITripService, TripService>();
builder.Services.AddScoped<ITripRepository, TripRepository>();
builder.Services.AddSingleton<IUserRepository, InMemoryUserRepository>();
builder.Services.AddScoped<AuthService>();

var app = builder.Build();

// Seed the database
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<TripzDbContext>();
    DbSeeder.SeedData(context);
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    
    // Enable Swagger UI
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "Tripz API v1");
        //options.RoutePrefix = string.Empty;
    });
}

app.UseHttpsRedirection();

// TODO: Uncomment when authentication is implemented
// app.UseAuthentication();
// app.UseAuthorization();

app.MapControllers();

app.Run();