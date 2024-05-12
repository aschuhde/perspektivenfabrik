namespace Domain.DataTypes;

public sealed class PostalAddress
{
    public required string AddressLine1 { get; init; }
    public required string AddressLine2 { get; init; }
    public required string AddressLine3 { get; init; }
    public required string AddressLine4 { get; init; }
    public required string AddressLine5 { get; init; }
    public required string AddressLine6 { get; init; }
}