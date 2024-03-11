using Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace Application.FunctionalTests;

[SetUpFixture]
public partial class Testing
{
    private static CustomWebApplicationFactory _factory = null!;
    private static IServiceScopeFactory _scopeFactory = null!;

    public static HttpClient CreateClient() => _factory.CreateClient();
    
    [OneTimeSetUp]
    public Task RunBeforeAnyTests()
    {
        _factory = new CustomWebApplicationFactory();

        _scopeFactory = _factory.Services.GetRequiredService<IServiceScopeFactory>();
        
        return Task.CompletedTask;
    }

    [OneTimeTearDown]
    public async Task RunAfterAnyTests()
    {
        await _factory.DisposeAsync();
    }
}