using PhotoForge.Core.Abstractions;

namespace PhotoForge.Core.ValueObjects;

public class HashedValue(byte[] hash, byte[] salt) : ValueObject
{
    public byte[] Hash { get; private set; } = hash ?? throw new ArgumentNullException(nameof(hash));
    public byte[] Salt { get; private set; } = salt ?? throw new ArgumentNullException(nameof(salt));

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Hash;
        yield return Salt;
    }
}