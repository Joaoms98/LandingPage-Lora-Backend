using LandingPage.Lora.Domain.Interfaces.Services;
using Microsoft.Extensions.Configuration;

namespace LandingPage.Lora.Infrastructure.Services;

public class LocalFileService : IFileService
{
    protected readonly IConfiguration _configuration;

    /// <summary>
    /// Constructor method
    /// </summary>
    /// <param name="configuration"></param>
    public LocalFileService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    /// <summary>
    /// Upload the file to storage
    /// </summary>
    /// <param name="stream"></param>
    /// <param name="containerName"></param>
    /// <param name="fileName"></param>
    /// <param name="contentType"></param>
    /// <param name="suffix"></param>
    /// <param name="fixedTime"></param>
    /// <returns>Returns the file url</returns>
    public Task<string> UploadAsync(Stream stream, string containerName, string fileName, string contentType, string suffix = "", string fixedTime = "")
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Upload the file to storage
    /// </summary>
    /// <param name="stream"></param>
    /// <param name="containerName"></param>
    /// <param name="fileName"></param>
    /// <returns>Returns the file url</returns>
    public string Upload(Stream stream, string containerName, string fileName)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Delete the file from storage
    /// </summary>
    /// <param name="containerName"></param>
    /// <param name="fileName"></param>
    public Task<bool> DeleteAsync(string containerName, string fileName)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Delete the file from storage
    /// </summary>
    /// <param name="containerName"></param>
    /// <param name="fileName"></param>
    public void Delete(string containerName, string fileName)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Get file path to storage
    /// </summary>
    /// <param name="folder"></param>
    /// <param name="fileName"></param>
    /// <returns>Returns the file url</returns>
    public string GetPath(string folder, string fileName)
    {
        return Path.Combine(
            _configuration["BaseUrl"].TrimEnd('/'),
            "images",
            folder.Trim('/'),
            fileName.Trim('/')
        )
        .Replace("\\", "/");
    }

    /// <summary>
    /// Get the file from storage
    /// </summary>
    /// <param name="containerName"></param>
    /// <param name="fileName"></param>
    public Task<Stream> GetAsync(string containerName, string fileName)
    {
        throw new NotImplementedException();
    }
}