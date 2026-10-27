using System.Net;
using Qase_IoTests.Core.Configuration;
using Qase_IoTests.Core.Models;
using Qase_IoTests.Tests.BaseTests;
using Qase_IoTests.Tests.Helpers;
using RestSharp;

namespace Qase_IoTests.Tests.ApiTests;

[TestFixture]
public class SuiteTests : BaseTest
{
    [Test]
    public async Task GetSuites()
    {
        var response = await ApiClient.SendAsync<SuitesResponseDto>($"/v1/suite/{TestConfig.ProjectCode}?limit=1", Method.Get);
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        Assert.That(response.Data, Is.Not.Null);
        Assert.That(response.Data.Status, Is.True);
        Assert.That(response.Data.Result.Count, Is.EqualTo(1));
        Assert.That(response.Data.Result.Entities, Has.Count.EqualTo(1));
        var suite = response.Data.Result.Entities[0];
        Assert.That(suite.Id, Is.GreaterThan(0));
        Assert.That(suite.Title, Is.Not.Empty);
        Assert.That(suite.CasesCount, Is.GreaterThanOrEqualTo(0));
    }
    [Test]
    public async Task PostCreateGetDeleteSuite()
    {
        var title = "Diploma API Test Suite";
        var created = await ApiClient.SendAsync<CreateSuiteResponseDto>($"/v1/suite/{TestConfig.ProjectCode}", Method.Post, new { title });
        Assert.That(created.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        Assert.That(created.Data, Is.Not.Null);
        Assert.That(created.Data.Result, Is.Not.Null);
        var suiteId = created.Data.Result.Id;
        Assert.That(suiteId, Is.GreaterThan(0));
        var endpoint = $"/v1/suite/{TestConfig.ProjectCode}/{suiteId}";
        await TestCleanup.ExecuteWithCleanupAsync(async () =>
            {
                var received = await ApiClient.SendAsync<SuiteResponseDto>(endpoint, Method.Get);
                Assert.That(received.StatusCode, Is.EqualTo(HttpStatusCode.OK));
                Assert.That(received.Data, Is.Not.Null);
                Assert.That(received.Data.Result.Id, Is.EqualTo(suiteId));
                Assert.That(received.Data.Result.Title, Is.EqualTo(title));
                Assert.That(received.Data.Result.CasesCount, Is.EqualTo(0));
            }, () => TestCleanup.DeleteAndVerifyAsync(ApiClient, endpoint), $"test suite: {suiteId}");
    }
    [Test]
    public async Task PatchUpdateSuite()
    {
        var created = await ApiClient.SendAsync<CreateSuiteResponseDto>($"/v1/suite/{TestConfig.ProjectCode}", Method.Post, new { title = "Original Suite" });
        Assert.That(created.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        Assert.That(created.Data, Is.Not.Null);
        Assert.That(created.Data.Result, Is.Not.Null);
        var suiteId = created.Data.Result.Id;
        Assert.That(suiteId, Is.GreaterThan(0));
        var endpoint = $"/v1/suite/{TestConfig.ProjectCode}/{suiteId}";
        await TestCleanup.ExecuteWithCleanupAsync(async () =>
            {
                var updated = await ApiClient.SendAsync<object>(endpoint, Method.Patch, new { title = "Updated Suite" });
                Assert.That(updated.StatusCode, Is.EqualTo(HttpStatusCode.OK));
                var received = await ApiClient.SendAsync<SuiteResponseDto>(endpoint, Method.Get);
                Assert.That(received.StatusCode, Is.EqualTo(HttpStatusCode.OK));
                Assert.That(received.Data, Is.Not.Null);
                Assert.That(received.Data.Result.Id, Is.EqualTo(suiteId));
                Assert.That(received.Data.Result.Title, Is.EqualTo("Updated Suite"));
            }, () => TestCleanup.DeleteAndVerifyAsync(ApiClient, endpoint, verifyNotFound: false), $"test suite: {suiteId}");
    }
}