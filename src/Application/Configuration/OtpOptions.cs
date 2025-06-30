namespace Application.Configuration;

public class OtpOptions
{
    public const string SectionName = "Otp";
    public int SecondsToWaitForNewRequest { get; set; } = 30;
    public int ExpirationInSeconds { get; set; } = 300;
}