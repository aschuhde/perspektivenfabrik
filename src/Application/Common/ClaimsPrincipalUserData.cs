using System.Security.Claims;
using Common;
using User = Domain.Entities.UserDto;

namespace Application.Common;

public sealed class ClaimsPrincipalUserData
{
    public const string AuthenticationType = "jwt";
     public required Guid UserId { get; init; }
     public required string[] Roles { get; init; } = [];
}

public static class UserRoles
{
    public const string Admin = "Admin";
}

public static class ClaimsPrincipalExtensions
{
    private const string UserIdName = "data-userid";
    private const string RoleName = "data-role";
    private static ClaimsPrincipalUserData ToUserData(this IEnumerable<Claim> claimsEnumerable)
    {
        var claims = claimsEnumerable.ToList();
        return new ClaimsPrincipalUserData()
        {
            UserId = Guid.Parse(ThrowIf.NullOrWhitespace(claims.FirstOrDefault(x => x.Type == UserIdName)?.Value,
                $"{UserIdName} not found in user claims")),
            Roles = claims.Where(x => x.Type == RoleName).Select(x => x.Value).ToArray()
        };
    }
    public static ClaimsPrincipalUserData ToUserData(this ClaimsPrincipal claimsPrincipal)
    {
        return claimsPrincipal.Claims.ToUserData();
    }
    public static ClaimsPrincipalUserData ToUserData(this ClaimsIdentity claimsIdentity)
    {
        return claimsIdentity.Claims.ToUserData();
    }

    public static ClaimsIdentity ToClaimsIdentity(this User user)
    {
        var claims = new List<Claim> { new(UserIdName, user.EntityId.ToString()) };
        if (user.Roles.Length > 0)
        {
            claims.AddRange(user.Roles.Select(x => new Claim(RoleName, x)));
        }

        return new ClaimsIdentity(claims, ClaimsPrincipalUserData.AuthenticationType);
    }
}
