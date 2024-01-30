using PhotoForge.Core.ValueObjects;

namespace PhotoForge.Core.Services.Hashing;

public interface IHashedValueService
{
    HashedValue GenerateHashedValue(string plainTextPassword);
    bool ValidateHashedValue(string plainTextPassword, HashedValue hashedValue);
}