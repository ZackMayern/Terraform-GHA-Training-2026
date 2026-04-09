using Microsoft.AspNetCore.Mvc;
using Docker_Training_2026.Models;
using Docker_Training_2026.Services;

namespace Docker_Training_2026.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WeatherController(WeatherService weatherService) : ControllerBase
{
    private readonly WeatherService _weatherService = weatherService ?? throw new ArgumentNullException(nameof(weatherService));

    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] string city, CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(city))
            return BadRequest(new { error = "City parameter is required." });

        var data = await _weatherService.GetByCityAsync(city, cancellationToken);
        if (data is null)
            return NotFound(new { error = $"City '{city}' not found." });

        return Ok(data);
    }
}