using System.Security.Claims;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PhotoForge.Api.Features.Galleries.Requests;
using PhotoForge.Application.Features.Galleries.CreateGallery;
using PhotoForge.Application.Features.Galleries.DeleteGallery;
using PhotoForge.Application.Features.Galleries.GetGalleries;
using PhotoForge.Core.Features.Users;

namespace PhotoForge.Api.Features.Galleries;

public static class MapGalleriesEndpointsExtension
{
    public static void MapGalleriesEndpoints(this WebApplication app)
    {
        var root = app.MapGroup("galleries")
            .WithTags("Galleries");

        root.MapGet("", GetAllGalleries);
        root.MapPost("", CreateGallery).RequireAuthorization(AuthPolicies.Admin);
        root.MapDelete("{id:guid}", DeleteGallery);
    }

    private static async Task<IResult> DeleteGallery([FromRoute] Guid id, [FromServices] IMediator mediator)
    {
        await mediator.Send(new DeleteGalleryCommand { Id = id });
        return Results.Ok();
    }

    private static async Task CreateGallery([FromBody] CreateGalleryCommand command, [FromServices] IMediator mediator)
        => Results.Ok(await mediator.Send(command));

    private static async Task<IResult> GetAllGalleries([AsParameters] GetAllGalleriesRequestParams parameters, [FromServices] IMediator mediator, ClaimsPrincipal? user)
    {
        var query = new GetAllGalleriesQuery
        {
            Items = parameters.Items,
            Page = parameters.Page,
            SearchString = parameters.SearchString,
            ShowPrivate = false
        };

        if (parameters.ShowPrivate == true && user != null && user.IsInRole(nameof(UserRole.Admin))) 
            query.ShowPrivate = true;
           
        
        return Results.Ok(await mediator.Send(query));
    } 

}