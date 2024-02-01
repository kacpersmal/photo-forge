using PhotoForge.Core.Abstractions;

namespace PhotoForge.Core.ValueObjects;

public class Resource : ValueObject
{
    public string Name { get; private set; } = null!;
    public string DisplayName { get; private set; } = null!;
    public string Location { get; private set; } = null!;

    public Resource() {}
    
    public Resource(string path)
    {
        var parts = path.Split("/");
        var location = string.Join("/", parts.Take(parts.Length - 1));
        var name = parts.Last();
        AssignProperties(name,location);
    }

    public Resource(string name, string location, string? displayName = null)
        => AssignProperties(name, location, displayName);
    
    public string GetResourcePath()
        => $"{Location}/{Name}";
    
    public string GetContentType()
    {
        var extension = Path.GetExtension(Name).ToLower();

        return extension switch
        {
            ".jpeg" or ".jpg" => "image/jpeg",
            ".png" => "image/png",
            ".gif" => "image/gif",
            ".bmp" => "image/bmp",
            ".webp" => "image/webp",
            ".mp4" => "video/mp4",
            ".webm" => "video/webm",
            ".ogg" => "video/ogg",
            _ => "application/octet-stream",// Default content type for unknown file types
        };
    }
    
    public void AddSuffixToName(string suffix)
    {
        if (string.IsNullOrWhiteSpace(suffix))
            throw new ArgumentException("Suffix cannot be null or whitespace.", nameof(suffix));

        suffix = suffix.Replace(" ", "-");

        var nameWithoutExtension = Path.GetFileNameWithoutExtension(Name);
        var extension = Path.GetExtension(Name);

        Name = $"{nameWithoutExtension}-{suffix}{extension}";
    }
    
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Name;
        yield return DisplayName;
        yield return Location;
    }

    private void AssignProperties(string name, string location, string? displayName = null)
    {
        if (string.IsNullOrWhiteSpace(name) || 
            Path.GetExtension(name) == string.Empty || 
            name.IndexOfAny(Path.GetInvalidFileNameChars()) >= 0)
        {
            throw new ArgumentException("Invalid name. Name should not contain any slashes, backslashes and it should have an extension.", nameof(name));
        }

        var locationParts = location.Split('/');
        if (locationParts.Any(string.IsNullOrWhiteSpace))
        {
            throw new ArgumentException("Invalid location. Location should be a valid path.", nameof(location));
        }
        
        Name = name;
        Location = location;
        DisplayName = displayName ?? name;
    }
}