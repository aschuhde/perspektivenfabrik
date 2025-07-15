using Application.Configuration;
using Infrastructure.Models;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MimeKit;

namespace Infrastructure.Services;

public class MailService(IConfiguration configuration, ILogger<MailService> logger)
{
    public async Task SendMail(MailObject mail, CancellationToken ct)
    {
        var smtpOptions = configuration.GetSmtpOptions();
        logger.LogDebug("Mail to {Recipients}: {MailSubject} \n {MailMessage}", string.Join(" ;", mail.To.Select(x => $"{x.Name} ({x.Email})").ToArray()), mail.Subject, mail.Message);
        if (!smtpOptions.Enabled)
        {
            return;
        }
        var message = new MimeMessage();
        message.From.Add(new MailboxAddress(smtpOptions.SmtpSenderName, smtpOptions.SmtpSenderAddress));
        message.To.AddRange(mail.To.Select(x => x.ToMailboxAddress()));
        message.Subject = mail.Subject;
        message.Body = new TextPart(mail.IsHtmlBody ? "html" : "plain")
        {
            Text = mail.Message
        };
       
        using var client = new SmtpClient();
        await client.ConnectAsync(smtpOptions.SmtpHost, smtpOptions.SmtpPort, smtpOptions.SmtpPort == 465 ? SecureSocketOptions.SslOnConnect : SecureSocketOptions.StartTls, ct);
        await client.AuthenticateAsync(smtpOptions.SmtpUser, smtpOptions.SmtpPassword, ct);
        await client.SendAsync(message, ct);
        await client.DisconnectAsync(true, ct);
    }
}