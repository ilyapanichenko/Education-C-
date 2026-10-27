using System.Text.Json.Serialization;

namespace Qase_IoTests.Core.Models;

public sealed class ResultDto
{
    [JsonPropertyName("total")] public int Total { get; set; }
    [JsonPropertyName("filtered")] public int Filtered { get; set; }
    [JsonPropertyName("count")] public int Count { get; set; }
    [JsonPropertyName("entities")] public List<ProjectDto> Entities { get; set; }
}

public class ProjectsResponseDto
{
    [JsonPropertyName("status")] public bool Status { get; set; }
    [JsonPropertyName("result")] public ResultDto Result { get; set; }
}

public class ProjectDto
{
    [JsonPropertyName("title")] public string Title { get; set; }
    [JsonPropertyName("code")] public string Code { get; set; }
}

public class ProjectResponseDto
{
    [JsonPropertyName("status")] public bool Status { get; set; }
    [JsonPropertyName("result")] public ProjectDto Result { get; set; }
}