namespace Application.ApiDataTypes;

public sealed class ApiMailAddress
{
    public required string Mail { get; set; }
    public ApiTranslationValue[] MailTranslations { get; set; } = [];
}