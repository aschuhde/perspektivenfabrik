namespace Application.Services;

public interface ICurrentUserService
{
    public Guid CurrentUserId { get; }
    public bool IsAdmin { get; }
}
