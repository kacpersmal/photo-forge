using Microsoft.AspNetCore.Authentication.JwtBearer;

using PhotoForge.Application.Features.Auth.Services.AuthTokenHelper;
using PhotoForge.Core.Features.Users;

namespace PhotoForge.Api.Extensions;

public static class AuthorizationExtensions
{
    public static void ConfigureAuthorization(this WebApplicationBuilder builder)
    {
        var provider = builder.Services.BuildServiceProvider();
        builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                var tokenHelperService = provider.GetRequiredService<IAuthTokenHelperService>();
                var tokenValidationParameters = tokenHelperService.GetTokenValidationParameters();

                options.TokenValidationParameters = tokenValidationParameters;
                options.Events = new JwtBearerEvents
                {
                    OnTokenValidated = context => Task.CompletedTask,
                    OnAuthenticationFailed = context => Task.CompletedTask
                };
            });
        
        builder.Services.AddAuthorizationBuilder()
            .AddPolicy(AuthPolicies.Admin, policy => policy.RequireRole(nameof(UserRole.Admin)))
            .AddPolicy(AuthPolicies.Guest, policy => policy.RequireRole(nameof(UserRole.Admin),nameof(UserRole.Guest)));
    }
}