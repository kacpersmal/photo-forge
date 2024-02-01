namespace PhotoForge.Application.Features.Galleries.CreateGallery;

public class CreateGalleryCommand : IRequest<CreateGalleryCommandResult>
{
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required bool IsPublic { get; set; }
    public string? AccessCode { get; set; }
    public IEnumerable<Guid>? UsersWithAccess { get; set; }
}