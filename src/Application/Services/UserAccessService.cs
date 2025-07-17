namespace Application.Services;

public class UserAccessService(ICurrentUserService currentUserService) : IUserAccessService
{
    public Task<bool> UserCanEditBaseMetadata()
    {
        //todo
        return Task.FromResult(true);
    }

    public bool UserProjectsNeedApproval() => !currentUserService.IsTrustedUser && !currentUserService.IsAdmin;
    public bool CanApproveProject()
    {
        return currentUserService.IsApprovalUser || currentUserService.IsAdmin;
    }
}