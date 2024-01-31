using AutoMapper;
using PhotoForge.Application.Features.Users;
using PhotoForge.Application.Features.Users.GetAllUsers;
using PhotoForge.Core.Features.Users;
using PhotoForge.Core.ValueObjects;

namespace PhotoForge.Application.Tests.Features.Users;

[TestFixture]
public class GetAllUsersQueryHandlerTests
{
    [Test]
    public async Task Handle_WhenSearchStringIsEmpty_ShouldReturnAllUsersPaged()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

        await using var context = new AppDbContext(options);
        // Seed the in-memory database with some test data
        var users = new List<User>
        {
            new(new FullName("John", "Doe"), new EmailAddress("john.doe@example.com"), new HashedValue(new byte[1], new byte[1])),
            new(new FullName("Jane", "Doe"), new EmailAddress("jane.doe@example.com"), new HashedValue(new byte[1], new byte[1])),
            new(new FullName("Bob", "Smith"), new EmailAddress("bob.smith@example.com"), new HashedValue(new byte[1], new byte[1]))
        };
        context.Users.AddRange(users);
        await context.SaveChangesAsync();

        var mapperConfig = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<UsersProfile>();
        });
        var mapper = mapperConfig.CreateMapper();
        var handler = new GetAllUsersQueryHandler(context, mapper);
        var query = new GetAllUsersQuery { Page = 0, Items = 2, SearchString = "" };

        // Act
        var result = await handler.Handle(query, CancellationToken.None);

        // Assert
        result.Users.Should().HaveCount(2);
        result.Users.Should().ContainSingle(user => user.FullName == "John Doe");
        result.Users.Should().ContainSingle(user => user.FullName == "Jane Doe");
    }

    [Test]
    public async Task Handle_WhenSearchStringIsProvided_ShouldReturnMatchingUsersPaged()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

        await using var context = new AppDbContext(options);
        // Seed the in-memory database with some test data
        var users = new List<User>
        {
            new(new FullName("John", "Doe"), new EmailAddress("john.doe@example.com"), new HashedValue(new byte[1], new byte[1])),
            new(new FullName("Jane", "Doe"), new EmailAddress("jane.doe@example.com"), new HashedValue(new byte[1], new byte[1])),
            new(new FullName("Bob", "Smith"), new EmailAddress("bob.smith@example.com"), new HashedValue(new byte[1], new byte[1]))
        };
        context.Users.AddRange(users);
        await context.SaveChangesAsync();

        var mapperConfig = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<UsersProfile>();
        });
        var mapper = mapperConfig.CreateMapper();
        var handler = new GetAllUsersQueryHandler(context, mapper);
        var query = new GetAllUsersQuery { Page = 0, Items = 2, SearchString = "Jane" };

        // Act
        var result = await handler.Handle(query, CancellationToken.None);

        // Assert
        result.Users.Should().HaveCount(1);
        result.Users.Should().ContainSingle(user => user.FullName == "Jane Doe");
    }
}