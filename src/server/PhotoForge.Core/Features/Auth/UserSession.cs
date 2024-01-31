using PhotoForge.Core.Features.Users;

namespace PhotoForge.Core.Features.Auth;

public class UserSession
{
    public Guid Id { get; private set; } = Guid.NewGuid();

    public string RefreshToken { get; private set; } = null!;
    public string Token { get; private set; } = null!;

    public Guid UserId { get; private set; }
    public User User { get; private set; } = null!;

    public string? UserAgent { get; private set; }
    public DateTime CreationDate { get; private set; }
    public DateTime LastRefresh { get; private set; }

    public UserSession() { }

    public UserSession(User user, string refreshToken)
    {
        User = user;
        UserId = user.Id;
        RefreshToken = refreshToken;
        CreationDate = DateTime.UtcNow;
    }
    
    public UserSession SetToken(string token, string refreshToken)
    {
        if (refreshToken != RefreshToken)
            throw new ArgumentException("Refresh token does not match", nameof(refreshToken));
        
        Token = token;
        LastRefresh = DateTime.UtcNow;
        return this;
    }

    public UserSession SetUserAgent(string userAgent)
    {
        UserAgent = userAgent;
        return this;
    }
}