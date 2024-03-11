namespace Domain.Entities;

public class UserRefreshToken
{
    public required string RefreshToken { get; init; }
    public required DateTimeOffset AbsoluteExpirationUtc { get; init; }
    public required bool ShouldBeRenewed { get; init; }
}