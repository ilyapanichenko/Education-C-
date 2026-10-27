using System.Text.Json.Serialization;
namespace Qase_IoTests.Core.Models;

public class ErrorResponseDto
{
    [JsonPropertyName("status")] public bool Status { get; set; }
    [JsonPropertyName("errorMessage")] public string ErrorMessage { get; set; }
}