using System.Security.Claims;
using System.Security.Principal;
using Common;
using Domain.Entities;

namespace Application.Common;

public sealed class ClaimsPrincipalUserData
{
    public const string AuthenticationType = "jwt";
     public required Guid UserId { get; init; }
}

public static class ClaimsPrincipalExtensions
{
    private const string UserIdName = "data-userid";
    private static ClaimsPrincipalUserData ToUserData(this Claim? claim)
    {
        return new ClaimsPrincipalUserData()
        {
            UserId = Guid.Parse(ThrowIf.NullOrWhitespace(claim?.Value,
                $"{UserIdName} not found in user claims"))
        };
    }
    public static ClaimsPrincipalUserData ToUserData(this ClaimsPrincipal claimsPrincipal)
    {
        return claimsPrincipal.FindFirst(UserIdName).ToUserData();
    }
    public static ClaimsPrincipalUserData ToUserData(this ClaimsIdentity claimsIdentity)
    {
        return claimsIdentity.FindFirst(UserIdName).ToUserData();
    }

    public static ClaimsIdentity ToClaimsIdentity(this User user) => new(
        new[] { new Claim(UserIdName, user.EntityId.ToString()) }, ClaimsPrincipalUserData.AuthenticationType);
}
