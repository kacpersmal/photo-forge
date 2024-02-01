using PhotoForge.Application.Features.Galleries.Dto;
using PhotoForge.Core.Features.Galleries;

namespace PhotoForge.Application.Features.Galleries;

public class GalleryProfile : Profile
{
    public GalleryProfile()
    {
        CreateMap<Gallery, GalleryDto>()
            .ForMember(dto => dto.Slug, opt => opt.MapFrom(x => x.Slug.Value))
            .ForMember(dto => dto.Thumbnail, opt => opt.MapFrom(x => x.Resources.FirstOrDefault()!.PrimaryResource));
    }
}