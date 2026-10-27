using System.Text.Json.Serialization;

namespace Qase_IoTests.Core.Models;

public class CasesResponseDto
{
    [JsonPropertyName("status")] public bool Status { get; set; }
    [JsonPropertyName("result")] public CasesResultDto Result { get; set; }
}

public class CasesResultDto
{
    [JsonPropertyName("total")] public int Total { get; set; }
    [JsonPropertyName("count")] public int Count { get; set; }
    [JsonPropertyName("entities")] public List<CaseDto> Entities { get; set; }
}

public class CaseDto
{
    [JsonPropertyName("id")] public int Id { get; set; }
    [JsonPropertyName("position")] public int Position { get; set; }
    [JsonPropertyName("title")] public string Title { get; set; }
}

public class CreateCaseResponseDto
{
    [JsonPropertyName("status")] public bool Status { get; set; }
    [JsonPropertyName("result")] public CreatedCaseDto Result { get; set; }
}

public class CreatedCaseDto
{
    [JsonPropertyName("id")] public int Id { get; set; }
}

public class CaseResponseDto
{
    [JsonPropertyName("status")] public bool Status { get; set; }
    [JsonPropertyName("result")] public CaseDto Result { get; set; }
}