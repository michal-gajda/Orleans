﻿namespace Gajda.WeatherForecast;

using Orleans;

public sealed class WeatherForecastGrain : Grain, IWeatherForecastGrain
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    public async Task<List<WeatherForecast>> GetForecastsAsync()
    {
        return await Task.FromResult(Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateTime.Now.AddDays(index),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToList());
    }
}
