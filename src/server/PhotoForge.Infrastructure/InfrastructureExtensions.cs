using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using PhotoForge.Infrastructure.Database;
using PhotoForge.Infrastructure.Storage;

namespace PhotoForge.Infrastructure;

public static class InfrastructureExtensions
{
    public static void AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAppDbContext(configuration);

        services.AddTransient<IStorageService, StorageService>();
    }
}