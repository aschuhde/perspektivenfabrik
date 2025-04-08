namespace Application.ApiDataTypes;

public sealed class ApiPostalAddress
{
    public required string AddressText { get; init; }
    public required string AddressDisplayName { get; set; }
}