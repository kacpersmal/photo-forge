using System.Security.Cryptography;
using System.Text;

using PhotoForge.Core.ValueObjects;

namespace PhotoForge.Core.Services.Hashing;

internal sealed class HashedValueService : IHashedValueService
{
    private const int SaltSize = 16;

    public HashedValue GenerateHashedValue(string plainTextPassword)
    {
        byte[] salt = GenerateSalt();
        byte[] hash = GenerateHash(plainTextPassword, salt);

        return new HashedValue(hash, salt);
    }

    public bool ValidateHashedValue(string plainTextPassword, HashedValue hashedValue)
    {
        byte[] inputHash = GenerateHash(plainTextPassword, hashedValue.Salt);

        return inputHash.SequenceEqual(hashedValue.Hash);
    }

    private byte[] GenerateSalt()
    {
        var salt = new byte[SaltSize];

        using var rng = RandomNumberGenerator.Create();
        rng.GetBytes(salt);

        return salt;
    }

    private byte[] GenerateHash(string plainText, byte[] salt)
    {
        using var sha256 = SHA256.Create();
        byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);
        byte[] combinedBytes = new byte[plainTextBytes.Length + salt.Length];

        Buffer.BlockCopy(plainTextBytes, 0, combinedBytes, 0, plainTextBytes.Length);
        Buffer.BlockCopy(salt, 0, combinedBytes, plainTextBytes.Length, salt.Length);

        return sha256.ComputeHash(combinedBytes);
    }
}