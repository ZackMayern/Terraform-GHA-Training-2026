using System.Text.Json;
using Docker_Training_2026.Data;
using Docker_Training_2026.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;

namespace Docker_Training_2026.Services;

public class WeatherService(WeatherDbContext dbContext, IDistributedCache cache)
{
    private static readonly JsonSerializerOptions SerializerOptions = new(JsonSerializerDefaults.Web);

    public async Task<WeatherData?> GetByCityAsync(string city, CancellationToken cancellationToken)
    {
        var lookupKey = NormalizeCity(city);
        var cacheKey = $"weather:{lookupKey}";

        var cachedWeather = await cache.GetStringAsync(cacheKey, cancellationToken);
        if (!string.IsNullOrWhiteSpace(cachedWeather))
        {
            return JsonSerializer.Deserialize<WeatherData>(cachedWeather, SerializerOptions);
        }

        var weather = await dbContext.WeatherLocations
            .AsNoTracking()
            .Include(location => location.ForecastDays)
            .SingleOrDefaultAsync(location => location.LookupKey == lookupKey, cancellationToken);

        if (weather is null)
        {
            return null;
        }

        var response = new WeatherData(
            weather.City,
            weather.Temp,
            weather.Feels,
            weather.Hi,
            weather.Lo,
            weather.Humidity,
            weather.Wind,
            weather.Condition,
            weather.Icon,
            weather.ForecastDays
                .OrderBy(forecast => forecast.Id)
                .Select(forecast => new Forecast(forecast.Day, forecast.Hi, forecast.Lo, forecast.Icon))
                .ToArray());

        await cache.SetStringAsync(
            cacheKey,
            JsonSerializer.Serialize(response, SerializerOptions),
            new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(10)
            },
            cancellationToken);

        return response;
    }

    private static string NormalizeCity(string city) => city.Trim().ToLowerInvariant();
}