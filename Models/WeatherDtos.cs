namespace Docker_Training_2026.Models;

public record Forecast(string Day, int Hi, int Lo, string Icon);

public record WeatherData(
    string City,
    int Temp,
    int Feels,
    int Hi,
    int Lo,
    int Humidity,
    string Wind,
    string Condition,
    string Icon,
    Forecast[] ForecastDays
);