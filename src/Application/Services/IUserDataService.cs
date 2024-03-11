using Domain.Entities;

namespace Application.Services;

public interface IUserDataService
{
    public Task<User?> GetActiveUserByEMail(string email, CancellationToken cancellationToken = default);
    public Task<User?> GetActiveUserById(Guid userId, CancellationToken cancellationToken = default);
}
