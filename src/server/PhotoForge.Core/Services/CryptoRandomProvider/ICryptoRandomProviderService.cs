namespace PhotoForge.Core.Services.CryptoRandomProvider;

public interface ICryptoRandomProviderService
{
    public string GetRandomString(int bytes);
}