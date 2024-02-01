using Microsoft.OpenApi.Models;

using PhotoForge.Api.Extensions;
using PhotoForge.Api.Features.Auth;
using PhotoForge.Api.Features.Users;
using PhotoForge.Application;
using PhotoForge.Core.Services;
using PhotoForge.Infrastructure.Database;

using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((context, configuration) =>
    configuration.ReadFrom.Configuration(context.Configuration));

builder.Services.AddEndpointsApiExplorer();
builder.Services.ConfigureSwagger();
builder.Services.ConfigureCors();
builder.Services.AddResponseCaching();
builder.Services.AddResponseCompression();
builder.Services.AddCoreServices();
builder.Services.AddAppDbContext(builder.Configuration);
builder.Services.AddApplicationServices(builder.Configuration);

builder.ConfigureAuthorization();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors();

//app.UseMiddleware<JwtMiddleware>();
//app.UseAuthorization();



app.UseResponseCaching();
app.UseResponseCompression();

app.MapUsersEndpoints();
app.MapAuthEndpoints();
app.Run();