using Microsoft.Extensions.Configuration;

namespace Application.Configuration;

public static class OptionExtensions
{
    public static OtpOptions GetOtpOptions(this IConfiguration configuration)
    {
        var otpOptions = new OtpOptions();
        configuration.GetSection(OtpOptions.SectionName).Bind(otpOptions);
        return otpOptions;
    }
}