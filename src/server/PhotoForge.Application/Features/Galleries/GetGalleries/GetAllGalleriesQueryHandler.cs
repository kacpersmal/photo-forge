using Microsoft.EntityFrameworkCore;

using PhotoForge.Application.Features.Galleries.Dto;

namespace PhotoForge.Application.Features.Galleries.GetGalleries;

internal class GetAllGalleriesQueryHandler(AppDbContext context, IMapper mapper) : IRequestHandler<GetAllGalleriesQuery, GetAllGalleriesQueryResult>
{
    public async Task<GetAllGalleriesQueryResult> Handle(GetAllGalleriesQuery request, CancellationToken cancellationToken)
    {
        var query = context.Galleries
            .Include(x => x.Resources)
            .Include(x => x.UsersWithAccess)
            .AsQueryable();

        if (!string.IsNullOrWhiteSpace(request.SearchString))
            query = query.Where(x => x.Name.Contains(request.SearchString));

        if (!request.ShowPrivate)
            query = query.Where(x => x.IsPublic == true);
        
        query = query.OrderByDescending(x => x.LastUpdateDate);
        
        query = query.Skip(request.Items * request.Page).Take(request.Items).AsNoTracking();

        var dto = await mapper.ProjectTo<GalleryDto>(query).ToListAsync(cancellationToken);
        
        return new() { Galleries = dto, GalleryCount = dto.Count };
    }
}