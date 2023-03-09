namespace LandingPage.Lora.Domain.Interfaces.Services;

public interface IFileService
{
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
    Task<string> UploadAsync(Stream stream, string containerName, string fileName, string contentType, string suffix = "", string fixedTime = "");

    /// <summary>
    /// Upload the file to storage
    /// </summary>
    /// <param name="stream"></param>
    /// <param name="containerName"></param>
    /// <param name="fileName"></param>
    /// <returns>Returns the file url</returns>
    string Upload(Stream stream, string containerName, string fileName);

    /// <summary>
    /// Delete the file from storage
    /// </summary>
    /// <param name="containerName"></param>
    /// <param name="fileName"></param>
    Task<bool> DeleteAsync(string containerName, string fileName);

    /// <summary>
    /// Delete the file from storage
    /// </summary>
    /// <param name="containerName"></param>
    /// <param name="fileName"></param>
    void Delete(string containerName, string fileName);

    /// <summary>
    /// Get file path to storage
    /// </summary>
    /// <param name="containerName"></param>
    /// <param name="fileName"></param>
    /// <returns>Returns the file url</returns>
    string GetPath(string containerName, string fileName);

    /// <summary>
    /// Get the file from storage
    /// </summary>
    /// <param name="containerName"></param>
    /// <param name="fileName"></param>
    Task<Stream> GetAsync(string folder, string fileName);
}
