using PhotoForge.Application.Features.Auth.Dto;

namespace PhotoForge.Application.Features.Auth.RefreshToken;

public class RefreshTokenCommand : IRequest<AuthTokenDto>
{
    public string RefreshToken { get; set; } = null!;
}