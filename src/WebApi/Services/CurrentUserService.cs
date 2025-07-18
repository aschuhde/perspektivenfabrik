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
    public bool IsAdmin => _currentUser?.IsAdmin ?? false;
    public bool IsTrustedUser => _currentUser?.IsTrustedUser ?? false;
    public bool IsApprovalUser => _currentUser?.IsApprovalUser ?? false;
}
