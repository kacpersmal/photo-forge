using PhotoForge.Application.Features.Users.CreateUser;
using PhotoForge.Core.Features.Users;
using PhotoForge.Core.Services.Hashing;
using PhotoForge.Core.ValueObjects;

namespace PhotoForge.Application.Tests.Features.Users;

[TestFixture]
public class CreateUserCommandHandlerTests
{
    [Test]
    public async Task Handle_WhenUserDoesNotExist_ShouldCreateUserAndSaveChanges()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

        using (var context = new AppDbContext(options))
        {
            var hashedValueService = new Mock<IHashedValueService>();
            var handler = new CreateUserCommandHandler(context, hashedValueService.Object);

            var createUserCommand = new CreateUserCommand
            {
                FirstName = "John",
                LastName = "Doe",
                Email = "john.doe@example.com",
                Password = "password123"
            };

            // Act
            await handler.Handle(createUserCommand, CancellationToken.None);

            // Assert
            var user = await context.Users.SingleOrDefaultAsync();
            user.Should().NotBeNull();
            user?.Email.Address.Should().Be(createUserCommand.Email);
        }
    }

    [Test]
    public async Task Handle_WhenUserExists_ShouldThrowEntityConflictException()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

        using (var context = new AppDbContext(options))
        {
            var hashedValueService = new Mock<IHashedValueService>();
            var handler = new CreateUserCommandHandler(context, hashedValueService.Object);

            var createUserCommand = new CreateUserCommand
            {
                FirstName = "John",
                LastName = "Doe",
                Email = "john.doe@example.com",
                Password = "password123"
            };

            // Add a user to the in-memory database to simulate an existing user
            var existingUser = new User(new FullName("Existing", "User"), new EmailAddress(createUserCommand.Email), new HashedValue(new byte[1], new byte[1]));
            context.Users.Add(existingUser);
            await context.SaveChangesAsync();

            // Act
            Func<Task> act = async () => await handler.Handle(createUserCommand, CancellationToken.None);

            // Assert
            await act.Should().ThrowAsync<EntityConflictException>();
        }
    }
}