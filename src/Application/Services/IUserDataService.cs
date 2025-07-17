using Domain.Entities;

namespace Application.Services;

public interface IUserDataService
{
    public Task<UserDto?> GetActiveUserByEMail(string email, CancellationToken cancellationToken = default);
    public Task<UserDto?> GetActiveUserById(Guid userId, CancellationToken cancellationToken = default);
    Task<bool> CheckIfEmailExists(string dataEmail, CancellationToken ct);
    Task RegisterUser(UserDto userDto, CancellationToken ct);
    Task<string?> GetUserPreferredLanguageCode(Guid userId, CancellationToken ct);
}
