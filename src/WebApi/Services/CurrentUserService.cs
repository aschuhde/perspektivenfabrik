using Application.Common;
using Application.Services;
using Common;

namespace WebApi.Services;

public sealed class CurrentUserService(IHttpContextAccessor httpContextAccessor) : ICurrentUserService
{
    private readonly ClaimsPrincipalUserData _currentUser = ThrowIf.Null(httpContextAccessor.HttpContext?.User, $"HttpContext could not be resolved in {nameof(CurrentUserService)}").ToUserData();

    public Guid CurrentUserId => _currentUser.UserId;
}
