using System.Security.Claims;
using Common;
using User = Domain.Entities.UserDto;

namespace Application.Common;

public sealed class ClaimsPrincipalUserData
{
    public const string AuthenticationType = "jwt";
    public const string EMailIsConfirmed = "data-emailIsConfirmed";
     public required Guid UserId { get; init; }
     public required string[] Roles { get; init; } = [];
     public required string DisplayName { get; init; }
     
     public bool IsAdmin => Roles.Any(x => string.Equals(x, UserRoles.Admin, StringComparison.OrdinalIgnoreCase));
     public bool IsTrustedUser => Roles.Any(x => string.Equals(x, UserRoles.TrustedUser, StringComparison.OrdinalIgnoreCase));
     public bool IsApprovalUser => Roles.Any(x => string.Equals(x, UserRoles.ApprovalUser, StringComparison.OrdinalIgnoreCase));
}

public static class UserRoles
{
    public const string Admin = "Admin";
    public const string TrustedUser = "TrustedUser";
    public const string ApprovalUser = "ApprovalUser";
}

public static class ClaimsPrincipalExtensions
{
    private const string UserIdName = "data-userid";
    private const string RoleName = "data-role";
    private const string DisplayName = "data-displayName";

    public static Guid? GetUserIdOrNull(this ClaimsPrincipal? claimsPrincipal)
    {
        if (claimsPrincipal == null)
        {
            return null;
        }

        var userIdName = claimsPrincipal.Claims.FirstOrDefault(x => x.Type == UserIdName)?.Value;
        if (string.IsNullOrWhiteSpace(userIdName))
        {
            return null;
        }
        return Guid.TryParse(userIdName, out var userId) ? userId : null;
    }
    
    private static ClaimsPrincipalUserData? ToUserData(this IEnumerable<Claim> claimsEnumerable)
    {
        var claims = claimsEnumerable.ToList();
        if (claims.All(x => x.Type != UserIdName))
        {
            return null;
        }
        return new ClaimsPrincipalUserData()
        {
            UserId = Guid.Parse(ThrowIf.NullOrWhitespace(claims.FirstOrDefault(x => x.Type == UserIdName)?.Value,
                $"{UserIdName} not found in user claims")),
            DisplayName = claims.FirstOrDefault(x => x.Type == DisplayName)?.Value ?? "",
            Roles = claims.Where(x => x.Type == RoleName).Select(x => x.Value).ToArray()
        };
    }
    public static ClaimsPrincipalUserData? ToUserData(this ClaimsPrincipal claimsPrincipal)
    {
        return claimsPrincipal.Claims.ToUserData();
    }
    public static ClaimsPrincipalUserData? ToUserData(this ClaimsIdentity claimsIdentity)
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
        claims.Add(new Claim(DisplayName, $"{user.Firstname} {user.Lastname}"));
        claims.Add(new Claim(ClaimsPrincipalUserData.EMailIsConfirmed, user.EmailConfirmed ? "true" : "false"));

        return new ClaimsIdentity(claims, ClaimsPrincipalUserData.AuthenticationType);
    }
}
