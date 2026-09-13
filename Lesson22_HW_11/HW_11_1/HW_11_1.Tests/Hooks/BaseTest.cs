using HW_11_1.Core;

namespace HW_11_1.Tests.Hooks;

public abstract class BaseTest
{
    protected Calculator Calculator { get; } = new();

    [OneTimeSetUp]
    public void OneTimeSetup()
    {
        Console.WriteLine("OneTimeSetUp");
    }

    [SetUp]
    public void Setup()
    {
        Console.WriteLine(
            $"SetUp: {TestContext.CurrentContext.Test.Name}, " +
            $"Thread: {Environment.CurrentManagedThreadId}");
    }

    [TearDown]
    public void TearDown()
    {
        Console.WriteLine(
            $"TearDown: {TestContext.CurrentContext.Test.Name}, " +
            $"Thread: {Environment.CurrentManagedThreadId}");
    }

    [OneTimeTearDown]
    public void OneTimeTearDown()
    {
        Console.WriteLine("OneTimeTearDown");
    }
}