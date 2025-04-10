namespace Domain.DataTypes;

public sealed class PostalAddress
{
    public required string AddressText { get; init; }
    public required string AddressDisplayName { get; set; }
}