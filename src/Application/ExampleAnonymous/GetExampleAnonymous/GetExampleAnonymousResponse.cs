using Application.Common.Response;

namespace Application.ExampleAnonymous.GetExampleAnonymous;

public class GetExampleAnonymousResponse : JsonResponse
{
    public required string Test { get; init; }
}

