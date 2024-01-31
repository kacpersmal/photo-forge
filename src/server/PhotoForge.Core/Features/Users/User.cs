using PhotoForge.Core.Abstractions;
using PhotoForge.Core.ValueObjects;

namespace PhotoForge.Core.Features.Users;

public class User : IRoot
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    
    public UserRole Role { get; set; }
    public EmailAddress Email { get; private set; } = null!;
    public FullName FullName { get; private set; } = null!;
    public HashedValue Password { get; private set; } = null!;
    
    public User() { }

    public User(FullName fullName, EmailAddress email, HashedValue password)
    {
        Email = email;
        FullName = fullName;
        Password = password;
    }

    public User SetEmail(EmailAddress newAddress)
    {
        Email = newAddress;
        return this;
    }

    public User SetFullname(FullName newName)
    {
        FullName = newName;
        return this;
    }
    
    public User SetPassword(HashedValue newPassword)
    {
        Password = newPassword;
        return this;
    }
    
    public User SetRole(UserRole role)
    {
        Role = role;
        return this;
    } 
}