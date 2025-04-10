using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.DbDataTypes;

[Owned]
public sealed class DbBic
{
    [MaxLength(Constants.StringLengths.Medium)]
    public required string BicName { get; init; }
}
