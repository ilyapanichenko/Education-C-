using System.Text.Json;
using ApiTests.Core.API.Clients;
using ApiTests.Core.API.Models;
using RestSharp;

namespace ApiTesting.Tests.API;

public abstract class BaseApiTest
{
    private ApiClient? _apiClient;

    private ApiClient Api => _apiClient ?? throw new InvalidOperationException("API client is not initialized.");
    protected UsersClient Users => new(Api);
    protected ResourcesClient Resources => new(Api);
    protected AuthClient Auth => new(Api);

    [OneTimeSetUp]
    public void OneTimeSetUp()
    {
        var apiKey = Environment.GetEnvironmentVariable("REQRES_API_KEY");
        if (string.IsNullOrWhiteSpace(apiKey))
            throw new InvalidOperationException("Set the REQRES_API_KEY environment variable before running tests.");
        _apiClient = new ApiClient(apiKey);
    }

    protected static ErrorResponseDto ReadError(RestResponse response)
    {
        var content = response.Content;
        if (string.IsNullOrWhiteSpace(content))
            throw new AssertionException("The error response should contain JSON.");
        return JsonSerializer.Deserialize<ErrorResponseDto>(content) ?? throw new AssertionException("The error response could not be deserialized.");
    }

    [OneTimeTearDown]
    public void OneTimeTearDown()
    {
        _apiClient?.Dispose();
    }
}
