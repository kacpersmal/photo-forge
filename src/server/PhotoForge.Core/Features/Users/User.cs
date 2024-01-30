using PhotoForge.Core.Abstractions;
using PhotoForge.Core.ValueObjects;

namespace PhotoForge.Core.Features.Users;

public class User : IRoot
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    
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

    public void SetEmail(EmailAddress newAddress)
        => Email = newAddress;
    
    public void SetFullname(FullName newName)
        => FullName = newName;
    
    public void SetPassword(HashedValue newPassword)
        => Password = newPassword;
}