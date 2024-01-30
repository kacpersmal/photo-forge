using PhotoForge.Api.Extensions;
using PhotoForge.Core.Services;
using PhotoForge.Infrastructure.Database;

using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((context, configuration) =>
    configuration.ReadFrom.Configuration(context.Configuration));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.ConfigureCors();

builder.Services.AddCoreServices();
builder.Services.AddAppDbContext(builder.Configuration);

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

app.Run();