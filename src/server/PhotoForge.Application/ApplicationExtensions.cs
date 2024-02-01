using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using PhotoForge.Application.Features.Auth.Services.AuthTokenHelper;

namespace PhotoForge.Application;

public static class ApplicationExtensions
{
    public static void AddApplicationServices(this IServiceCollection services, IConfiguration config)
    {
        services.AddMediatR(conf => conf.RegisterServicesFromAssembly(typeof(ApplicationExtensions).Assembly));
        services.AddAutoMapper(typeof(ApplicationExtensions).Assembly);

        services.AddTransient<IAuthTokenHelperService, AuthTokenHelperService>();
    }
}