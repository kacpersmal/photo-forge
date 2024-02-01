using PhotoForge.Core.Abstractions;

namespace PhotoForge.Core.ValueObjects;

public class Token : ValueObject
{
    public string Value { get; set; } = null!;
    public DateTime ExpirationDate { get; set; }

    public Token() { }
    
    public Token(DateTime expirationDate, string value)
    {
        if (expirationDate < DateTime.UtcNow)
            throw new ArgumentException("Cannot add already expired token", nameof(expirationDate));
        
        ExpirationDate = expirationDate;
        Value = value;
    }

    public bool IsExpired()
        => ExpirationDate < DateTime.UtcNow;
    
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
        yield return ExpirationDate;
    }
}