using PhotoForge.Application.Features.Galleries.Dto;

namespace PhotoForge.Application.Features.Galleries.GetGalleries;

public class GetAllGalleriesQueryResult
{
    public IEnumerable<GalleryDto> Galleries { get; set; } = null!;
    public int GalleryCount { get; set; }
}