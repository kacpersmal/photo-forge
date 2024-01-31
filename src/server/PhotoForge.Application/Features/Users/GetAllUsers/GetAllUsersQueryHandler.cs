using Microsoft.EntityFrameworkCore;
using PhotoForge.Application.Features.Users.Dto;

namespace PhotoForge.Application.Features.Users.GetAllUsers;

internal class GetAllUsersQueryHandler(AppDbContext context, IMapper mapper) : IRequestHandler<GetAllUsersQuery, GetAllUsersQueryResult>
{
    public async Task<GetAllUsersQueryResult> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
    {
        var query = context.Users.AsQueryable();

        if (!string.IsNullOrWhiteSpace(request.SearchString))
            query = query.Where(x =>
                x.FullName.FirstName.Contains(request.SearchString) ||
                x.FullName.LastName.Contains(request.SearchString) || x.Email.Address.Contains(request.SearchString));

        query = query.Skip(request.Items * request.Page).Take(request.Items).AsNoTracking();
        
        return new GetAllUsersQueryResult()
        {
            Users = await mapper.ProjectTo<UserDto>(query).ToListAsync(cancellationToken)
        };
    }
}