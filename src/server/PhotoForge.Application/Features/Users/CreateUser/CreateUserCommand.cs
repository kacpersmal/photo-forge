namespace PhotoForge.Application.Features.Users.CreateUser;

public class CreateUserCommand : IRequest
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Email { get; set; }
    public required string Password { get; set; }  
}