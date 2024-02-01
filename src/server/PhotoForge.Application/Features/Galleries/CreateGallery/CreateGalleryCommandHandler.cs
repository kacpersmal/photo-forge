using Microsoft.EntityFrameworkCore;

using PhotoForge.Application.Exceptions;
using PhotoForge.Core.Features.Galleries;
using PhotoForge.Core.Services.Hashing;

namespace PhotoForge.Application.Features.Galleries.CreateGallery;

internal class CreateGalleryCommandHandler(AppDbContext context, IHashedValueService hashedValueService) : IRequestHandler<CreateGalleryCommand, CreateGalleryCommandResult>
{
    public async Task<CreateGalleryCommandResult> Handle(CreateGalleryCommand request, CancellationToken cancellationToken)
    {
        if (context.Galleries.Any(x => x.Name == request.Name))
            throw new EntityConflictException("Gallery with same name already exists");
        
        var gallery = new Gallery(request.Name, request.Description, request.IsPublic);

        if (!string.IsNullOrWhiteSpace(request.AccessCode))
        {
            var hashedAccessCode = hashedValueService.GenerateHashedValue(request.AccessCode);
            gallery.SetAccessCode(hashedAccessCode);
        }

        if (request.UsersWithAccess is not null && request.UsersWithAccess.Any())
        {
            var users = await context.Users.Where(x => request.UsersWithAccess.Contains(x.Id)).ToListAsync(cancellationToken);
            
            if (users.Count != 0)
                gallery.GrantAccess(users);
        }

        await context.Galleries.AddAsync(gallery, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
        
        return new() { Id = gallery.Id, Slug = gallery.Slug.Value };
    }
}