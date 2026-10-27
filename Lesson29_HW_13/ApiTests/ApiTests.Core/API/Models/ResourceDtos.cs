using System.Text.Json.Serialization;

namespace ApiTests.Core.API.Models;

public class ResourceDto
{
    [JsonPropertyName("id")] public int Id { get; set; }
    [JsonPropertyName("name")] public string? Name { get; set; }
    [JsonPropertyName("year")] public int Year { get; set; }
    [JsonPropertyName("color")] public string? Color { get; set; }
}

public class ResourceResponseDto
{
    [JsonPropertyName("data")] public ResourceDto? Data { get; set; }
}

public class ResourcesPageDto
{
    [JsonPropertyName("data")] public List<ResourceDto>? Data { get; set; }
}
