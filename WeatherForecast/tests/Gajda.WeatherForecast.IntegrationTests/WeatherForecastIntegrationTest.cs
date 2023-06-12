namespace Gajda.WeatherForecast.IntegrationTests;

using Orleans.TestingHost;

[TestClass]
public sealed class WeatherForecastIntegrationTest
{
    private TestCluster? cluster;
    
    private static readonly string[] summaries = {
        "Balmy",
        "Bracing",
        "Chilly",
        "Cool",
        "Freezing",
        "Hot",
        "Mild",
        "Scorching",
        "Sweltering",
        "Warm",
    };
    
    [TestMethod]
    public async Task GetForecastsTestMethod()
    {
        var grain = this.cluster!.GrainFactory.GetGrain<IWeatherForecastGrain>(Guid.Empty);
        var result = await grain.GetForecastsAsync();
        
        result.Should()
            .NotBeEmpty()
            .And
            .HaveCount(5)
            ;

        result[0].TemperatureC.Should()
            .BeInRange(-20, 55)
            ;
        result[0].Summary.Should()
            .NotBeNull()
            .And
            .ContainAny(summaries)
            ;
        
        result[1].TemperatureC.Should()
            .BeInRange(-20, 55)
            ;
        result[1].Summary.Should()
            .NotBeNull()
            .And
            .ContainAny(summaries)
            ;

        result[2].TemperatureC.Should()
            .BeInRange(-20, 55)
            ;
        result[2].Summary.Should()
            .NotBeNull()
            .And
            .ContainAny(summaries)
            ;

        result[3].TemperatureC.Should()
            .BeInRange(-20, 55)
            ;
        result[3].Summary.Should()
            .NotBeNull()
            .And
            .ContainAny(summaries)
            ;

        result[4].TemperatureC.Should()
            .BeInRange(-20, 55)
            ;
        result[4].Summary.Should()
            .NotBeNull()
            .And
            .ContainAny(summaries)
            ;
    }
    
    [TestInitialize]
    public async Task Initialize()
    {
        var builder = new TestClusterBuilder();
        builder.AddSiloBuilderConfigurator<TestSiloConfigurations>();
        this.cluster = builder.Build();
        await this.cluster.DeployAsync();
    }
    
    [TestCleanup]
    public async Task TearDown() 
    {
        await this.cluster!.StopAllSilosAsync();
    }
}
