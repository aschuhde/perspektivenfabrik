using Application.ExampleAnonymous.GetExampleAnonymous;
using FluentAssertions;
using NUnit.Framework;
using WebApi.Constants;

namespace Application.FunctionalTests.Example;


using static Testing;

public sealed class GetExampleTests : BaseTestFixture
{
    [Test]
    public async Task ShouldReturnSomeExampleWhenCalledGetExample()
    {
        var response = await CreateClient().GetAsync($"{Routes.GetExampleAnonymous}?test=hello");
        var responseObject = await response.Content.ReadAsJsonObject<GetExampleAnonymousResponse>();
        responseObject.Should().NotBeNull();
        responseObject!.Test.Should().Be("hello");
    }
}