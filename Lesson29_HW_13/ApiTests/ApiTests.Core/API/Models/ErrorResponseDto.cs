using System.Text.Json.Serialization;

namespace ApiTests.Core.API.Models;

public class ErrorResponseDto
{
    [JsonPropertyName("error")] public string? Error { get; set; }
}
