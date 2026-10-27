using System.Net;
using Qase_IoTests.Core.Configuration;
using Qase_IoTests.Core.Models;
using Qase_IoTests.Tests.BaseTests;
using Qase_IoTests.Tests.Helpers;
using RestSharp;
using ErrorResponseDto = Qase_IoTests.Core.Models.ErrorResponseDto;

namespace Qase_IoTests.Tests.ApiTests;

[TestFixture]
public class CaseTests : BaseTest
{
    [Test]
    public async Task GetTestCases()
    {
        var response = await ApiClient.SendAsync<CasesResponseDto>($"/v1/case/{TestConfig.ProjectCode}?limit=1", Method.Get);
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        Assert.That(response.Data, Is.Not.Null);
        Assert.That(response.Data.Status, Is.True);
        Assert.That(response.Data.Result.Count, Is.EqualTo(1));
        Assert.That(response.Data.Result.Entities.Count, Is.EqualTo(1));
        var testCase = response.Data.Result.Entities[0];
        Assert.That(testCase.Id, Is.GreaterThan(0));
        Assert.That(testCase.Title, Is.Not.Empty);
    }

    [Test]
    public async Task PostCreateGetDeleteCase()
    {
        var body = new
        {
            title = "Diploma API Test Case",
            description = "Created by automated API test",
            preconditions = "User is logged in"
        };
        var created = await ApiClient.SendAsync<CreateCaseResponseDto>($"/v1/case/{TestConfig.ProjectCode}", Method.Post, body);
        Assert.That(created.Data, Is.Not.Null);
        Assert.That(created.Data.Result, Is.Not.Null);
        var caseId = created.Data.Result.Id;
        Assert.That(caseId, Is.GreaterThan(0));
        var endpoint = $"/v1/case/{TestConfig.ProjectCode}/{caseId}";
        await TestCleanup.ExecuteWithCleanupAsync(async () =>
            {
                Assert.That(created.StatusCode, Is.EqualTo(HttpStatusCode.OK));
                Assert.That(created.Data.Status, Is.True);
                var received = await ApiClient.SendAsync<CaseResponseDto>(endpoint, Method.Get);
                Assert.That(received.StatusCode, Is.EqualTo(HttpStatusCode.OK));
                Assert.That(received.Data, Is.Not.Null);
                Assert.That(received.Data.Result.Id, Is.EqualTo(caseId));
                Assert.That(received.Data.Result.Title, Is.EqualTo("Diploma API Test Case"));
            }, () => TestCleanup.DeleteAndVerifyAsync(ApiClient, endpoint), $"test case: {caseId}");
    }
    [Test]
    public async Task PatchUpdateCase()
    {
        var body = new
        {
            title = "Original Test Case"
        };
        var created = await ApiClient.SendAsync<CreateCaseResponseDto>($"/v1/case/{TestConfig.ProjectCode}", Method.Post, body);
        Assert.That(created.Data, Is.Not.Null);
        Assert.That(created.Data.Result, Is.Not.Null);
        var caseId = created.Data.Result.Id;
        Assert.That(caseId, Is.GreaterThan(0));
        var endpoint = $"/v1/case/{TestConfig.ProjectCode}/{caseId}";
        await TestCleanup.ExecuteWithCleanupAsync(async () =>
            {
                Assert.That(created.StatusCode, Is.EqualTo(HttpStatusCode.OK));
                var updated = await ApiClient.SendAsync<object>(endpoint, Method.Patch, new { title = "Updated Test Case" });
                Assert.That(updated.StatusCode, Is.EqualTo(HttpStatusCode.OK));
                var received = await ApiClient.SendAsync<CaseResponseDto>(endpoint, Method.Get);
                Assert.That(received.StatusCode, Is.EqualTo(HttpStatusCode.OK));
                Assert.That(received.Data, Is.Not.Null);
                Assert.That(received.Data.Result.Id, Is.EqualTo(caseId));
                Assert.That(received.Data.Result.Title, Is.EqualTo("Updated Test Case"));
            }, () => TestCleanup.DeleteAndVerifyAsync(ApiClient, endpoint, verifyNotFound: false), $"test case: {caseId}");
    }
    
    [Test]
    public async Task GetCaseByInvalidId()
    {
        var response = await ApiClient.SendAsync<ErrorResponseDto>($"/v1/case/{TestConfig.ProjectCode}/999999999", Method.Get);
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound), $"Response: {response.Content}");
        Assert.That(response.Data, Is.Not.Null);
        Assert.That(response.Data.Status, Is.False);
    }
    [Test]
    public async Task PostCreateCaseWithoutTitle()
    {
        var body = new
        {
            description = "Test case without title"
        };
        var response = await ApiClient.SendAsync<ErrorResponseDto>($"/v1/case/{TestConfig.ProjectCode}", Method.Post, body);
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.UnprocessableEntity), $"Actual response: {response.Content}");
        Assert.That(response.Data, Is.Not.Null);
        Assert.That(response.Data.Status, Is.False);
    }
}