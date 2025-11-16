using Microsoft.EntityFrameworkCore;
using Tripz.AppLogic.Services;
using Tripz.Infrastructure.Data;
using Tripz.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddControllers();
builder.Services.AddOpenApi();

// Configure in-memory database
builder.Services.AddDbContext<TripzDbContext>(options =>
    options.UseInMemoryDatabase("TripzDb"));

// Register application services
builder.Services.AddScoped<ITripService, TripService>();
builder.Services.AddScoped<ITripRepository, TripRepository>();

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
}

app.UseHttpsRedirection();

// TODO: Uncomment when authentication is implemented
// app.UseAuthentication();
// app.UseAuthorization();

app.MapControllers();

app.Run();