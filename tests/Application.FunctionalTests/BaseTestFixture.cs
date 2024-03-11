using NUnit.Framework;

namespace Application.FunctionalTests;

using static Testing;

[TestFixture]
public abstract class BaseTestFixture
{
    [SetUp]
    public Task TestSetUp()
    {
        return Task.CompletedTask;
    }
}