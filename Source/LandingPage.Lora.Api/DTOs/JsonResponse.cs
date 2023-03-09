using System.Text.Json.Serialization;

namespace LandingPage.Lora.Api.DTOs;

public class JsonResponse<TData>
{
   /// <summary>
    /// Response message
    /// </summary>
    [JsonPropertyName("message")]
    public String Message { get; set; }

    /// <summary>
    /// Response status code
    /// </summary>
    [JsonPropertyName("statusCode")]
    public Int32 StatusCode { get; set; }

    /// <summary>
    /// Response data
    /// </summary>
    [JsonPropertyName("data")]
    public TData Data { get; set; }

    /// <summary>
    /// Response validation errors
    /// </summary>
    [JsonPropertyName("errors")]
    public Dictionary<string, string[]> Errors { get; set; }
}
