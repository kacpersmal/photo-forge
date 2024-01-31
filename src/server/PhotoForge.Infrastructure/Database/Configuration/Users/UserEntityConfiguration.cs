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

        builder.OwnsOne(u => u.Email);
        
        //builder.OwnsOne(u => u.Email);
        builder.OwnsOne(u => u.Password);

    }
}