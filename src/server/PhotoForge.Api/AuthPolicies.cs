using PhotoForge.Core.Features.Users;

namespace PhotoForge.Api;

public static class AuthPolicies
{
    public const string Admin = nameof(UserRole.Admin);
    public const string Guest = nameof(UserRole.Guest);
}