namespace PhotoForge.Core.Services.Hashing;

public interface IHashedValueService
{
    ValueObjects.HashedValue GenerateHashedValue(string plainTextValue);
    bool ValidateHashedValue(string plainTextValue, ValueObjects.HashedValue hashedValue);
}