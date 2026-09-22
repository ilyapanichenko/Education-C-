using Allure.NUnit;
using Allure.NUnit.Attributes;
using HW_11_1.Core;
using log4net;
using NUnit.Framework.Interfaces;

namespace HW_11_1.Tests.Hooks;

[AllureNUnit]
public abstract class BaseTest
{
    protected ILog Logger => LogManager.GetLogger(GetType());
    protected Calculator Calculator { get; } = new();

    [OneTimeSetUp]
    [AllureBefore("Start test fixture")]
    public void OneTimeSetup()
    {
        Logger.Info($"[FIXTURE START] {GetType().Name}");
    }

    [SetUp]
    [AllureBefore("Prepare test")]
    public void Setup()
    {
        Logger.Info($"[START] {TestContext.CurrentContext.Test.Name}");
    }

    [TearDown]
    [AllureAfter("Finish test")]
    public void TearDown()
    {
        var testName = TestContext.CurrentContext.Test.Name;
        var result = TestContext.CurrentContext.Result;
        var status = result.Outcome.Status;

        switch (status)
        {
            case TestStatus.Passed:
                Logger.Info($"[PASS] {testName}");
                break;

            case TestStatus.Failed:
                Logger.Error($"[FAIL] {testName} | Message: {result.Message} | StackTrace: {result.StackTrace}");
                break;

            case TestStatus.Skipped:
                Logger.Warn($"[SKIP] {testName}");
                break;

            default:
                Logger.Warn($"[{status.ToString().ToUpper()}] {testName}");
                break;
        }
    }

    [OneTimeTearDown]
    [AllureAfter("Finish test fixture")]
    public void OneTimeTearDown()
    {
        Logger.Info($"[FIXTURE END] {GetType().Name}");
    }
}