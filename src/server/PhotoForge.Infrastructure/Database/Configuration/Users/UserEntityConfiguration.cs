using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using PhotoForge.Core.Features.Users;
using PhotoForge.Core.ValueObjects;

namespace PhotoForge.Infrastructure.Database.Configuration.Users;

internal class UserEntityConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable(nameof(User), "User");
        builder.HasKey(u => u.Id);

        builder.OwnsOne(u => u.FullName);

        builder.HasIndex(u => u.Email);
        builder.Property(u => u.Email)
            .HasConversion(add => add.Address, value => new EmailAddress(value));
        
        //builder.OwnsOne(u => u.Email);
        builder.OwnsOne(u => u.Password);

    }
}