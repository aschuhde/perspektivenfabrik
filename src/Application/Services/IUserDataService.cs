using Domain.Entities;

namespace Application.Services;

public interface IUserDataService
{
    public Task<UserDto?> GetActiveUserByEMail(string email, CancellationToken cancellationToken = default);
    public Task<UserDto?> GetActiveUserById(Guid userId, CancellationToken cancellationToken = default);
}
