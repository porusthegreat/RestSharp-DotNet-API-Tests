using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace PurgoMalumTests.DTO;

public class ProfanityResponse
{
    
    [JsonPropertyName("result")]
    public string? Result { get; set; }
}