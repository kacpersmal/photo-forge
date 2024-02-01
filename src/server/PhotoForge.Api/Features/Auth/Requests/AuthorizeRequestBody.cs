namespace PhotoForge.Api.Features.Auth.Requests;

public class AuthorizeRequestBody
{
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
}