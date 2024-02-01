using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using PhotoForge.Core.Features.Galleries;

namespace PhotoForge.Infrastructure.Database.Configuration.Galleries;

internal class GalleryEntityConfiguration : IEntityTypeConfiguration<Gallery>
{
    public void Configure(EntityTypeBuilder<Gallery> builder)
    {
        builder.ToTable(nameof(Gallery), "Galleries");

        builder.HasKey(x => x.Id);
        builder.OwnsOne(x => x.Slug);
        builder.OwnsOne(x => x.AccessCode);

        builder
            .HasMany(x => x.Resources)
            .WithOne(x => x.Gallery)
            .HasForeignKey(x => x.GalleryId)
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .HasMany(x => x.UsersWithAccess)
            .WithMany();
    }
}