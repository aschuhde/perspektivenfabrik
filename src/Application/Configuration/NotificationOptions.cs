using Common;

namespace Application.Configuration;

public class NotificationOptions
{
    public const string SectionName = "Notifications";
    public string ReceiverName { get; set; } = "";
    public string ReceiverAddress { get; set; } = "";

    public void Validate()
    {
        ThrowIf.NullOrWhitespace(ReceiverName);
        ThrowIf.NullOrWhitespace(ReceiverAddress);
    }
}