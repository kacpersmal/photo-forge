using PhotoForge.Core.ValueObjects;

namespace PhotoForge.Core.Tests.ValueObjects;

[TestFixture]
public class ResourceTests
{
    [Test]
    public void Constructor_WithValidPath_SetsPropertiesCorrectly()
    {
        // Arrange
        var path = "folder1/folder2/folder3/example.jpeg";

        // Act
        var resource = new Resource(path);

        // Assert
        resource.Name.Should().Be("example.jpeg");
        resource.Location.Should().Be("folder1/folder2/folder3");
        resource.DisplayName.Should().Be("example.jpeg");
    }

    [Test]
    public void GetResourcePath_ReturnsCorrectPath()
    {
        // Arrange
        var resource = new Resource("example.jpeg", "folder1/folder2/folder3", "CustomDisplayName");

        // Act
        var result = resource.GetResourcePath();

        // Assert
        result.Should().Be("folder1/folder2/folder3/example.jpeg");
    }
    
    [Test]
    public void Constructor_WithNameContainingInvalidCharacters_ThrowsArgumentException()
    {
        // Arrange
        var name = "example/invalid.jpeg";
        var location = "folder1/folder2/folder3";

        // Act & Assert
        Assert.Throws<ArgumentException>(() => new Resource(name, location));
    }

    [Test]
    public void Constructor_WithNameWithoutExtension_ThrowsArgumentException()
    {
        // Arrange
        var name = "example";
        var location = "folder1/folder2/folder3";

        // Act & Assert
        Assert.Throws<ArgumentException>(() => new Resource(name, location));
    }

    [Test]
    public void Constructor_WithInvalidLocation_ThrowsArgumentException()
    {
        // Arrange
        var name = "example.jpeg";
        var location = "folder1//folder2/folder3";

        // Act & Assert
        Assert.Throws<ArgumentException>(() => new Resource(name, location));
    }
    
    [Test]
    public void AddSuffixToName_WithValidSuffix_AddsSuffixCorrectly()
    {
        // Arrange
        var resource = new Resource("example.jpeg", "folder1/folder2/folder3");
        var suffix = "123";

        // Act
        resource.AddSuffixToName(suffix);

        // Assert
        resource.Name.Should().Be("example-123.jpeg");
    }

    [Test]
    public void AddSuffixToName_WithSuffixContainingSpaces_ReplacesSpacesWithDashes()
    {
        // Arrange
        var resource = new Resource("example.jpeg", "folder1/folder2/folder3");
        var suffix = "1 2 3";

        // Act
        resource.AddSuffixToName(suffix);

        // Assert
        resource.Name.Should().Be("example-1-2-3.jpeg");
    }

    [Test]
    public void AddSuffixToName_WithWhitespaceSuffix_ThrowsArgumentException()
    {
        // Arrange
        var resource = new Resource("example.jpeg", "folder1/folder2/folder3");

        // Act & Assert
        Assert.Throws<ArgumentException>(() => resource.AddSuffixToName(" "));
    }
    
    [Test]
    public void GetContentType_WithJpegExtension_ReturnsCorrectContentType()
    {
        // Arrange
        var resource = new Resource("example.jpeg", "folder1/folder2/folder3");

        // Act
        var result = resource.GetContentType();

        // Assert
        result.Should().Be("image/jpeg");
    }

    [Test]
    public void GetContentType_WithPngExtension_ReturnsCorrectContentType()
    {
        // Arrange
        var resource = new Resource("example.png", "folder1/folder2/folder3");

        // Act
        var result = resource.GetContentType();

        // Assert
        result.Should().Be("image/png");
    }

    [Test]
    public void GetContentType_WithMp4Extension_ReturnsCorrectContentType()
    {
        // Arrange
        var resource = new Resource("example.mp4", "folder1/folder2/folder3");

        // Act
        var result = resource.GetContentType();

        // Assert
        result.Should().Be("video/mp4");
    }

    [Test]
    public void GetContentType_WithUnknownExtension_ReturnsDefaultContentType()
    {
        // Arrange
        var resource = new Resource("example.unknown", "folder1/folder2/folder3");

        // Act
        var result = resource.GetContentType();

        // Assert
        result.Should().Be("application/octet-stream");
    }
}