using Common;

namespace Application.Messages;

public static class OtpMessages
{
    public static Message NotFound() => new("You don't have any open OTP-Confirmation requests to confirm. Please request a new OTP.");
    public static Message NotRequired() => new("There is no OTP-Confirmation required.");
    public static Message PleaseWaitForNewRequest(int secondsToWait) => new($"Please wait {secondsToWait} seconds before requesting a new OTP.");

    public static string OtpRequestMailSubject(string otpOtp, string preferredLanguageCode)
    {
        if (preferredLanguageCode == LanguageCode.Italian)
        {
            return $"OTP {otpOtp} - Conferma il tuo indirizzo email";
        }

        return $"OTP {otpOtp} - Bitte bestätige deine E-Mail Adresse";
    }

    public const bool OtpRequestMailMessageIsHtml = true;

    public static string OtpRequestMailMessage(string otpOtp, int validityInMinutes, string preferredLanguageCode)
    {
        if (preferredLanguageCode == LanguageCode.Italian)
        {
            return $"<h5>Il tuo codice di conferma è:</h5><h2>{otpOtp}</h2><p>Inserisci il codice di conferma sul sito web. Il codice è valido per {validityInMinutes} minuti.</p><p>Non hai richiesto alcun codice di conferma? Per favore segnalaci l'incidente a info@perspektivenfabrik.it!</p>";
        }

        return $"<h5>Dein Bestätigungscode lautet:</h5><h2>{otpOtp}</h2><p>Bitte gib den Bestätigungscode auf der Website ein. Der Code ist {validityInMinutes} Minuten gültig.</p><p>Du hast keinen Bestätigungscode angefragt? Bitte melde uns den Vorfall an info@perspektivenfabrik.it!</p>";
    }
}