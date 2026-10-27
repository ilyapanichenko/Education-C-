using Allure.NUnit;
using NUnit.Framework.Interfaces;
using Qase_IoTests.Core.Api;
using Qase_IoTests.Core.Configuration;
using Qase_IoTests.Core.Logging;

namespace Qase_IoTests.Tests.BaseTests;

[AllureNUnit]
public abstract class BaseTest
{
    protected ApiClient ApiClient = null!;

    [SetUp]
    public void SetUp()
    {
        TestLogger.Info($"Test started:  {TestContext.CurrentContext.Test.Name}");
    }

    [TearDown]
    public void TearDown()
    {
        var testName = TestContext.CurrentContext.Test.Name;
        var status = TestContext.CurrentContext.Result.Outcome.Status;
        if (status == TestStatus.Failed)
        {
            TestLogger.Error($"Test failed: {testName}");
        }
        else if (status == TestStatus.Skipped)
        {
            TestLogger.Warning($"Test skipped: {testName}");
        }
        else if (status == TestStatus.Passed)
        {
            TestLogger.Info($"Test finished: {testName} | {status}");
        }
    }
    [OneTimeSetUp]
    public void OneTimeSetup()
    {
        ApiClient = new ApiClient(TestConfig.BaseUrl, TestConfig.ApiKey);
    }
    
    [OneTimeTearDown]
    public void OneTimeTearDown()
    {
        ApiClient.Dispose();
    }
}