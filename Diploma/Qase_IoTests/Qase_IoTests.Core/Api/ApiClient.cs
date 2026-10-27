using System.Diagnostics;
using Qase_IoTests.Core.Logging;
using RestSharp;

namespace Qase_IoTests.Core.Api;

public class ApiClient : IDisposable
{
    private readonly string _apiKey;
    private readonly RestClient _client;

    public ApiClient(string baseUrl, string apiKey)
    {
        _client = new RestClient(baseUrl);
        _apiKey = apiKey;
    }

    public async Task<RestResponse<T>> SendAsync<T>(string resource, Method method, object? body = null)
    {
        var request = new RestRequest(resource, method);
        request.AddHeader("Token", _apiKey);
        if (body is not null) request.AddJsonBody(body);
        TestLogger.Info($"Request: {method} {resource}");
        var stopwatch = Stopwatch.StartNew();
        var response = await _client.ExecuteAsync<T>(request);
        stopwatch.Stop();
        TestLogger.Info($"Response: {(int)response.StatusCode} {response.StatusCode} | {stopwatch.ElapsedMilliseconds} ms");
        if (response.StatusCode == 0 && response.ErrorException is not null)
        {
            TestLogger.Error($"Request error: {method} {resource}", response.ErrorException);
        }
        return response;
    }

    public void Dispose()
    {
        _client.Dispose();
    }
}