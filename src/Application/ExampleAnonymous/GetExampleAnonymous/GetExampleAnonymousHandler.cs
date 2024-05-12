using Application.Common;

namespace Application.ExampleAnonymous.GetExampleAnonymous;

public sealed class GetExampleAnonymousHandler(IServiceProvider serviceProvider) : BaseHandler<GetExampleAnonymousRequest, GetExampleAnonymousResponse>(serviceProvider)
{
    public override Task<GetExampleAnonymousResponse> ExecuteAsync(GetExampleAnonymousRequest command, CancellationToken ct)
    {
        return Task.FromResult(new GetExampleAnonymousResponse()
        {
            Test = command.Test2 ?? command.Test ?? "Hello world"
        });
    }
}
