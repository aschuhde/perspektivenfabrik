using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace Application.FunctionalTests;

[SetUpFixture]
public partial class Testing
{
    private static CustomWebApplicationFactory _factory = null!;
    private static IServiceScopeFactory _scopeFactory = null!;
    

    public static HttpClient CreateClient() => _factory.CreateClient();
    public static IServiceProvider Services => _factory.Services;
    public static IServiceScopeFactory ScopeFactory => _scopeFactory;
    public static IConfiguration Configuration => _factory.Services.GetRequiredService<IConfiguration>();

    protected virtual CustomWebApplicationFactory GetWebApplicationFactory()
    {
        return new CustomWebApplicationFactory();
    }
    [OneTimeSetUp]
    public Task RunBeforeAnyTests()
    {
        _factory = GetWebApplicationFactory();

        _scopeFactory = _factory.Services.GetRequiredService<IServiceScopeFactory>();
        
        return Task.CompletedTask;
    }

    [OneTimeTearDown]
    public async Task RunAfterAnyTests()
    {
        await _factory.DisposeAsync();
    }
}