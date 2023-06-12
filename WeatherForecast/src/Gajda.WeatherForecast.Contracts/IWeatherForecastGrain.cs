namespace Gajda.WeatherForecast;

using Orleans;

public interface IWeatherForecastGrain : IGrainWithGuidKey
{
    Task<List<WeatherForecast>> GetForecastsAsync();
}
