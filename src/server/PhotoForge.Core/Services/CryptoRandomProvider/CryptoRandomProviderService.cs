using System.Security.Cryptography;

namespace PhotoForge.Core.Services.CryptoRandomProvider;

internal sealed class CryptoRandomProviderService : ICryptoRandomProviderService
{
    public string GetRandomString(int bytes)
        =>  Convert.ToBase64String(RandomNumberGenerator.GetBytes(bytes));
}