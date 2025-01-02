namespace Application.Services;

public interface IUserAccessService
{
    public Task<bool> UserCanEditBaseMetadata();
}
