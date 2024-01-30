using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace PhotoForge.Infrastructure.Database;

public static class DatabaseExtensions
{
    public static void AddAppDbContext(this IServiceCollection services, IConfiguration config)
    {
        services.AddDbContext<AppDbContext>(
            options => options.UseNpgsql(config.GetConnectionString("Postgres")));
    }
}