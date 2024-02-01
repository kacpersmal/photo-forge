namespace PhotoForge.Application.Features.Galleries.DeleteGallery;

public class DeleteGalleryCommand : IRequest
{
    public Guid Id { get; set; }
}