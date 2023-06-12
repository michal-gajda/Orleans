namespace Gajda.WeatherForecast.IntegrationTests;

using Orleans.TestingHost;

public sealed class TestSiloConfigurations : ISiloConfigurator
{
    public void Configure(ISiloBuilder siloBuilder)
    {
        siloBuilder.AddMemoryGrainStorageAsDefault();
        siloBuilder.UseInMemoryReminderService();
    }
}
