namespace PhotoForge.Application.Features.Galleries.GetGalleries;

public class GetAllGalleriesQuery : IRequest<GetAllGalleriesQueryResult>
{
    public int Page { get; set; } = 0;
    public int Items { get; set; } = 10;
    public bool ShowPrivate { get; set; }
    public string? SearchString { get; set; }
}