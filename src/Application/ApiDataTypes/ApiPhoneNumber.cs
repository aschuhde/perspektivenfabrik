namespace Application.ApiDataTypes;

public sealed class ApiPhoneNumber
{
    public required string PhoneNumberText { get; init; }
    public ApiTranslationValue[] PhoneNumberTextTranslations { get; set; } = [];
}