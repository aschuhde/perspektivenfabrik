namespace Domain.DataTypes;

public sealed class BankAccount
{
    public required Iban Iban { get; init; }
    public required Bic Bic { get; init; }
    public required string AccountName { get; init; }
    public required string Reference { get; init; }
}
