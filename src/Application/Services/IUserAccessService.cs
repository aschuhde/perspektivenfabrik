namespace Application.Services;

public interface IUserAccessService
{
    public Task<bool> UserCanEditBaseMetadata();
    public bool UserProjectsNeedApproval();
    public bool CanApproveProject();
}
