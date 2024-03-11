namespace Application.Services;

public interface ICurrentUserService
{
    public Guid CurrentUserId { get; }
}
