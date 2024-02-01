using MediatR;
using Microsoft.AspNetCore.Mvc;
using PhotoForge.Application.Features.Users.CreateUser;
using PhotoForge.Application.Features.Users.GetAllUsers;

namespace PhotoForge.Api.Features.Users;

public static class MapUsersEndpointsExtension
{
    public static void MapUsersEndpoints(this WebApplication app)
    {
        var root = app.MapGroup("users")
            .WithTags("Users");

        root.MapPost("", CreateUser);

        root.MapGet("", GetAllUsers)
            .Produces<GetAllUsersQueryResult>()
            .RequireAuthorization(AuthPolicies.Admin);
    }

    private static async Task<IResult> GetAllUsers([AsParameters] GetAllUsersQuery query, [FromServices] IMediator mediator)
        => Results.Ok(await mediator.Send(query));

    private static async Task CreateUser([FromBody] CreateUserCommand req, [FromServices] IMediator mediator)
    {
        await mediator.Send(req);
        Results.Ok();
    }
}