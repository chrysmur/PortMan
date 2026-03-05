using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Security.Cryptography;

namespace PortMan.Api.Authentication.helpers;

internal static class PassWordHandler
{
    private const int SALT_SIZE = 16;
    private const int HASH_SIZE = 32;
    private const int ITERATIONS = 310000;
    public static string HashPassword(string password)
    {
        ArgumentNullException.ThrowIfNull(password);

        

        byte[] salt = RandomNumberGenerator.GetBytes(SALT_SIZE);

        byte[] hash = KeyDerivation.Pbkdf2(
            password,
            salt,
            KeyDerivationPrf.HMACSHA256,
            ITERATIONS,
            HASH_SIZE);

        byte[] result = new byte[1 + 4 + SALT_SIZE + HASH_SIZE];
        Span<byte> span = result;

        span[0] = 1; // version
        BitConverter.TryWriteBytes(span[1..5], ITERATIONS);

        salt.CopyTo(span[5..]);
        hash.CopyTo(span[(5 + SALT_SIZE)..]);

        return Convert.ToBase64String(result);
    }

    public static bool VerifyPassword(string password, string storedHash)
    {
        ArgumentNullException.ThrowIfNull(password);
        ArgumentNullException.ThrowIfNull(storedHash);

        byte[] combined = Convert.FromBase64String(storedHash);
        ReadOnlySpan<byte> span = combined;

        if (span.Length != 1 + 4 + SALT_SIZE + HASH_SIZE || span[0] != 1)
        {
            return false; // Invalid hash format
        }
       
        int iterations = BitConverter.ToInt32(span[1..5]);
        ReadOnlySpan<byte> salt = span[5..(5 + SALT_SIZE)];
        ReadOnlySpan<byte> storedHashedBytes = span[(5 + SALT_SIZE)..];

        byte[] computedHash = KeyDerivation.Pbkdf2(
            password: password,
            salt: salt.ToArray(),
            prf: KeyDerivationPrf.HMACSHA256,
            iterationCount: iterations,
            numBytesRequested: HASH_SIZE);
        return CryptographicOperations.FixedTimeEquals(computedHash, storedHashedBytes);
    }
}
