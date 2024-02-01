using System.Text.RegularExpressions;

using PhotoForge.Core.Abstractions;

namespace PhotoForge.Core.ValueObjects;

public class Slug : ValueObject
{
    public string Value { get; private set; } = null!;

    public Slug() {}
    public Slug(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
        {
            throw new ArgumentException("Input cannot be null or empty.", nameof(input));
        }

        // Convert input to lowercase and replace invalid characters with hyphens
        Value = ConvertToSlug(input);
    }

    private string ConvertToSlug(string input)
    {
        // Convert to lowercase
        string slug = input.ToLowerInvariant();

        // Replace invalid characters with hyphens
        slug = Regex.Replace(slug, @"[^a-z0-9\s-]", "");
        slug = Regex.Replace(slug, @"\s+", " ").Trim();
        slug = slug.Replace(" ", "-");

        return slug;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    public override string ToString()
    {
        return Value;
    }
}