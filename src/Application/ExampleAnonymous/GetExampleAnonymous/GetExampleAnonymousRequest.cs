using Application.Common;

namespace Application.ExampleAnonymous.GetExampleAnonymous;

public class GetExampleAnonymousRequest : BaseRequest<GetExampleAnonymousResponse>
{
    public string? Test { get; init; }
    public string? Test2 { get; init; }
}

