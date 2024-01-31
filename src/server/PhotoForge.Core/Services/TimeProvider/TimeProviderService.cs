namespace PhotoForge.Core.Services.TimeProvider;

internal sealed class TimeProviderService : ITimeProviderService
{
    public DateTime GetCurrentDateTime()
        => DateTime.UtcNow;
}