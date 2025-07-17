using Application.Configuration;
using Infrastructure.Models;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Identity.Client;
using MimeKit;

namespace Infrastructure.Services;

public class MailService(IConfiguration configuration, ILogger<MailService> logger, IMemoryCache memoryCache)
{
    private const string AccessTokenCacheKey = "MailService_AccessToken";
    private const int SecondsToCacheExpiresEarlierThanToken = 120;
    private async Task<string> GetConfidentialClientOAuth2CredentialsAsync (SmtpOptions smtpOptions, CancellationToken cancellationToken = default)
    {
        return await memoryCache.GetOrCreateAsync(AccessTokenCacheKey, async entry =>
        {
            var result = await GetConfidentialClientOAuth2CredentialsAsyncWithoutCache(smtpOptions, cancellationToken);
            entry.SetAbsoluteExpiration(result.ExpiresOn.AddSeconds(-SecondsToCacheExpiresEarlierThanToken));
            return result.AccessToken;
        }) ?? "";
    }
    
    private async Task<AuthenticationResult> GetConfidentialClientOAuth2CredentialsAsyncWithoutCache (SmtpOptions smtpOptions, CancellationToken cancellationToken = default)
    {
        var confidentialClientApplication = ConfidentialClientApplicationBuilder.Create(smtpOptions.ClientId)
            .WithAuthority(smtpOptions.AuthorityUrl)
            .WithClientSecret(smtpOptions.ClientSecret)
            .Build();

        var scopes = smtpOptions.Scopes.Split(';',
            StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);

        var authenticationResult = await confidentialClientApplication.AcquireTokenForClient(scopes)
            .ExecuteAsync(cancellationToken);
        return authenticationResult;
    }
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
        if (!string.IsNullOrWhiteSpace(smtpOptions.DevRecipient))
        {
            message.To.Add(new MailboxAddress(smtpOptions.DevRecipient, smtpOptions.DevRecipient));
        }
        else
        {
            message.To.AddRange(mail.To.Select(x => x.ToMailboxAddress()));   
        }
        
        message.Subject = mail.Subject;
        message.Body = new TextPart(mail.IsHtmlBody ? "html" : "plain")
        {
            Text = mail.Message
        };

        
        using var client = new SmtpClient();
        
        await client.ConnectAsync(smtpOptions.SmtpHost, smtpOptions.SmtpPort, smtpOptions.SmtpPort == 465 ? SecureSocketOptions.SslOnConnect : SecureSocketOptions.StartTls, ct);
        if (smtpOptions.UseOauth2)
        {
            var oauth2 = new SaslMechanismOAuth2 (smtpOptions.SmtpUser, await GetConfidentialClientOAuth2CredentialsAsync(smtpOptions, ct));
            await client.AuthenticateAsync(oauth2, ct);
        }
        else
        {
            await client.AuthenticateAsync(smtpOptions.SmtpSenderName, smtpOptions.SmtpPassword, ct);
        }

        await client.SendAsync(message, ct);
        await client.DisconnectAsync(true, ct);
    }
}