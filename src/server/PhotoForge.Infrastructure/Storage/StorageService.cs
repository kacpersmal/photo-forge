using System.Diagnostics;
using Google.Cloud.Storage.V1;
using Microsoft.Extensions.Logging;
using PhotoForge.Core.ValueObjects;
using PhotoForge.Infrastructure.Storage.Dto;

namespace PhotoForge.Infrastructure.Storage;

internal sealed class StorageService(ILogger<StorageService> logger) : IStorageService
{

    public async Task<FileUploadDto> UploadFileAsync(Stream stream, string resourceName, string bucket)
    {
        logger.LogInformation($"Started uploading resource: {resourceName} to bucket: {bucket}");
        
        var stopwatch = new Stopwatch();
        stopwatch.Start();
        
        var resourceRef = new Resource(resourceName, "uploads");
        resourceRef.AddSuffixToName(Guid.NewGuid().ToString());
        
        var storage = await StorageClient.CreateAsync();
        
        var bucketObj = await storage.UploadObjectAsync(bucket, resourceRef.GetResourcePath(), resourceRef.GetContentType(), stream);
        
        stopwatch.Stop();
        logger.LogInformation($"Finished uploading resource: {resourceName} to bucket: {bucket} in {stopwatch.Elapsed.Seconds}s");
        
        return new()
        {
            ResourceRef = resourceRef,
            Url = bucketObj.MediaLink,
            FileSize = bucketObj.Size,
            UploadTime = stopwatch.Elapsed.Seconds
        };
    }
}