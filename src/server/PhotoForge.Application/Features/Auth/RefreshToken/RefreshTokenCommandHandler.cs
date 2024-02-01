using Microsoft.EntityFrameworkCore;

using PhotoForge.Application.Exceptions;
using PhotoForge.Application.Features.Auth.Dto;
using PhotoForge.Application.Features.Auth.Services.AuthTokenHelper;

namespace PhotoForge.Application.Features.Auth.RefreshToken;

public class RefreshTokenCommandHandler(AppDbContext context, IAuthTokenHelperService tokenHelper) : IRequestHandler<RefreshTokenCommand, AuthTokenDto>
{
    public async Task<AuthTokenDto> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
    {
        var session = await context.UserSessions
            .Include(x => x.User)
            .FirstOrDefaultAsync(x => x.RefreshToken.Value == request.RefreshToken, cancellationToken);

        if (session is null || session.RefreshToken.IsExpired())
            throw new AuthException();

        var newToken = tokenHelper.GenerateJwtToken(session.User);

        session.SetToken(newToken, session.RefreshToken);
        await context.SaveChangesAsync(cancellationToken);
        
        return new() { RefreshToken = session.RefreshToken, Token = newToken, SessionId = session.Id };
    }
}