using PhotoForge.Core.Services.Hashing;
using PhotoForge.Core.ValueObjects;

namespace PhotoForge.Core.Tests.Services;

[TestFixture]
public class HashedValueServiceTests
{
    private IHashedValueService _hashedValueService = null!;

    [SetUp]
    public void SetUp()
    {
        _hashedValueService = new HashedValueService();
    }

    [Test]
    public void GenerateHashedValue_ShouldGenerateValidHashedValue()
    {
        // Arrange
        string plainTextPassword = "testPassword";

        // Act
        HashedValue hashedValue = _hashedValueService.GenerateHashedValue(plainTextPassword);

        // Assert
        hashedValue.Hash.Should().NotBeNullOrEmpty();
        hashedValue.Salt.Should().NotBeNullOrEmpty();
    }

    [Test]
    public void ValidateHashedValue_ShouldReturnTrueForValidPassword()
    {
        // Arrange
        string plainTextPassword = "testPassword";
        HashedValue hashedValue = _hashedValueService.GenerateHashedValue(plainTextPassword);

        // Act
        bool isValid = _hashedValueService.ValidateHashedValue(plainTextPassword, hashedValue);

        // Assert
        isValid.Should().BeTrue();
    }

    [Test]
    public void ValidateHashedValue_ShouldReturnFalseForInvalidPassword()
    {
        // Arrange
        string validPassword = "testPassword";
        string invalidPassword = "wrongPassword";
        HashedValue hashedValue = _hashedValueService.GenerateHashedValue(validPassword);

        // Act
        bool isValid = _hashedValueService.ValidateHashedValue(invalidPassword, hashedValue);

        // Assert
        isValid.Should().BeFalse();
    }

    [Test]
    public void ValidateHashedValue_ShouldReturnFalseForModifiedHash()
    {
        // Arrange
        string plainTextPassword = "testPassword";
        HashedValue hashedValue = _hashedValueService.GenerateHashedValue(plainTextPassword);
        hashedValue.Hash[0] = (byte)(hashedValue.Hash[0] ^ 0xFF); // Modify the hash

        // Act
        bool isValid = _hashedValueService.ValidateHashedValue(plainTextPassword, hashedValue);

        // Assert
        isValid.Should().BeFalse();
    }

    [Test]
    public void ValidateHashedValue_ShouldReturnFalseForModifiedSalt()
    {
        // Arrange
        string plainTextPassword = "testPassword";
        HashedValue hashedValue = _hashedValueService.GenerateHashedValue(plainTextPassword);
        hashedValue.Salt[0] = (byte)(hashedValue.Salt[0] ^ 0xFF); // Modify the salt

        // Act
        bool isValid = _hashedValueService.ValidateHashedValue(plainTextPassword, hashedValue);

        // Assert
        isValid.Should().BeFalse();
    }
}