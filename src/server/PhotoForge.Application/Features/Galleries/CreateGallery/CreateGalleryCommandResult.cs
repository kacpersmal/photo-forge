namespace PhotoForge.Application.Features.Galleries.CreateGallery;

public class CreateGalleryCommandResult
{
    public Guid Id { get; set; }
    public string Slug { get; set; } = null!;
}