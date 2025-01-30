namespace Application.Services;

public class UserAccessService : IUserAccessService
{
    public Task<bool> UserCanEditBaseMetadata()
    {
        //todo
        return Task.FromResult(true);
    }
}