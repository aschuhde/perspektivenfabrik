namespace Domain.DataTypes;

public sealed class BankAccount
{
    public required Iban Iban { get; init; }
    public required Bic Bic { get; init; }
    public required string AccountName { get; init; }
    public required string Reference { get; init; }
    
    public TranslationValue[] AccountNameTranslations { get; set; } = [];
    public TranslationValue[] ReferenceTranslations { get; set; } = [];
}
