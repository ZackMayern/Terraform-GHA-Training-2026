namespace Docker_Training_2026.Models;

public class WeatherLocation
{
    public int Id { get; set; }

    public string LookupKey { get; set; } = string.Empty;

    public string City { get; set; } = string.Empty;

    public int Temp { get; set; }

    public int Feels { get; set; }

    public int Hi { get; set; }

    public int Lo { get; set; }

    public int Humidity { get; set; }

    public string Wind { get; set; } = string.Empty;

    public string Condition { get; set; } = string.Empty;

    public string Icon { get; set; } = string.Empty;

    public List<WeatherForecast> ForecastDays { get; set; } = [];
}

public class WeatherForecast
{
    public int Id { get; set; }

    public int WeatherLocationId { get; set; }

    public string Day { get; set; } = string.Empty;

    public int Hi { get; set; }

    public int Lo { get; set; }

    public string Icon { get; set; } = string.Empty;

    public WeatherLocation? WeatherLocation { get; set; }
}