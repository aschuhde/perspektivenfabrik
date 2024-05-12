using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.DbDataTypes;

[Owned]
public sealed class DbFormattedContent
{
    [MaxLength(Constants.StringLengths.Largest)]
    public required string RawContentString { get; init; }
}