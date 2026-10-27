using System.Net;
using Allure.Net.Commons;
using Allure.NUnit;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Qase_IoTests.Core.Api;
using Qase_IoTests.Core.Configuration;
using Qase_IoTests.Core.Logging;
using Qase_IoTests.Core.Models;
using Qase_IoTests.Core.Pages;
using Qase_IoTests.Core.Utilities;
using Qase_IoTests.Core.WebDriver;
using Qase_IoTests.Tests.Helpers;
using RestSharp;

namespace Qase_IoTests.Tests.BaseTests;

[AllureNUnit]
public abstract class BaseUiTest
{
    protected IWebDriver Driver = null!;

    [SetUp]
    public void SetUp()
    {
        TestLogger.Info(
            $"UI test started: {TestContext.CurrentContext.Test.Name} | " +
            $"Browser: {TestConfig.BrowserSettings.Browser}"
        );
        Driver = DriverFactory.CreateDriver();
    }
    protected ProjectsPage LoginAsValidUser()
    {
        var loginPage = new LoginPage(Driver);

        loginPage.Open();
        loginPage.AcceptCookiesIfPresent();
        loginPage.EnterEmail(TestConfig.UiEmail);
        loginPage.EnterPassword(TestConfig.UiPassword);
        loginPage.ClickLogin();

        var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(15));

        try
        {
            wait.Until(driver =>
            {
                if (new Uri(driver.Url).AbsolutePath == "/projects")
                    return true;

                var error = loginPage.GetVisibleLoginError();

                if (!string.IsNullOrWhiteSpace(error))
                {
                    throw new InvalidOperationException(
                        $"Qase login failed: {error}. URL: {driver.Url}");
                }

                return false;
            });
        }
        catch (WebDriverTimeoutException)
        {
            throw new WebDriverTimeoutException(
                $"Qase login timeout. Current URL: {Driver.Url}. " +
                $"Login error: {loginPage.GetVisibleLoginError() ?? "Not detected"}");
        }

        return new ProjectsPage(Driver);
    }

    protected async Task DeleteCaseViaApiAsync(int caseId)
    {
        using var client = new ApiClient(TestConfig.BaseUrl, TestConfig.ApiKey);
        await TestCleanup.DeleteAndVerifyAsync(client, $"/v1/case/{TestConfig.ProjectCode}/{caseId}");
    }

    protected async Task<int?> FindCaseIdViaApiAsync(string title)
    {
        using var client = new ApiClient(TestConfig.BaseUrl, TestConfig.ApiKey);
        var search = Uri.EscapeDataString(title);
        var endpoint = $"/v1/case/{TestConfig.ProjectCode}?search={search}";
        var response = await client.SendAsync<CasesResponseDto>(endpoint, Method.Get);
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        return response.Data?.Result?.Entities?.FirstOrDefault(c => c.Title == title)?.Id;
    }
    protected async Task<int?> FindSuiteIdViaApiAsync(string title)
    {
        using var client = new ApiClient(TestConfig.BaseUrl, TestConfig.ApiKey);
        var search = Uri.EscapeDataString(title);
        var endpoint = $"/v1/suite/{TestConfig.ProjectCode}?search={search}";
        var response = await client.SendAsync<SuitesResponseDto>(endpoint, Method.Get);
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        return response.Data?.Result?.Entities?.FirstOrDefault(s => s.Title == title)?.Id;
    }

    protected async Task DeleteSuiteViaApiAsync(int suiteId)
    {
        using var client = new ApiClient(TestConfig.BaseUrl, TestConfig.ApiKey);
        await TestCleanup.DeleteAndVerifyAsync(client, $"/v1/suite/{TestConfig.ProjectCode}/{suiteId}");
    }
    protected async Task<int> CreateSuiteViaApiAsync(string title)
    {
        using var client = new ApiClient(TestConfig.BaseUrl, TestConfig.ApiKey);
        var response = await client.SendAsync<CreateSuiteResponseDto>($"/v1/suite/{TestConfig.ProjectCode}", Method.Post, new { title });
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        Assert.That(response.Data?.Result, Is.Not.Null);
        return response.Data!.Result.Id;
    }
    [TearDown]
    public void TearDown()
    {
        var testName = TestContext.CurrentContext.Test.Name;
        var status = TestContext.CurrentContext.Result.Outcome.Status;
        try
        {
            if (status == TestStatus.Failed)
            {
                TestLogger.Error($"UI test failed: {testName}");
                if (Driver != null)
                {
                    try
                    {
                        var path = ScreenshotHelper.Save(Driver, testName);
                        TestContext.AddTestAttachment(path, "Screenshot on failure");
                        AllureApi.AddAttachment("Screenshot on failure", "image/png", path);
                        TestLogger.Info($"Screenshot saved: {path}");
                    }
                    catch (Exception ex)
                    {
                        TestLogger.Error("Failed to save screenshot", ex);
                    }
                }
            }
            else if (status == TestStatus.Passed)
            {
                TestLogger.Info($"UI test finished: {testName} | {status}");
            }
            else
            {
                TestLogger.Warning($"UI test finished: {testName} | {status}");
            }
        }
        finally
        {
            if (Driver != null)
            {
                try
                {
                    Driver.Quit();
                }
                finally
                {
                    Driver.Dispose();
                }
            }
        }
    }
}