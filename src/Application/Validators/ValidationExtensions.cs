using FluentValidation;

namespace Application.Validators;

public static class ValidationExtensions
{
    private static bool HaveOnlyAlphabeticCharactersAndNumbers(string s) => 
        s.All(c => c is >= 'a' and <= 'z' or >= 'A' and <= 'Z' or >= '0' and <= '9');

    public static IRuleBuilderOptions<T, string> IsRequiredName<T>(this IRuleBuilder<T, string> rule)
    {
        return rule.IsRequiredTitle().Must(HaveOnlyAlphabeticCharactersAndNumbers)
            .WithMessage($"The name must have {ApiStringLengths.NameMinimum} to {ApiStringLengths.NameMaximum} characters, only containing alphabetic letters and numbers");
    }
    public static IRuleBuilderOptions<T, string> IsRequiredTitle<T>(this IRuleBuilder<T, string> rule)
    {
        return rule.NotNull().NotEmpty().MinimumLength(ApiStringLengths.NameMinimum).MaximumLength(ApiStringLengths.NameMaximum)
            .WithMessage($"The title must have {ApiStringLengths.NameMinimum} to {ApiStringLengths.NameMaximum} characters");
    }
}