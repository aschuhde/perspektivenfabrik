using MimeKit;

namespace Infrastructure.Models;

public class MailObject
{
    public required MailObjectAddress[] To { get; init; }
    public required string Subject { get; init; }
    public required string Message { get; init; }
    public required bool IsHtmlBody { get; init; }
}

public class MailObjectAddress
{
    public required string Name { get; init; }
    public required string Email { get; init; }

    public MailboxAddress ToMailboxAddress()
    {
        return new MailboxAddress(Name, Email);
    }
}