using Application.Tools;
using Domain.Entities;

namespace Application.Common;

public static class UserExtensions
{
    public static bool VerifyPassword(this User user, string password)
    {
        return PasswordHasher.VerifyHashedPassword(user.PasswordHash, password);
    }
}
