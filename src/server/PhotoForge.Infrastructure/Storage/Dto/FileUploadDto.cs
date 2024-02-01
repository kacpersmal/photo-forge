using PhotoForge.Core.ValueObjects;

namespace PhotoForge.Infrastructure.Storage.Dto;

public class FileUploadDto
{
    public Resource ResourceRef { get; set; } = null!;
    public string Url { get; set; } = null!;
    public int UploadTime { get; set; }
    public ulong? FileSize { get; set; }
}