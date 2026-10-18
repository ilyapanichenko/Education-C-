using System.Text.Json.Serialization;

namespace ApiTests.Core.API.Models;

public class CredentialsRequestDto
{
    [JsonPropertyName("email")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Email { get; set; }

    [JsonPropertyName("password")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Password { get; set; }
}

public class AuthResponseDto
{
    [JsonPropertyName("id")] public int? Id { get; set; }
    [JsonPropertyName("token")] public string? Token { get; set; }
}
