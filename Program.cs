using Docker_Training_2026.Data;
using Docker_Training_2026.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var databaseConnection = builder.Configuration.GetConnectionString("DefaultConnection");
if (string.IsNullOrWhiteSpace(databaseConnection))
{
	throw new InvalidOperationException(
		"Connection string 'DefaultConnection' is required.");
}

var redisConnection = builder.Configuration.GetConnectionString("Redis");
if (string.IsNullOrWhiteSpace(redisConnection))
{
	throw new InvalidOperationException(
		"Connection string 'Redis' is required.");
}

builder.Services.AddControllers();
builder.Services.AddDbContext<WeatherDbContext>(options => options.UseNpgsql(databaseConnection));
builder.Services.AddStackExchangeRedisCache(options => options.Configuration = redisConnection);
builder.Services.AddScoped<WeatherService>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
	var dbContext = scope.ServiceProvider.GetRequiredService<WeatherDbContext>();
	await dbContext.Database.EnsureCreatedAsync();
	await WeatherSeed.SeedAsync(dbContext);
}

app.UseDefaultFiles();
app.UseStaticFiles();

app.MapControllers();  // <-- wires up /api/weather

app.Run();