using System.Text.Json.Serialization;

namespace LandingPage.Lora.Api.Site.Resources;

public class PersonResource
{
    [JsonPropertyName("Name")]
    public string Name { get; set; }

    [JsonPropertyName("Email")]
    public string Email { get; set; }
}