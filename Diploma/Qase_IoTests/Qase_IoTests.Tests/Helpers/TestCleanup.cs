using System.Net;
using Qase_IoTests.Core.Api;
using Qase_IoTests.Core.Logging;
using Qase_IoTests.Core.Models;
using RestSharp;

namespace Qase_IoTests.Tests.Helpers;

public static class TestCleanup
{
    public static async Task ExecuteWithCleanupAsync(Func<Task> testAction, Func<Task> cleanupAction, string entityDescription)
    {
        var testFailed = false;
        try
        {
            await testAction();
        }
        catch
        {
            testFailed = true;
            throw;
        }
        finally
        {
            try
            {
                await cleanupAction();
            }
            catch (Exception cleanupError)
            {
                TestLogger.Error($"Failed to clean up {entityDescription}", cleanupError);
                if (!testFailed)
                    throw;
            }
        }
    }

    public static async Task DeleteAndVerifyAsync(ApiClient client, string endpoint, bool verifyNotFound = true)
    {
        var deleted = await client.SendAsync<object>(endpoint, Method.Delete);
        Assert.That(deleted.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        if (verifyNotFound)
        {
            var afterDelete = await client.SendAsync<ErrorResponseDto>(endpoint, Method.Get);
            Assert.That(afterDelete.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
        }
    }
}