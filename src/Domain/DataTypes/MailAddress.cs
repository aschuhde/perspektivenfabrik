namespace Domain.DataTypes;

public sealed class MailAddress
{
    public required string Mail { get; set; }
    public TranslationValue[] MailTranslations { get; set; } = [];
}