using Application.Common.Response;

namespace Application.ExampleAnonymous.GetExampleAnonymous;

public sealed class GetExampleAnonymousResponse : JsonResponse
{
    public required string Test { get; init; }
}

