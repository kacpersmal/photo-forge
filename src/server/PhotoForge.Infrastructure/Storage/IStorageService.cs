using PhotoForge.Infrastructure.Storage.Dto;

namespace PhotoForge.Infrastructure.Storage;

public interface IStorageService
{
    public Task<FileUploadDto> UploadFileAsync(Stream stream, string resourceName, string bucket);
}