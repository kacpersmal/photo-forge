using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using PhotoForge.Core.Features.Users;
using PhotoForge.Core.ValueObjects;

namespace PhotoForge.Application.Features.Auth.Services.AuthTokenHelper;

internal sealed class AuthTokenHelperService(IConfiguration config) : IAuthTokenHelperService
{
    private readonly string _secretKey = config.GetValue<string>("Jwt:Key") ?? throw new Exception("Jwt Key not found"); 
    private readonly string _issuer = config.GetValue<string>("Jwt:Issuer") ?? throw new Exception("Jwt Issuer not found");    
    private readonly string _audience = config.GetValue<string>("Jwt:Audience") ?? throw new Exception("Jwt Audience not found");
    private readonly int _tokenExpirationSeconds = config.GetValue<int?>("Jwt:TokenExpiration") ?? throw new Exception("Jwt TokenExpiration not found");

    public Token GenerateJwtToken(User user)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Convert.FromBase64String(_secretKey);

        var claims = new ClaimsIdentity(new[]
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Email, user.Email.Address),
            new Claim(ClaimTypes.Role, user.Role.ToString())
        });

        var tokenExpiration = DateTime.UtcNow.AddSeconds(_tokenExpirationSeconds);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = claims,
            Expires = tokenExpiration,
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
            Issuer = _issuer,
            Audience = _audience
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return new Token { Value = tokenHandler.WriteToken(token), ExpirationDate = tokenExpiration};
    }

    public ClaimsPrincipal? ValidateJwtToken(string token)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        try
        {
            var principal = tokenHandler.ValidateToken(token, GetTokenValidationParameters(), out SecurityToken validatedToken);

            return principal;
        }
        catch (Exception)
        {
            return null;
        }
    }

    public TokenValidationParameters GetTokenValidationParameters()
        => new()
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Convert.FromBase64String(_secretKey)),
            ValidIssuer = _issuer,
            ValidAudience = _audience
        };
}