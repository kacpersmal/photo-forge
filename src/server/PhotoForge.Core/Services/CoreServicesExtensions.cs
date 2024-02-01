using Microsoft.Extensions.DependencyInjection;

using PhotoForge.Core.Services.CryptoRandomProvider;
using PhotoForge.Core.Services.Hashing;
using PhotoForge.Core.Services.TimeProvider;

namespace PhotoForge.Core.Services;

public static class CoreServicesExtensions
{
    public static void AddCoreServices(this IServiceCollection services)
    {
        services.AddTransient<IHashedValueService, HashedValueService>();
        services.AddSingleton<ITimeProviderService,TimeProviderService>();
        services.AddTransient<ICryptoRandomProviderService, CryptoRandomProviderService>();
    }
}