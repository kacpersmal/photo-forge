using PhotoForge.Core.Abstractions;

namespace PhotoForge.Core.ValueObjects;

public class EmailAddress : ValueObject
{
    public string Address { get; private set; } = null!;

    public EmailAddress() { }
    public EmailAddress(string address)
    {
        if (RegexUtilities.IsValidEmail(address))
            throw new ArgumentException("Email is in invalid format", nameof(address));

        Address = address;
    }
    
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Address;
    }
}