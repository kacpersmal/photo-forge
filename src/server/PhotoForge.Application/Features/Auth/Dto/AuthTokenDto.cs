using PhotoForge.Core.ValueObjects;

namespace PhotoForge.Application.Features.Auth.Dto;

public class AuthTokenDto
{
    public Guid SessionId { get; set; }
    public required Token RefreshToken { get; set; }
    public required Token Token { get; set; }
}