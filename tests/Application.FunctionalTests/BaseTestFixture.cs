using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace Application.FunctionalTests;

using static Testing;

[TestFixture]
public abstract class BaseTestFixture
{
    private IServiceScope _scope = null!;
    protected IServiceProvider ScopedServices => _scope.ServiceProvider;
    [SetUp]
    public Task TestSetUp()
    {
        _scope = ScopeFactory.CreateScope();
        return Task.CompletedTask;
    }
    [TearDown]
    public Task TestTearDown()
    {
        _scope.Dispose();
        return Task.CompletedTask;
    }
}