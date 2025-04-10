using Application.Tools;
using Domain.Entities;

namespace Application.Common;

public static class UserExtensions
{
    public static bool VerifyPassword(this UserDto user, string password)
    {
        return PasswordHasher.VerifyHashedPassword(user.PasswordHash, password);
    }
}
