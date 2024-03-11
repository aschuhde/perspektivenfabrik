using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace Application.Tools;

/// <summary>
/// Implements the standard Identity password hashing.
/// </summary>
public static class PasswordHasher
{
    private const int IterCount = 10000;
    private static readonly RandomNumberGenerator Rng = RandomNumberGenerator.Create();

    // Compares two byte arrays for equality. The method is specifically written so that the loop is not optimized.
    [MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
    private static bool ByteArraysEqual(byte[]? a, byte[]? b)
    {
        if (a == null && b == null)
        {
            return true;
        }
        if (a == null || b == null || a.Length != b.Length)
        {
            return false;
        }
        var areSame = true;
        for (var i = 0; i < a.Length; i++)
        {
            areSame &= (a[i] == b[i]);
        }
        return areSame;
    }

    /// <summary>
    /// Returns a hashed representation of the supplied <paramref name="password"/>.
    /// </summary>
    /// <param name="password">The password to hash.</param>
    /// <returns>A hashed representation of the supplied <paramref name="password"/>.</returns>
    public static string HashPassword(string password)
    {
        if (password == null)
        {
            throw new ArgumentNullException(nameof(password));
        }
        
        return Convert.ToBase64String(HashPasswordV3(password, Rng));
        
    }

    private static byte[] HashPasswordV3(string password, RandomNumberGenerator rng, KeyDerivationPrf prf = KeyDerivationPrf.HMACSHA256, int iterCount = IterCount, int saltSize = 128 / 8, int numBytesRequested = 256 / 8)
    {
        // Produce a version 3 (see comment above) text hash.
        var salt = new byte[saltSize];
        rng.GetBytes(salt);
        var subkey = KeyDerivation.Pbkdf2(password, salt, prf, iterCount, numBytesRequested);

        var outputBytes = new byte[13 + salt.Length + subkey.Length];
        outputBytes[0] = 0x01; // format marker
        WriteNetworkByteOrder(outputBytes, 1, (uint)prf);
        WriteNetworkByteOrder(outputBytes, 5, (uint)iterCount);
        WriteNetworkByteOrder(outputBytes, 9, (uint)saltSize);
        Buffer.BlockCopy(salt, 0, outputBytes, 13, salt.Length);
        Buffer.BlockCopy(subkey, 0, outputBytes, 13 + saltSize, subkey.Length);
        return outputBytes;
    }

    private static uint ReadNetworkByteOrder(byte[] buffer, int offset)
    {
        return ((uint)(buffer[offset + 0]) << 24)
               | ((uint)(buffer[offset + 1]) << 16)
               | ((uint)(buffer[offset + 2]) << 8)
               | buffer[offset + 3];
    }

    /// <summary>
    /// Returns true if the passwords match
    /// </summary>
    /// <param name="hashedPassword">The hash value for a user's stored password.</param>
    /// <param name="providedPassword">The password supplied for comparison.</param>
    /// <returns>true if the passwords match</returns>
    /// <remarks>Implementations of this method should be time consistent.</remarks>
    public static bool VerifyHashedPassword(string hashedPassword, string providedPassword)
    {
        ArgumentNullException.ThrowIfNull(hashedPassword);
        ArgumentNullException.ThrowIfNull(providedPassword);

        var decodedHashedPassword = Convert.FromBase64String(hashedPassword);
        
        if (decodedHashedPassword.Length == 0)
            return false;

        return decodedHashedPassword[0] switch
        {
            0x00 => false,
            0x01 => VerifyHashedPasswordV3(decodedHashedPassword, providedPassword),
            _ => false
        };
    }
    
    private static bool VerifyHashedPasswordV3(byte[] hashedPassword, string password)
    {
        try
        {
            // Read header information
            var prf = (KeyDerivationPrf)ReadNetworkByteOrder(hashedPassword, 1);
            var iterCount = (int)ReadNetworkByteOrder(hashedPassword, 5);
            var saltLength = (int)ReadNetworkByteOrder(hashedPassword, 9);

            // Read the salt: must be >= 128 bits
            if (saltLength < 128 / 8)
            {
                return false;
            }
            var salt = new byte[saltLength];
            Buffer.BlockCopy(hashedPassword, 13, salt, 0, salt.Length);

            // Read the subkey (the rest of the payload): must be >= 128 bits
            var subkeyLength = hashedPassword.Length - 13 - salt.Length;
            if (subkeyLength < 128 / 8)
            {
                return false;
            }
            var expectedSubkey = new byte[subkeyLength];
            Buffer.BlockCopy(hashedPassword, 13 + salt.Length, expectedSubkey, 0, expectedSubkey.Length);
            
            var actualSubkey = KeyDerivation.Pbkdf2(password, salt, prf, iterCount, subkeyLength);
            return ByteArraysEqual(actualSubkey, expectedSubkey);
        }
        catch
        {
            return false;
        }
    }

    private static void WriteNetworkByteOrder(byte[] buffer, int offset, uint value)
    {
        buffer[offset + 0] = (byte)(value >> 24);
        buffer[offset + 1] = (byte)(value >> 16);
        buffer[offset + 2] = (byte)(value >> 8);
        buffer[offset + 3] = (byte)(value >> 0);
    }
}
