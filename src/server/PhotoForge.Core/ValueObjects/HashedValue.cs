using PhotoForge.Core.Abstractions;

namespace PhotoForge.Core.ValueObjects;

public class HashedValue : ValueObject
{
    public byte[] Hash { get; private set; } = null!;
    public byte[] Salt { get; private set; } = null!;

    public HashedValue() { }
    public HashedValue(byte[] hash, byte[] salt)
    {
        Hash = hash ?? throw new ArgumentNullException(nameof(hash));
        Salt = salt ?? throw new ArgumentNullException(nameof(salt));
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Hash;
        yield return Salt;
    }
}