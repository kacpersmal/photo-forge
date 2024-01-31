using PhotoForge.Core.Abstractions;

namespace PhotoForge.Core.ValueObjects;

public class FullName : ValueObject
{
    public string FirstName { get; private set; } = null!;
    public string LastName { get; private set; } = null!;
    public string Name => $"{FirstName} {LastName}";

    public FullName() { }

    public FullName(string firstName, string lastName)
    {
        if (string.IsNullOrWhiteSpace(firstName))
            throw new ArgumentException("Invalid firstName", nameof(firstName));
        
        if(string.IsNullOrWhiteSpace(lastName))
            throw new ArgumentException("Invalid lastName", nameof(firstName));
        
        FirstName = firstName;
        LastName = lastName;
    }
    
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return FirstName;
        yield return LastName;
    }
}