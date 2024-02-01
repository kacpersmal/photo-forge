using PhotoForge.Application.Features.Auth.Dto;

namespace PhotoForge.Application.Features.Auth.GenerateAuthToken;

public class GenerateAuthTokenCommand : IRequest<AuthTokenDto>
{
    public required string Email { get; set; }
    public required string Password { get; set; }
    public string? UserAgent { get; set; }
}