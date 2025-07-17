namespace Application.Services;

public interface ICurrentUserService
{
    public Guid CurrentUserId { get; }
    public string DisplayName { get; }
    public bool IsAdmin { get; }
    public bool IsTrustedUser { get; }
    public bool IsApprovalUser { get; }
}
