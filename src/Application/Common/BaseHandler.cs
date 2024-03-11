using Application.Services;
using FastEndpoints;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Common;

public abstract class BaseHandler<TCommand, TResponse>(IServiceProvider serviceProvider) : ICommandHandler<TCommand, TResponse> where TCommand : ICommand<TResponse>
{

    private ICurrentUserService? _currentUserService;
    private IUserDataService? _userDataService;
    private ICurrentRequestInformationService? _currentRequestInformationService;

    public ICurrentUserService CurrentUserService =>
        _currentUserService ??= serviceProvider.GetRequiredService<ICurrentUserService>();

    public IUserDataService UserDataService =>
        _userDataService ??= serviceProvider.GetRequiredService<IUserDataService>();

    public ICurrentRequestInformationService CurrentRequestInformationService => _currentRequestInformationService ??=
        serviceProvider.GetRequiredService<ICurrentRequestInformationService>();
    
    public abstract Task<TResponse> ExecuteAsync(TCommand command, CancellationToken ct);
}
