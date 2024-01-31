using PhotoForge.Api.Extensions;
using PhotoForge.Api.Features.Users;
using PhotoForge.Application;
using PhotoForge.Core.Services;
using PhotoForge.Infrastructure.Database;

using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((context, configuration) =>
    configuration.ReadFrom.Configuration(context.Configuration));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.ConfigureCors();
builder.Services.AddResponseCaching();
builder.Services.AddResponseCompression();
builder.Services.AddCoreServices();
builder.Services.AddAppDbContext(builder.Configuration);
builder.Services.AddApplicationServices(builder.Configuration);
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors();

app.UseResponseCaching();
app.UseResponseCompression();

app.MapUsersEndpoints();

app.Run();