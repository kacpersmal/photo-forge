using Microsoft.EntityFrameworkCore;
using PhotoForge.Application.Exceptions;

namespace PhotoForge.Application.Features.Galleries.DeleteGallery;

public class DeleteGalleryCommandHandler(AppDbContext context) : IRequestHandler<DeleteGalleryCommand>
{
    public async Task Handle(DeleteGalleryCommand request, CancellationToken cancellationToken)
    {
        var gallery = await context.Galleries.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken: cancellationToken) 
                      ?? throw new NotFoundException($"Gallery with id: {request.Id} not found");

        context.Galleries.Remove(gallery);
        await context.SaveChangesAsync(cancellationToken);
    }
}