using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.DbDataTypes;

[Owned]
public sealed class DbBankAccount
{
    public required DbIban Iban { get; init; }
    public required DbBic Bic { get; init; }
    [MaxLength(Constants.StringLengths.Medium)]
    public required string Reference { get; init; }
    [MaxLength(Constants.StringLengths.Medium)]
    public required string AccountName { get; init; }
}
