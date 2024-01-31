using PhotoForge.Application.Features.Users.Dto;

namespace PhotoForge.Application.Features.Users.GetAllUsers;

public class GetAllUsersQueryResult
{
    public required List<UserDto> Users { get; set; }
}