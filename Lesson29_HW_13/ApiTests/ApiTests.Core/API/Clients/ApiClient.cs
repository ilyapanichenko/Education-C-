using RestSharp;

namespace ApiTests.Core.API.Clients;

public sealed class ApiClient : IDisposable
{
    private readonly RestClient _client = new("https://reqres.in");
    private readonly string _apiKey;

    public ApiClient(string apiKey)
    {
        _apiKey = apiKey;
    }

    public Task<RestResponse<T>> SendAsync<T>(string resource, Method method, object? body = null)
    {
        var request = new RestRequest(resource, method);
        request.AddHeader("x-api-key", _apiKey);
        if (body is not null) request.AddJsonBody(body);
        return _client.ExecuteAsync<T>(request);
    }

    public void Dispose()
    {
        _client.Dispose();
    }
}
