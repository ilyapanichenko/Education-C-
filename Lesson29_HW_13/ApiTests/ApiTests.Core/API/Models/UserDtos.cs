using System.Text.Json.Serialization;

namespace ApiTests.Core.API.Models;

public class UserDto
{
    [JsonPropertyName("id")] public int Id { get; set; }
    [JsonPropertyName("email")] public string? Email { get; set; }
    [JsonPropertyName("first_name")] public string? FirstName { get; set; }
    [JsonPropertyName("last_name")] public string? LastName { get; set; }
}

public class UserResponseDto
{
    [JsonPropertyName("data")] public UserDto? Data { get; set; }
}

public class UsersPageDto
{
    [JsonPropertyName("page")] public int Page { get; set; }
    [JsonPropertyName("per_page")] public int PerPage { get; set; }
    [JsonPropertyName("total")] public int Total { get; set; }
    [JsonPropertyName("total_pages")] public int TotalPages { get; set; }
    [JsonPropertyName("data")] public List<UserDto>? Data { get; set; }
}

public class UserWriteRequestDto
{
    [JsonPropertyName("name")] public string Name { get; set; } = string.Empty;
    [JsonPropertyName("job")] public string Job { get; set; } = string.Empty;
}

public class UserMutationResponseDto
{
    [JsonPropertyName("id")] public string? Id { get; set; }
    [JsonPropertyName("name")] public string? Name { get; set; }
    [JsonPropertyName("job")] public string? Job { get; set; }
    [JsonPropertyName("createdAt")] public string? CreatedAt { get; set; }
    [JsonPropertyName("updatedAt")] public string? UpdatedAt { get; set; }
}
