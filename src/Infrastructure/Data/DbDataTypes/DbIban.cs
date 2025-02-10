using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.DbDataTypes;

[Owned]
public sealed class DbIban
{
    [MaxLength(Constants.StringLengths.Medium)]
    public required string Iban { get; init; }
}
