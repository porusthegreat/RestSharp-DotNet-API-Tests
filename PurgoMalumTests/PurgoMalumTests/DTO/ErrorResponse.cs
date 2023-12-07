using System.Text.Json.Serialization;

namespace PurgoMalumTests.DTO;

public class ErrorResponse
{
    [JsonPropertyName("error")]
    public string? Error { get; set; }
}