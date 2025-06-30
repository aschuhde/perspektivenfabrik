using System.Security.Cryptography;

namespace Application.Tools;

public static class OtpGenerator
{
    private const int OtpLength = 6;
    
    public static string GenerateOtp()
    {
        return RandomNumberGenerator.GetString("0123456789", OtpLength);
    }
}