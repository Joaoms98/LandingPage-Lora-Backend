using System.Text.RegularExpressions;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using LandingPage.Lora.Core.Utils;
using LandingPage.Lora.Domain.Interfaces.Services;
using Microsoft.Extensions.Configuration;

namespace LandingPage.Lora.Infrastructure.Services;

public class AzureFileService : IFileService
{
    protected readonly IConfiguration _configuration;

    /// <summary>
    /// Constructor method
    /// </summary>
    /// <param name="configuration"></param>
    public AzureFileService(IConfiguration configuration)
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
    public async Task<string> UploadAsync(Stream stream, string containerName, string fileName, string contentType, string suffix = "", string fixedTime = "")
    {
        string newFilename = GetUniqueFileName(fileName, suffix, fixedTime);
        string connectionString = _configuration["AzureStorage:ConnectionString"];

        var blobClient = new BlobClient(connectionString, containerName, newFilename);

        await blobClient.UploadAsync(stream, new BlobHttpHeaders { ContentType = contentType });

        return blobClient.Name;
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
        string newFilename = GetUniqueFileName(fileName);
        string contentType = "";
        string connectionString = _configuration["AzureStorage:ConnectionString"];

        var blobClient = new BlobClient(connectionString, containerName, newFilename);

        blobClient.Upload(stream, new BlobHttpHeaders { ContentType = contentType });

        return blobClient.Name;
    }

    /// <summary>
    /// Delete the file from storage
    /// </summary>
    /// <param name="containerName"></param>
    /// <param name="fileName"></param>
    public async Task<bool> DeleteAsync(string containerName, string fileName)
    {
        string connectionString = _configuration["AzureStorage:ConnectionString"];

        BlobServiceClient storageAccount = new BlobServiceClient(connectionString);
        BlobContainerClient container = storageAccount.GetBlobContainerClient(containerName);

        string fullFilePath = $"{containerName}/{fileName}".Replace("web/", "");

        var blobClient = container.GetBlobClient(fullFilePath);
        return await blobClient.DeleteIfExistsAsync();
    }

    /// <summary>
    /// Delete the file from storage
    /// </summary>
    /// <param name="containerName"></param>
    /// <param name="fileName"></param>
    public void Delete(string containerName, string fileName)
    {
        string connectionString = _configuration["AzureStorage:ConnectionString"];

        BlobServiceClient storageAccount = new BlobServiceClient(connectionString);
        BlobContainerClient container = storageAccount.GetBlobContainerClient(containerName);

        var blobClient = container.GetBlobClient(fileName);
        blobClient.DeleteIfExists();
    }

    /// <summary>
    /// Generate a unique name to the file
    /// </summary>
    /// <param name="fileName"></param>
    /// <param name="suffix"></param>
    /// <param name="fixedTime"></param>
    /// <param name="handleSeparators"></param>
    /// <returns>Returns the file name</returns>
    private string GetUniqueFileName(string fileName, string suffix = "", string fixedTime = "", string handleSeparators = @"[._]")
    {
        fileName = Path.GetFileName(fileName).ToLower();

        string newFilename = Path.GetFileNameWithoutExtension(fileName);
        string now = fixedTime is null || fixedTime == string.Empty ? DateTime.UtcNow.ToString().Normalize() : fixedTime;

        now = Regex.Replace(now, @"[^0-9a-zA-Z]+", string.Empty);

        if (!string.IsNullOrWhiteSpace(handleSeparators)) newFilename = Regex.Replace(newFilename, handleSeparators, string.Empty);

        newFilename = FormatString.RemoveDiacritics(newFilename, "-");

        string fullImageName = string.Empty;

        if (suffix == string.Empty)
        {
            fullImageName = newFilename
                + "_"
                + now
                + Path.GetExtension(fileName);
        } else {
            fullImageName = newFilename
                + "_"
                + now
                + "_"
                + suffix
                + Path.GetExtension(fileName);
        }

        return fullImageName;
    }

    /// <summary>
    /// Get file path to storage
    /// </summary>
    /// <param name="folder"></param>
    /// <param name="fileName"></param>
    /// <returns>Returns the file url</returns>
    public string GetPath(string folder, string fileName)
    {
        string containerName = _configuration[$"AzureStorage:Containers:{folder}"];
        string connectionString = _configuration["AzureStorage:ConnectionString"];

        BlobServiceClient storageAccount = new BlobServiceClient(connectionString);
        BlobContainerClient container = storageAccount.GetBlobContainerClient(containerName);

        string fullFilePath = $"{containerName}/{fileName}".Replace("web/", "");

        BlobClient blobClient = container.GetBlobClient(fullFilePath);

        return blobClient.Uri.AbsoluteUri;
    }

    /// <summary>
    /// Get the file from storage
    /// </summary>
    /// <param name="containerName"></param>
    /// <param name="fileName"></param>
    public async Task<Stream> GetAsync(string containerName, string fileName)
    {
        string connectionString = _configuration["AzureStorage:ConnectionString"];

        MemoryStream memoryStream = new MemoryStream();

        try
        {
            BlobServiceClient storageAccount = new BlobServiceClient(connectionString);
            BlobContainerClient container = storageAccount.GetBlobContainerClient(containerName);

            string fullFilePath = $"{containerName}/{fileName}".Replace("web/", "");

            BlobClient blobClient = container.GetBlobClient(fullFilePath);

            if (await blobClient.ExistsAsync())
            {
                var response = await blobClient.DownloadAsync();

                using (Stream fileStream = response.Value.Content)
                {
                    fileStream.CopyTo(memoryStream);
                }
            }

        }
        catch (System.Exception ex)
        {
            throw new Exception(ex.Message);
        }

        return memoryStream;
    }
}