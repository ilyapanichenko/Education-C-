using ApiTests.Core.API.Models;
using RestSharp;

namespace ApiTests.Core.API.Clients;

public class UsersClient
{
    private readonly ApiClient _api;

    public UsersClient(ApiClient api)
    {
        _api = api;
    }

    public Task<RestResponse<UserResponseDto>> GetUser(int id) =>
        _api.SendAsync<UserResponseDto>($"/api/users/{id}", Method.Get);

    public Task<RestResponse<UsersPageDto>> GetPage(int page) =>
        _api.SendAsync<UsersPageDto>($"/api/users?page={page}", Method.Get);

    public Task<RestResponse<UserMutationResponseDto>> Create(UserWriteRequestDto user) =>
        _api.SendAsync<UserMutationResponseDto>("/api/users", Method.Post, user);

    public Task<RestResponse<UserMutationResponseDto>> Update(int id, UserWriteRequestDto changes) =>
        _api.SendAsync<UserMutationResponseDto>($"/api/users/{id}", Method.Put, changes);

    public Task<RestResponse<object>> Delete(int id) =>
        _api.SendAsync<object>($"/api/users/{id}", Method.Delete);
}
