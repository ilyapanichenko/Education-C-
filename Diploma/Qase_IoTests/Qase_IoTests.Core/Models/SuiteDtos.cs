using System.Text.Json.Serialization;

namespace Qase_IoTests.Core.Models;

public class SuitesResponseDto
{
    [JsonPropertyName("status")]
    public bool Status { get; set; }

    [JsonPropertyName("result")]
    public SuitesResultDto Result { get; set; }
}

public class SuitesResultDto
{
    [JsonPropertyName("total")]
    public int Total { get; set; }

    [JsonPropertyName("count")]
    public int Count { get; set; }

    [JsonPropertyName("entities")]
    public List<SuiteDto> Entities { get; set; }
}

public class SuiteDto
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("title")]
    public string Title { get; set; }

    [JsonPropertyName("cases_count")]
    public int CasesCount { get; set; }
}
public class CreateSuiteResponseDto
{
    [JsonPropertyName("status")]
    public bool Status { get; set; }

    [JsonPropertyName("result")]
    public CreatedSuiteDto Result { get; set; }
}

public class CreatedSuiteDto
{
    [JsonPropertyName("id")]
    public int Id { get; set; }
}

public class SuiteResponseDto
{
    [JsonPropertyName("status")]
    public bool Status { get; set; }

    [JsonPropertyName("result")]
    public SuiteDto Result { get; set; }
}