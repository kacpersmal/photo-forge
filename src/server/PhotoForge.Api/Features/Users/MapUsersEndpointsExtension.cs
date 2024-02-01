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

        root.MapPost("", async ([FromBody] CreateUserCommand req, [FromServices] IMediator mediator) =>
        {
            await mediator.Send(req);
            Results.Ok();
        });

        root.MapGet("", async ([AsParameters] GetAllUsersQuery query, [FromServices] IMediator mediator) 
                => Results.Ok(await mediator.Send(query)))
            .Produces<GetAllUsersQueryResult>()
            .RequireAuthorization(AuthPolicies.Admin);
    }
}