using Microsoft.AspNetCore.Mvc;

namespace SwaggerDateFormat.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }

    /// <summary>
    /// A Swagger example.
    /// </summary>
    /// <param name="firstParam" example="-5">The first parameter.</param>
    /// <param name="secondParam" example="Just try something">The second parameter.</param>
    /// <returns>The return value.</returns>
    [HttpGet("Forecast")]
    public IEnumerable<WeatherForecast> Get([FromQuery]int firstParam, [FromQuery]string secondParam)
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
    }
}