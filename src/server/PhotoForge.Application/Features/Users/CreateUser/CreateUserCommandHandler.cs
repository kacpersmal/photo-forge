using Microsoft.EntityFrameworkCore;
using PhotoForge.Application.Exceptions;
using PhotoForge.Core.Features.Users;
using PhotoForge.Core.Services.Hashing;
using PhotoForge.Core.ValueObjects;

namespace PhotoForge.Application.Features.Users.CreateUser;

internal class CreateUserCommandHandler(AppDbContext context, IHashedValueService hashedValueService) : IRequestHandler<CreateUserCommand>
{
    public async Task Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var userExists = await context.Users.AnyAsync(x => x.Email.Address == request.Email, cancellationToken);

        if (userExists)
            throw new EntityConflictException("User with given email already exists");

        var passwordHash = hashedValueService.GenerateHashedValue(request.Password);

        var user = new User(
            new FullName(request.FirstName, request.LastName),
            new EmailAddress(request.Email),
            passwordHash
            );

        await context.Users.AddAsync(user, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
    }
}