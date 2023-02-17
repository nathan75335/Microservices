using Microsoft.AspNetCore.Mvc;

namespace CustomValidation.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    List<WeatherForecast> weathers = new List<WeatherForecast>();
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }

    [HttpGet("GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
    }

    [HttpPost("AddWeatherForecast")]
    public IActionResult AddWeatherForecast([FromBody] WeatherForecast weatherForecast)
    {
        return Ok();
    }
    
    [HttpPost("student")]
    public IActionResult AddStudent([FromBody]Student student)
    {
        return Ok();
    }
}
