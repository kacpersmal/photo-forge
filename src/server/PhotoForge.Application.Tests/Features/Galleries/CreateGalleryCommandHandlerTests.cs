using PhotoForge.Application.Features.Galleries.CreateGallery;
using PhotoForge.Core.Features.Galleries;
using PhotoForge.Core.Features.Users;
using PhotoForge.Core.Services.Hashing;
using PhotoForge.Core.ValueObjects;

namespace PhotoForge.Application.Tests;

[TestFixture]
public class CreateGalleryCommandHandlerTests
{
 private CreateGalleryCommandHandler _handler;
    private AppDbContext _context;
    private Mock<IHashedValueService> _hashedValueServiceMock;

    [SetUp]
    public void SetUp()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

        _context = new AppDbContext(options);
        _hashedValueServiceMock = new Mock<IHashedValueService>();
        _handler = new CreateGalleryCommandHandler(_context, _hashedValueServiceMock.Object);
    }

    [TearDown]
    public void TearDown()
    {
        _context.Database.EnsureDeleted();
    }

    [Test]
    public async Task Handle_WhenGalleryNameExists_ThrowsEntityConflictException()
    {
        // Arrange
        var existingGallery = new Gallery("Existing Name", "Description", true);
        _context.Galleries.Add(existingGallery);
        _context.SaveChanges();

        var command = new CreateGalleryCommand
        {
            Name = "Existing Name",
            Description = "New Description",
            IsPublic = false
        };

        // Act
        Func<Task> act = async () => await _handler.Handle(command, CancellationToken.None);

        // Assert
        await act.Should().ThrowAsync<EntityConflictException>().WithMessage("Gallery with same name already exists");
    }

    [Test]
    public async Task Handle_WhenGalleryNameDoesNotExist_DoesNotThrowException()
    {
        // Arrange
        var command = new CreateGalleryCommand
        {
            Name = "New Name",
            Description = "New Description",
            IsPublic = false
        };

        // Act
        Func<Task> act = async () => await _handler.Handle(command, CancellationToken.None);

        // Assert
        await act.Should().NotThrowAsync<EntityConflictException>();
    }

    [Test]
    public async Task Handle_WhenAccessCodeIsNotProvided_DoesNotSetAccessCode()
    {
        // Arrange
        var command = new CreateGalleryCommand
        {
            Name = "New Name",
            Description = "New Description",
            IsPublic = false
        };

        // Act
        var result = await _handler.Handle(command, CancellationToken.None);

        // Assert
        var gallery = _context.Galleries.Find(result.Id);
        gallery?.AccessCode.Should().BeNull();
    }

    [Test]
    public async Task Handle_WhenUsersAreNotProvided_DoesNotGrantAccessToUsers()
    {
        // Arrange
        var command = new CreateGalleryCommand
        {
            Name = "New Name",
            Description = "New Description",
            IsPublic = false
        };

        // Act
        var result = await _handler.Handle(command, CancellationToken.None);

        // Assert
        var gallery = _context.Galleries.Include(g => g.UsersWithAccess).Single(g => g.Id == result.Id);
        gallery.UsersWithAccess.Should().BeEmpty();
    }
}
