using ApiTests.Core.API.Models;
using RestSharp;

namespace ApiTests.Core.API.Clients;

public class ResourcesClient
{
    private readonly ApiClient _api;

    public ResourcesClient(ApiClient api)
    {
        _api = api;
    }

    public Task<RestResponse<ResourcesPageDto>> GetAll() =>
        _api.SendAsync<ResourcesPageDto>("/api/unknown", Method.Get);

    public Task<RestResponse<ResourceResponseDto>> GetById(int id) =>
        _api.SendAsync<ResourceResponseDto>($"/api/unknown/{id}", Method.Get);
}
