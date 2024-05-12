using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.DbDataTypes;

[Owned]
public sealed class DbPostalAddress
{
    [MaxLength(Constants.StringLengths.Medium)]
    public required string AddressLine1 { get; init; }
    [MaxLength(Constants.StringLengths.Medium)]
    public required string AddressLine2 { get; init; }
    [MaxLength(Constants.StringLengths.Medium)]
    public required string AddressLine3 { get; init; }
    [MaxLength(Constants.StringLengths.Medium)]
    public required string AddressLine4 { get; init; }
    [MaxLength(Constants.StringLengths.Medium)]
    public required string AddressLine5 { get; init; }
    [MaxLength(Constants.StringLengths.Medium)]
    public required string AddressLine6 { get; init; }
}