namespace Domain.DataTypes;

public sealed class PhoneNumber
{
    public required string PhoneNumberText { get; init; }
    public TranslationValue[] PhoneNumberTextTranslations { get; set; } = [];
}