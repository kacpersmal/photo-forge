using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

using PhotoForge.Application.Exceptions;
using PhotoForge.Application.Features.Auth.Dto;
using PhotoForge.Application.Features.Auth.Services.AuthTokenHelper;
using PhotoForge.Core.Features.Auth;
using PhotoForge.Core.Services.CryptoRandomProvider;
using PhotoForge.Core.Services.Hashing;
using PhotoForge.Core.Services.TimeProvider;
using PhotoForge.Core.ValueObjects;

namespace PhotoForge.Application.Features.Auth.GenerateAuthToken;

public class GenerateAuthTokenCommandHandler(AppDbContext context, IAuthTokenHelperService tokenHelperService,IHashedValueService hashedValueService, IConfiguration config, ITimeProviderService timeProvider, ICryptoRandomProviderService randomProvider) : IRequestHandler<GenerateAuthTokenCommand, AuthTokenDto>
{
    public async Task<AuthTokenDto> Handle(GenerateAuthTokenCommand request, CancellationToken cancellationToken)
    {
        var user = await context.Users.FirstOrDefaultAsync(x => x.Email.Address == request.Email, cancellationToken) ?? throw new AuthException();
        var passwordMatch = hashedValueService.ValidateHashedValue(request.Password, user.Password);

        if (!passwordMatch)
            throw new AuthException();

        var sessionExpirationDate =
            timeProvider.GetCurrentDateTime().AddDays(config.GetValue<int>("Jwt:SessionExpiration"));

        var refreshToken = new Token(sessionExpirationDate, randomProvider.GetRandomString(64));
        
        var session = new UserSession(user, refreshToken);

        if (request.UserAgent is not null)
            session.SetUserAgent(request.UserAgent);

        var token = tokenHelperService.GenerateJwtToken(user);

        session.SetToken(token, refreshToken);

        await context.UserSessions.AddAsync(session, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
        
        return new() { Token = token, RefreshToken = refreshToken, SessionId = session.Id };
    }
}