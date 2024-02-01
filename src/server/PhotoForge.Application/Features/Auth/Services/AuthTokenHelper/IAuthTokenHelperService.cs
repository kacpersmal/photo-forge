using System.Security.Claims;

using Microsoft.IdentityModel.Tokens;

using PhotoForge.Core.Features.Users;
using PhotoForge.Core.ValueObjects;

namespace PhotoForge.Application.Features.Auth.Services.AuthTokenHelper;

public interface IAuthTokenHelperService
{
    public Token GenerateJwtToken(User user);
    public ClaimsPrincipal? ValidateJwtToken(string token);
    public TokenValidationParameters GetTokenValidationParameters();
}