using Common;

namespace Application.Configuration;

public class SmtpOptions
{
    public const string SectionName = "Smtp";
    public string SmtpHost { get; set; } = "";
    public string SmtpUser { get; set; } = "";
    public string SmtpPassword { get; set; } = "";
    public string SmtpSenderName { get; set; } = "";
    public string SmtpSenderAddress { get; set; } = "";
    public int SmtpPort { get; set; }
    public string DevRecipient { get; set; } = "";
    public bool Enabled { get; set; } = true;

    public void Validate()
    {
        if (!Enabled)
        {
            return;
        }
        ThrowIf.NullOrWhitespace(SmtpHost);
        ThrowIf.NullOrWhitespace(SmtpUser);
        ThrowIf.NullOrWhitespace(SmtpPassword);
        ThrowIf.NullOrWhitespace(SmtpSenderName);
        ThrowIf.NullOrWhitespace(SmtpSenderAddress);
        ThrowIf.NullOrNotEqualTo(SmtpPort,"Must be 587 or 465", nameof(SmtpPort), 587, 465);
    }
}