using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.DbDataTypes;

[Owned]
public sealed class DbBankAccount
{
    public required DbIban Iban { get; set; }
    public required DbBic Bic { get; set; }
    [MaxLength(Constants.StringLengths.Medium)]
    public required string Reference { get; set; }
    [MaxLength(Constants.StringLengths.Medium)]
    public required string AccountName { get; set; }

    public void Update(DbBankAccount targetEntityBankAccount)
    {
      if (this.Iban != targetEntityBankAccount.Iban)
      {
        this.Iban = targetEntityBankAccount.Iban;
      }

      if (this.Bic != targetEntityBankAccount.Bic)
      {
        this.Bic = targetEntityBankAccount.Bic;
      }

      if (this.Reference != targetEntityBankAccount.Reference)
      {
        this.Reference = targetEntityBankAccount.Reference;
      }

      if (this.AccountName != targetEntityBankAccount.AccountName)
      {
        this.AccountName = targetEntityBankAccount.AccountName;
      }
    }
}
