using ApiTests.Core.API.Models;
using RestSharp;

namespace ApiTests.Core.API.Clients;

public class AuthClient
{
    private readonly ApiClient _api;

    public AuthClient(ApiClient api)
    {
        _api = api;
    }

    public Task<RestResponse<T>> Login<T>(CredentialsRequestDto credentials) =>
        _api.SendAsync<T>("/api/login", Method.Post, credentials);

    public Task<RestResponse<T>> Register<T>(CredentialsRequestDto credentials) =>
        _api.SendAsync<T>("/api/register", Method.Post, credentials);
}
