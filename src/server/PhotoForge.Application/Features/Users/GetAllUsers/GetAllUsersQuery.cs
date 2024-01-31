namespace PhotoForge.Application.Features.Users.GetAllUsers;

public class GetAllUsersQuery : IRequest<GetAllUsersQueryResult>
{
    public int Page { get; set; } = 0;
    public int Items { get; set; } = 10;
    public string? SearchString { get; set; }
}