using PhotoForge.Core.ValueObjects;

namespace PhotoForge.Core.Features.Galleries;

public class GalleryResource
{
    public Guid Id { get; set; } = Guid.NewGuid();
    
    public Guid GalleryId { get; private set; }
    public Gallery Gallery { get; private set; } = null!;

    public Resource PrimaryResource { get; private set; } = null!;
    public Resource? ThumbnailResource { get; private set; }

    public GalleryResource() { }

    public GalleryResource(Gallery gallery, Resource primaryResource, Resource? thumbnailResource = null)
    {
        GalleryId = gallery.Id;
        Gallery = gallery;
        PrimaryResource = primaryResource;
        ThumbnailResource = thumbnailResource;
    }
}