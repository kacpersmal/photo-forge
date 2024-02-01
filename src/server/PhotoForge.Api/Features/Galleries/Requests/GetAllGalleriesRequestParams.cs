using System.ComponentModel;

namespace PhotoForge.Api.Features.Galleries.Requests;

public class GetAllGalleriesRequestParams
{
    [DefaultValue(0)]
    public int Page { get; set; }
    
    [DefaultValue(10)]
    public int Items { get; set; }
    public string? SearchString { get; set; }
    public bool? ShowPrivate { get; set; }
}