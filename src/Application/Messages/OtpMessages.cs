using Common;

namespace Application.Messages;

public static class OtpMessages
{
    public static Message NotFound() => new("You don't have any open OTP-Confirmation requests to confirm. Please request a new OTP.");
    public static Message NotRequired() => new("There is no OTP-Confirmation required.");
    public static Message PleaseWaitForNewRequest(int secondsToWait) => new($"Please wait {secondsToWait} seconds before requesting a new OTP.");
}