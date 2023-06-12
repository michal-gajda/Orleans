namespace Gajda.Recipiens.Web.Controllers;

using Gajda.WeatherForecast;
using Microsoft.AspNetCore.Mvc;

[ApiController, Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private readonly IGrainFactory grainFactory;

    private readonly ILogger<WeatherForecastController> logger;

    public WeatherForecastController(IGrainFactory grainFactory, ILogger<WeatherForecastController> logger)
    {
        this.grainFactory = grainFactory;
        this.logger = logger;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public async Task<IEnumerable<WeatherForecast>> Get()
    {
        var grain = this.grainFactory.GetGrain<IWeatherForecastGrain>(Guid.Empty);
        var result = await grain.GetForecastsAsync();
        return await Task.FromResult(result);
    }
}
