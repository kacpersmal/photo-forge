using Microsoft.EntityFrameworkCore;

using PhotoForge.Application.Exceptions;
using PhotoForge.Core.Features.Galleries;
using PhotoForge.Core.Services.Hashing;

namespace PhotoForge.Application.Features.Galleries.CreateGallery;

internal class CreateGalleryCommandHandler(AppDbContext context, IHashedValueService hashedValueService) : IRequestHandler<CreateGalleryCommand, CreateGalleryCommandResult>
{
      public async Task<CreateGalleryCommandResult> Handle(CreateGalleryCommand request, CancellationToken cancellationToken)
    {
        ValidateGalleryName(request.Name);
        
        var gallery = new Gallery(request.Name, request.Description, request.IsPublic);

        SetAccessCodeIfProvided(request.AccessCode, gallery);
        GrantAccessToUsersIfProvided(request.UsersWithAccess, gallery, cancellationToken);

        await context.Galleries.AddAsync(gallery, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
        
        return new() { Id = gallery.Id, Slug = gallery.Slug.Value };
    }

    private void ValidateGalleryName(string name)
    {
        if (context.Galleries.Any(x => x.Name == name))
            throw new EntityConflictException("Gallery with same name already exists");
    }

    private void SetAccessCodeIfProvided(string? accessCode, Gallery gallery)
    {
        if (!string.IsNullOrWhiteSpace(accessCode))
        {
            var hashedAccessCode = hashedValueService.GenerateHashedValue(accessCode);
            gallery.SetAccessCode(hashedAccessCode);
        }
    }

    private async void GrantAccessToUsersIfProvided(IEnumerable<Guid>? usersWithAccess, Gallery gallery, CancellationToken cancellationToken)
    {
        if (usersWithAccess is not null && usersWithAccess.Any())
        {
            var users = await context.Users.Where(x => usersWithAccess.Contains(x.Id)).ToListAsync(cancellationToken);
            
            if (users.Count != 0)
                gallery.GrantAccess(users);
        }
    }
}