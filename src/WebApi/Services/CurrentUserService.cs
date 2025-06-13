using Application.Common;
using Application.Services;
using Common;

namespace WebApi.Services;

public sealed class CurrentUserService(IHttpContextAccessor httpContextAccessor) : ICurrentUserService
{
    private readonly ClaimsPrincipalUserData _currentUser = ThrowIf.Null(httpContextAccessor.HttpContext?.User, $"HttpContext could not be resolved in {nameof(CurrentUserService)}").ToUserData();

    public Guid CurrentUserId => _currentUser.UserId;
    public string DisplayName => _currentUser.DisplayName;
    public bool IsAdmin => _currentUser.Roles.Any(x => string.Equals(x, UserRoles.Admin, StringComparison.OrdinalIgnoreCase));
    public bool IsTrustedUser => _currentUser.Roles.Any(x => string.Equals(x, UserRoles.TrustedUser, StringComparison.OrdinalIgnoreCase));
    public bool IsApprovalUser => _currentUser.Roles.Any(x => string.Equals(x, UserRoles.ApprovalUser, StringComparison.OrdinalIgnoreCase));
}
