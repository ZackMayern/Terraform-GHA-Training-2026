using Docker_Training_2026.Models;
using Microsoft.EntityFrameworkCore;

namespace Docker_Training_2026.Data;

public static class WeatherSeed
{
    public static async Task SeedAsync(WeatherDbContext dbContext)
    {
        if (await dbContext.WeatherLocations.AnyAsync())
        {
            return;
        }

        var cities = new[]
        {
            CreateLocation("new york", "New York, US", 18, 16, 21, 14, 62, "14 km/h", "Partly cloudy", "cloudy", [
                new WeatherForecast { Day = "Tue", Hi = 22, Lo = 15, Icon = "sunny" },
                new WeatherForecast { Day = "Wed", Hi = 19, Lo = 13, Icon = "rainy" },
                new WeatherForecast { Day = "Thu", Hi = 16, Lo = 11, Icon = "rainy" },
                new WeatherForecast { Day = "Fri", Hi = 20, Lo = 13, Icon = "cloudy" },
                new WeatherForecast { Day = "Sat", Hi = 24, Lo = 16, Icon = "sunny" }
            ]),
            CreateLocation("london", "London, UK", 12, 10, 14, 9, 75, "18 km/h", "Overcast", "cloudy", [
                new WeatherForecast { Day = "Tue", Hi = 13, Lo = 8, Icon = "rainy" },
                new WeatherForecast { Day = "Wed", Hi = 11, Lo = 7, Icon = "rainy" },
                new WeatherForecast { Day = "Thu", Hi = 14, Lo = 9, Icon = "cloudy" },
                new WeatherForecast { Day = "Fri", Hi = 15, Lo = 10, Icon = "cloudy" },
                new WeatherForecast { Day = "Sat", Hi = 16, Lo = 11, Icon = "sunny" }
            ]),
            CreateLocation("tokyo", "Tokyo, JP", 22, 21, 25, 18, 58, "10 km/h", "Clear skies", "sunny", [
                new WeatherForecast { Day = "Tue", Hi = 24, Lo = 19, Icon = "sunny" },
                new WeatherForecast { Day = "Wed", Hi = 23, Lo = 17, Icon = "cloudy" },
                new WeatherForecast { Day = "Thu", Hi = 20, Lo = 16, Icon = "rainy" },
                new WeatherForecast { Day = "Fri", Hi = 22, Lo = 17, Icon = "cloudy" },
                new WeatherForecast { Day = "Sat", Hi = 26, Lo = 20, Icon = "sunny" }
            ]),
            CreateLocation("mumbai", "Mumbai, IN", 34, 38, 36, 29, 82, "22 km/h", "Hot and humid", "sunny", [
                new WeatherForecast { Day = "Tue", Hi = 35, Lo = 28, Icon = "sunny" },
                new WeatherForecast { Day = "Wed", Hi = 33, Lo = 27, Icon = "cloudy" },
                new WeatherForecast { Day = "Thu", Hi = 31, Lo = 26, Icon = "rainy" },
                new WeatherForecast { Day = "Fri", Hi = 30, Lo = 26, Icon = "rainy" },
                new WeatherForecast { Day = "Sat", Hi = 32, Lo = 27, Icon = "cloudy" }
            ]),
            CreateLocation("sydney", "Sydney, AU", 20, 19, 23, 15, 55, "16 km/h", "Sunny intervals", "sunny", [
                new WeatherForecast { Day = "Tue", Hi = 24, Lo = 16, Icon = "sunny" },
                new WeatherForecast { Day = "Wed", Hi = 22, Lo = 15, Icon = "sunny" },
                new WeatherForecast { Day = "Thu", Hi = 19, Lo = 13, Icon = "cloudy" },
                new WeatherForecast { Day = "Fri", Hi = 18, Lo = 12, Icon = "rainy" },
                new WeatherForecast { Day = "Sat", Hi = 21, Lo = 14, Icon = "cloudy" }
            ]),
            CreateLocation("paris", "Paris, FR", 15, 13, 17, 11, 68, "12 km/h", "Light rain", "rainy", [
                new WeatherForecast { Day = "Tue", Hi = 16, Lo = 10, Icon = "rainy" },
                new WeatherForecast { Day = "Wed", Hi = 14, Lo = 9, Icon = "rainy" },
                new WeatherForecast { Day = "Thu", Hi = 17, Lo = 11, Icon = "cloudy" },
                new WeatherForecast { Day = "Fri", Hi = 19, Lo = 13, Icon = "sunny" },
                new WeatherForecast { Day = "Sat", Hi = 20, Lo = 14, Icon = "sunny" }
            ]),
            CreateLocation("dubai", "Dubai, AE", 38, 41, 40, 31, 45, "8 km/h", "Clear and sunny", "sunny", [
                new WeatherForecast { Day = "Tue", Hi = 41, Lo = 32, Icon = "sunny" },
                new WeatherForecast { Day = "Wed", Hi = 39, Lo = 31, Icon = "sunny" },
                new WeatherForecast { Day = "Thu", Hi = 38, Lo = 30, Icon = "sunny" },
                new WeatherForecast { Day = "Fri", Hi = 37, Lo = 30, Icon = "sunny" },
                new WeatherForecast { Day = "Sat", Hi = 39, Lo = 31, Icon = "sunny" }
            ]),
            CreateLocation("bengaluru", "Bengaluru, IN", 27, 28, 30, 22, 60, "11 km/h", "Partly cloudy", "cloudy", [
                new WeatherForecast { Day = "Tue", Hi = 29, Lo = 21, Icon = "sunny" },
                new WeatherForecast { Day = "Wed", Hi = 28, Lo = 21, Icon = "cloudy" },
                new WeatherForecast { Day = "Thu", Hi = 26, Lo = 20, Icon = "rainy" },
                new WeatherForecast { Day = "Fri", Hi = 25, Lo = 19, Icon = "rainy" },
                new WeatherForecast { Day = "Sat", Hi = 27, Lo = 21, Icon = "cloudy" }
            ]),
            CreateLocation("bangalore", "Bengaluru, IN", 27, 28, 30, 22, 60, "11 km/h", "Partly cloudy", "cloudy", [
                new WeatherForecast { Day = "Tue", Hi = 29, Lo = 21, Icon = "sunny" },
                new WeatherForecast { Day = "Wed", Hi = 28, Lo = 21, Icon = "cloudy" },
                new WeatherForecast { Day = "Thu", Hi = 26, Lo = 20, Icon = "rainy" },
                new WeatherForecast { Day = "Fri", Hi = 25, Lo = 19, Icon = "rainy" },
                new WeatherForecast { Day = "Sat", Hi = 27, Lo = 21, Icon = "cloudy" }
            ]),
            CreateLocation("new delhi", "New Delhi, IN", 35, 39, 38, 28, 40, "15 km/h", "Hazy sunshine", "sunny", [
                new WeatherForecast { Day = "Tue", Hi = 37, Lo = 29, Icon = "sunny" },
                new WeatherForecast { Day = "Wed", Hi = 36, Lo = 28, Icon = "sunny" },
                new WeatherForecast { Day = "Thu", Hi = 34, Lo = 27, Icon = "cloudy" },
                new WeatherForecast { Day = "Fri", Hi = 33, Lo = 26, Icon = "cloudy" },
                new WeatherForecast { Day = "Sat", Hi = 35, Lo = 27, Icon = "sunny" }
            ])
        };

        await dbContext.WeatherLocations.AddRangeAsync(cities);
        await dbContext.SaveChangesAsync();
    }

    private static WeatherLocation CreateLocation(
        string lookupKey,
        string city,
        int temp,
        int feels,
        int hi,
        int lo,
        int humidity,
        string wind,
        string condition,
        string icon,
        IEnumerable<WeatherForecast> forecastDays)
    {
        return new WeatherLocation
        {
            LookupKey = lookupKey,
            City = city,
            Temp = temp,
            Feels = feels,
            Hi = hi,
            Lo = lo,
            Humidity = humidity,
            Wind = wind,
            Condition = condition,
            Icon = icon,
            ForecastDays = forecastDays.ToList()
        };
    }
}