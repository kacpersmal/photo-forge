using PhotoForge.Core.ValueObjects;

namespace PhotoForge.Application.Features.Galleries.Dto;

public class GalleryDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public bool IsPublic { get; set; }
    public string Slug { get; set; } = null!;
    public Resource? Thumbnail { get; set; } = null!;
    public int NumberOfResources { get; set; }
    public DateTime CreationDate { get; set; }
    public DateTime UpdateDate { get; set; }
}