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
    
    public static SmtpOptions GetSmtpOptions(this IConfiguration configuration)
    {
        var smtpOptions = new SmtpOptions();
        configuration.GetSection(SmtpOptions.SectionName).Bind(smtpOptions);
        return smtpOptions;
    }
    
    public static NotificationOptions GetNotificationOptions(this IConfiguration configuration)
    {
        var notificationOptions = new NotificationOptions();
        configuration.GetSection(NotificationOptions.SectionName).Bind(notificationOptions);
        return notificationOptions;
    }
}