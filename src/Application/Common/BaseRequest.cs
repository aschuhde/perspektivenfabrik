using FastEndpoints;

namespace Application.Common;

public class BaseRequest<TResponse> : ICommand<TResponse>
{
    public bool? _ { get; init; }
}
