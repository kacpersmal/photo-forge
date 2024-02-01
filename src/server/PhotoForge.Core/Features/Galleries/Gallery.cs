using PhotoForge.Core.Abstractions;
using PhotoForge.Core.Features.Users;
using PhotoForge.Core.ValueObjects;

namespace PhotoForge.Core.Features.Galleries;

public class Gallery : IRoot
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    
    public bool IsPublic { get; private set; }
    public string Name { get; private set; } = null!;
    public string Description { get; private set; } = null!;
    public IEnumerable<GalleryResource> Resources { get; private set; } = Enumerable.Empty<GalleryResource>();

    public IEnumerable<User> UsersWithAccess { get; private set; } = Enumerable.Empty<User>();
    public HashedValue? AccessCode { get; private set; }
    
    public DateTime CreationDate { get; private set; } = DateTime.UtcNow;
    public DateTime LastUpdateDate { get; private set; } = DateTime.UtcNow;
    
    public Gallery() { }

    public Gallery(string name, string description, bool isPublic = false)
    {
        Name = name;
        Description = description;
        IsPublic = isPublic;
    }

    public Gallery GrantAccess(IEnumerable<User> users)
    {
        UsersWithAccess = UsersWithAccess.Concat(users);
        LastUpdateDate = DateTime.UtcNow;
        return this;
    }

    public Gallery RevokeAccess(IEnumerable<User> users)
    {
        UsersWithAccess = UsersWithAccess.Except(users);
        LastUpdateDate = DateTime.UtcNow;
        return this;
    }

    public Gallery RevokeAllAccess()
    {
        UsersWithAccess = Enumerable.Empty<User>();
        LastUpdateDate = DateTime.UtcNow;
        return this;
    }

    public Gallery SetAccessCode(HashedValue code)
    {
        AccessCode = code;
        LastUpdateDate = DateTime.UtcNow;
        return this;
    }

    public Gallery RemoveAccessCode()
    {
        AccessCode = null;
        LastUpdateDate = DateTime.UtcNow;
        return this;
    }

    public Gallery SetName(string name)
    {
        Name = name;
        return this;
    }

    public Gallery SetDescription(string description)
    {
        Description = description;
        LastUpdateDate = DateTime.UtcNow;
        return this;
    }

    public Gallery AddResources(IEnumerable<GalleryResource> resources)
    {
        Resources = Resources.Concat(resources);
        LastUpdateDate = DateTime.UtcNow;
        return this;
    }

    public Gallery RemoveResources(IEnumerable<GalleryResource> resources)
    {
        Resources = Resources.Except(resources);
        LastUpdateDate = DateTime.UtcNow;
        return this;
    }
}