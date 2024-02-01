using MediatR;

using Microsoft.AspNetCore.Mvc;

using PhotoForge.Api.Features.Auth.Requests;
using PhotoForge.Application.Features.Auth.Dto;
using PhotoForge.Application.Features.Auth.GenerateAuthToken;

namespace PhotoForge.Api.Features.Auth;

public static class MapAuthEndpointsExtension
{
    public static void MapAuthEndpoints(this WebApplication app)
    {
        var root = app.MapGroup("auth")
            .WithTags("Auth");

        root.MapPost("", async ([FromBody] AuthorizeRequestBody request, [FromServices] IMediator mediator, HttpContext context) =>
        {
            var command = new GenerateAuthTokenCommand { Email = request.Email, Password = request.Password, };
            
            var agent = context.Request.Headers.UserAgent[0];
            if (agent is not null)
                command.UserAgent = agent;
            
            var res = await mediator.Send(command);
            return Results.Ok(res);
        })
        .Produces<AuthTokenDto>();

    }
}