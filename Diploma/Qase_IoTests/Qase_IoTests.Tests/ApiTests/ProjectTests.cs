using System.Net;
using Qase_IoTests.Core.Configuration;
using Qase_IoTests.Core.Models;
using Qase_IoTests.Tests.BaseTests;
using Qase_IoTests.Tests.Helpers;
using RestSharp;

namespace Qase_IoTests.Tests.ApiTests;

[TestFixture]
public class ProjectTests : BaseTest
{
    [Test]
    public async Task GetProjects()
    {
        var response = await ApiClient.SendAsync<ProjectsResponseDto>("/v1/project", Method.Get);
        Assert.That(response, Is.Not.Null);
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        Assert.That(response.Data, Is.Not.Null);
        Assert.That(response.Data.Status, Is.True);
        Assert.That(response.Data.Result.Entities, Is.Not.Empty);
        var project = response.Data.Result.Entities.FirstOrDefault(p => p.Code == TestConfig.ProjectCode);
        Assert.That(project, Is.Not.Null);
        Assert.That(project.Title, Is.EqualTo("Getting Started"));
    }

    [Test]
    public async Task GetProjectByCode()
    {
        var response = await ApiClient.SendAsync<ProjectResponseDto>($"/v1/project/{TestConfig.ProjectCode}", Method.Get);
        Assert.That(response, Is.Not.Null);
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        Assert.That(response.Data, Is.Not.Null);
        Assert.That(response.Data.Result.Code, Is.EqualTo(TestConfig.ProjectCode));
    }

    [Test]
    public async Task GetProjectByInvalidCode()
    {
        var response = await ApiClient.SendAsync<ErrorResponseDto>("/v1/project/UNKNOWN123", Method.Get);
        Assert.That(response, Is.Not.Null);
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
        Assert.That(response.Data, Is.Not.Null);
        Assert.That(response.Data.Status, Is.False);
        Assert.That(response.Data.ErrorMessage, Is.EqualTo("Project not found"));
    }

    [Test]
    [Ignore("Qase Free plan - project creation is Forbidden")]
    public async Task PostCreateDeleteProject()
    {
        var projectCode = "QA" +new string(Enumerable.Range(0, 6).Select(_ => (char)Random.Shared.Next('A', 'Z' + 1)).ToArray());
        var endpoint = $"/v1/project/{projectCode}";
        var body = new
        {
            title = "Diploma API Test",
            code = projectCode,
            description = "Project created by automated API test"
        };
        var created = await ApiClient.SendAsync<object>("/v1/project", Method.Post, body);
        Assert.That(created.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        await TestCleanup.ExecuteWithCleanupAsync(async () =>
            {
                var project = await ApiClient.SendAsync<ProjectResponseDto>(endpoint, Method.Get);
                Assert.That(project.StatusCode, Is.EqualTo(HttpStatusCode.OK));
                Assert.That(project.Data, Is.Not.Null);
                Assert.That(project.Data.Result.Title, Is.EqualTo("Diploma API Test"));
                Assert.That(project.Data.Result.Code, Is.EqualTo(projectCode));
            }, () => TestCleanup.DeleteAndVerifyAsync(ApiClient, endpoint, verifyNotFound: false), $"project: {projectCode}");
    }
}