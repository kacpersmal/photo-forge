using Microsoft.Extensions.DependencyInjection;

using PhotoForge.Core.Services.Hashing;

namespace PhotoForge.Core.Services;

public static class CoreServicesExtensions
{
    public static void AddCoreServices(this IServiceCollection services)
    {
        services.AddTransient<IHashedValueService, HashedValueService>();
    }
}