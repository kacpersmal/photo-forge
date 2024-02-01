using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using PhotoForge.Core.Features.Galleries;

namespace PhotoForge.Infrastructure.Database.Configuration.Galleries;

internal class GalleryResourceEntityConfiguration : IEntityTypeConfiguration<GalleryResource>
{
    public void Configure(EntityTypeBuilder<GalleryResource> builder)
    {
        builder.ToTable(nameof(GalleryResource), "Galleries");

        builder.HasKey(x => x.Id);

        builder.OwnsOne(x => x.PrimaryResource);
        builder.OwnsOne(x => x.ThumbnailResource);
    }
}