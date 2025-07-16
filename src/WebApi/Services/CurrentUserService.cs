using Application.Common;
using Application.Services;
using Common;

namespace WebApi.Services;

public sealed class CurrentUserService(IHttpContextAccessor httpContextAccessor) : ICurrentUserService
{
    private readonly ClaimsPrincipalUserData? _currentUser = httpContextAccessor.HttpContext?.User.ToUserData();

    public bool HasUser => _currentUser != null;
    public Guid CurrentUserId => _currentUser?.UserId ?? Guid.Empty;
    public string DisplayName => _currentUser?.DisplayName ?? "";
    public bool IsAdmin => _currentUser?.Roles.Any(x => string.Equals(x, UserRoles.Admin, StringComparison.OrdinalIgnoreCase)) ?? false;
    public bool IsTrustedUser => _currentUser?.Roles.Any(x => string.Equals(x, UserRoles.TrustedUser, StringComparison.OrdinalIgnoreCase)) ?? false;
    public bool IsApprovalUser => _currentUser?.Roles.Any(x => string.Equals(x, UserRoles.ApprovalUser, StringComparison.OrdinalIgnoreCase)) ?? false;
}
